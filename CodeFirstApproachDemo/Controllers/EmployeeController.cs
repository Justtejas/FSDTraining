using CodeFirstApproachDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproachDemo.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly MyContext _context;
        public EmployeeController(MyContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
        public IActionResult Details(int id)
        {
            var employees = _context.Employees.FirstOrDefault(x => x.EmployeeID == id);
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var employees = _context.Employees.FirstOrDefault(x =>x.EmployeeID == id);
            return View(employees);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (employee != null)
            {
                _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(d => d.EmployeeID == id);
            return View(employee);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteEmployeeConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var employee = _context.Employees.FirstOrDefault(d => d.EmployeeID == id);
                if(employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
