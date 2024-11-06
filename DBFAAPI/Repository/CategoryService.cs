using DBFAAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DBFAAPI.Repository
{
    public class CategoryService : ICategoryServices
    {
        private readonly BikeStoresContext _bikeStoresContext;
        public CategoryService(BikeStoresContext bikeStoresContext)
        {
            _bikeStoresContext = bikeStoresContext;
        }
        public List<Category> GetAllCategories()
        {
            var categories = _bikeStoresContext.Categories.ToList();
            if (!categories.Any())
            {
                return null;
            }
            return categories;
        }

        public Category GetCategoryByID(int id)
        {
            var category = _bikeStoresContext.Categories.Include(c => c.Products).FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return null;
            }
            return category;
        }
    }
}
