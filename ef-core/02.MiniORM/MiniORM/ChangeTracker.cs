namespace MiniORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    public class ChangeTracker<T> 
        where T : class, new()
    {
        private readonly List<T> allEntities;
        private readonly List<T> added;
        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            this.added = new List<T>();
            this.removed = new List<T>();

            this.allEntities = this.CloneEntities(entities);
        }

        public IReadOnlyCollection<T> AllEntities 
            => this.allEntities.AsReadOnly();

        public IReadOnlyCollection<T> Added 
            => this.added.AsReadOnly();

        public IReadOnlyCollection<T> Removed 
            => this.removed.AsReadOnly();

        public void Add(T item)
        {
            this.added.Add(item);
        }

        public void Remove(T item)
        {
            this.removed.Add(item);
        }

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            List<T> modifiedEntities = new List<T>();

            PropertyInfo[] primaryKeys = typeof(T)
                .GetProperties()
                .Where(x => x.HasAttribute<KeyAttribute>())
                .ToArray();
            foreach (T proxyEntity in this.AllEntities)
            {
                object[] primaryKeyValues = this.GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();
                T entity = dbSet
                    .Entities
                    .Single(e => this.GetPrimaryKeyValues(primaryKeys, e)
                                .SequenceEqual(primaryKeyValues));

                if (this.IsModified(proxyEntity, entity))
                {
                    modifiedEntities.Add(entity);
                }
            }

            return modifiedEntities;
        }

        private IEnumerable<object> GetPrimaryKeyValues(PropertyInfo[] primaryKeys, T proxyEntity)
        {
            return primaryKeys.Select(x => x.GetValue(proxyEntity));
        }

        private bool IsModified(T entity, T proxyEntity)
        {
            IEnumerable<PropertyInfo> monitoredProperties = typeof(T)
                .GetProperties()
                .Where(x => DbContext.AllowedSqlTypes.Contains(x.PropertyType));

            PropertyInfo[] modifiedProperties = monitoredProperties
                .Where(x => !Equals(x.GetValue(entity), x.GetValue(proxyEntity)))
                .ToArray();

            return modifiedProperties.Any();
        }

        private List<T> CloneEntities(IEnumerable<T> entities)
        {
            List<T> clonedEntities = new List<T>();

            PropertyInfo[] propertiesToClone = typeof(T)
                .GetProperties()
                .Where(x => DbContext.AllowedSqlTypes.Contains(x.PropertyType))
                .ToArray();
            foreach (T entity in entities)
            {
                T clonedEntity = Activator.CreateInstance<T>();
                foreach (PropertyInfo property in propertiesToClone)
                {
                    object value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);
                }

                clonedEntities.Add(clonedEntity);
            }

            return clonedEntities;
        }
    }	
}
