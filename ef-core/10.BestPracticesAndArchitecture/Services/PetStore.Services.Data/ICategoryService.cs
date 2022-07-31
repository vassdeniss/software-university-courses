namespace PetStore.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using PetStore.Data.Models;

    public interface ICategoryService
    {
        IQueryable<Category> All();

        bool ExistsById(int id);
    }
}
