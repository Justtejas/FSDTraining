using CodeFirstApproachDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproachDemo.Controllers
{
    public class DepartmentController:Controller
    {
        private readonly MyContext _context;
        public DepartmentController(MyContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }
        public IActionResult Details(int id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.DepartmentID == id);
            return View(department);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Departments.Add(department);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(department);
        }
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.FirstOrDefault(x =>x.DepartmentID == id);
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
            return View(department);
        }
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.DepartmentID == id);
            return View(department);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteDepartmentConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var department = _context.Departments.FirstOrDefault(d => d.DepartmentID == id);
                if(department != null)
                {
                    _context.Departments.Remove(department);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
