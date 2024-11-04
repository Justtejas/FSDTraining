using DBFA.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBFA.Controllers
{
    public class CategoriesController: Controller
    {
        private readonly BikeStoresContext _bikeStoresContext;
        public CategoriesController(BikeStoresContext bikeStoresContext)
        {
            _bikeStoresContext = bikeStoresContext;
        }
        public IActionResult Index()
        {
            var categories = _bikeStoresContext.Categories.ToList();
            return View(categories);
        }
        public IActionResult Details(int id)
        {
            var categories = _bikeStoresContext.Categories.FirstOrDefault(c => c.CategoryId == id);
            if(categories == null)
                return NotFound();
            else
            return View(categories);
        }
    }
}
