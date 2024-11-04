using CFAD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CFAD.Controllers
{
    public class DepartmentController : Controller
    { 
        private readonly MyContext _context;
        public DepartmentController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var departments=_context.Departments.ToList();
            return View(departments);
        }
        public IActionResult Details(int id)
        {
            var department= _context.Departments.FirstOrDefault(x => x.DepartmentID==id);   
            return View(department);
        }
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.DepartmentID == id);
            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (department != null)
            {
                _context.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.DepartmentID == id);
            return View(department);
        }
        [HttpPost("department/delete/{id}")]
        public IActionResult DeleteConfirmed(int  id)
        {
           var department= _context.Departments.FirstOrDefault(x => x.DepartmentID == id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }          

            return View();
        }
    }
}
