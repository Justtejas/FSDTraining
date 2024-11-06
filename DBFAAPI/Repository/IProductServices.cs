using DBFAAPI.Models;

namespace DBFAAPI.Repository
{
    public interface IProductServices
    {
        public Task<List<Product>> GetAllProducts();
        public List<Product> GetProductFromCategory(int id);
        public Product GetProductByID(int id);
        public List<Product> GetProductByName(string productName);
    }
}
