using DBFAAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DBFAAPI.Repository
{
    public class ProductService : IProductServices
    {
        private readonly BikeStoresContext _bikeStoresContext;
        public ProductService(BikeStoresContext bikeStoresContext)
        {
            _bikeStoresContext = bikeStoresContext;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _bikeStoresContext.Products.Include(p => p.Brand).Include(p => p.Category).Take(5).ToListAsync();
            if (products.Count == 0 || products == null)
            {
                return null;
            }
            return products;
        }

        public Product GetProductByID(int id)
        {
            var product = _bikeStoresContext.Products.Include(p => p.Brand).Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public List<Product> GetProductByName(string productName)
        {
            var products = _bikeStoresContext.Products.Include(p => p.Brand).Include(p => p.Category).Take(5).Where(p => p.ProductName.Contains(productName)).ToList();
            if (products.Count == 0 || products == null)
            {
                return null;
            }
            return products;
        }

        public List<Product> GetProductFromCategory(int id)
        {
            var products = _bikeStoresContext.Products.Include(p => p.Category).Where(p => p.CategoryId == id).ToList();
            if (products.Count == 0 || products == null)
            {
                return null;
            }
            return products;
        }
    }
}
