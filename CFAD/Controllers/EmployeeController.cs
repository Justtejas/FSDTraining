using CFAD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CFAD.Controllers
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
            var employees=_context.Employees.Include(e => e.Department).ToList();
            return View(employees);
        }
        public IActionResult Details(int id)
        {
            var employees= _context.Employees.Include(e => e.Department).FirstOrDefault(x => x.EmployeeID ==id);
            return View(employees);
        }
        public IActionResult Edit(int id)
        {
            var employees = _context.Employees.Include(e => e.Department).FirstOrDefault(x => x.EmployeeID == id);
            if(employees == null)
            {
                return NotFound();
            }
            ViewBag.DepartmentList = new SelectList(_context.Departments, "DepartmentID", "Name");
            return View(employees);
        }
        [HttpPost]
        public IActionResult Edit(Employee employees)
        {
            if (employees != null)
            {
                _context.Entry(employees).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(_context.Departments, "DepartmentID", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employees)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employees);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(_context.Departments, "DepartmentID", "Name", employees.DepartmentID);
            return View(employees);
        }
        public IActionResult Delete(int id)
        {
            var employees = _context.Employees.Include(e => e.Department).FirstOrDefault(x => x.EmployeeID == id);
            return View(employees);
        }
        [HttpPost("employees/delete/{id}")]
        public IActionResult DeleteConfirmed(int  id)
        {
            Employee? employees = _context.Employees.FirstOrDefault(x => x.EmployeeID == id);
            if (employees != null)
            {
                _context.Employees.Remove(employees);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }          

            return View();
        }
    }
}
