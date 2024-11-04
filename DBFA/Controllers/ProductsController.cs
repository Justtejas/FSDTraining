using DBFA.Models;
using Microsoft.AspNetCore.Mvc;
namespace DBFA.Controllers
{
    public class ProductsController:Controller
    {
        private readonly BikeStoresContext _bikeStoresContext;
        public ProductsController(BikeStoresContext bikeStoresContext)
        {
            _bikeStoresContext = bikeStoresContext;
        }
        public IActionResult Index(string searchTerm)
        {
            var products = _bikeStoresContext.Products.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p =>
                    p.ProductName.Contains(searchTerm));
            }
            ViewData["SearchTerm"] = searchTerm;
            return View(products.ToList());
        }
    }
}
