using DBFAAPI.Models;

namespace DBFAAPI.Repository
{
    public interface ICategoryServices
    {
        public List<Category> GetAllCategories();
        public Category GetCategoryByID(int id);
    }
}
