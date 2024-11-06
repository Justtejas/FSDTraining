using DBFAAPI.Models;

namespace DBFAAPI.Repository
{
    public interface IBrandServices
    {
        public List<Brand> GetAllBrands();
        public Brand GetBrandByID(int id);
    }
}
