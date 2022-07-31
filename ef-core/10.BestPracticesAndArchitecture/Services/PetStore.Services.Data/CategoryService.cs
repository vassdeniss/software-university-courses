namespace PetStore.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using PetStore.Data.Common.Repositories;
    using PetStore.Data.Models;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepo;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public IQueryable<Category> All()
        {
            return this.categoryRepo.AllAsNoTracking();
        }

        public bool ExistsById(int id)
        {
            return this.categoryRepo.AllAsNoTracking().FirstOrDefault(c => c.Id == id) != null;
        }
    }
}
