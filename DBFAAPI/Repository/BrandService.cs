using DBFAAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DBFAAPI.Repository
{
    public class BrandService : IBrandServices
    {
        private readonly BikeStoresContext _bikeStoresContext;
        public BrandService(BikeStoresContext bikeStoresContext)
        {
            _bikeStoresContext = bikeStoresContext;
        }

        public List<Brand> GetAllBrands()
        {
            var brands = _bikeStoresContext.Brands.Include(b => b.Products).ToList();
            if (!brands.Any())
            {
                return null;
            }
            return brands;
        }

        public Brand GetBrandByID(int id)
        {
            var brand = _bikeStoresContext.Brands.Include(b => b.Products).FirstOrDefault(b => b.BrandId == id);
            if (brand == null)
            {
                return null;
            }
            return brand;
        }
    }
}
