using Microsoft.AspNetCore.Mvc;
using WebAppDemo.Models;
namespace WebAppDemo.Controllers
{
    public class DepartmentsController : Controller
    {
        private static readonly List<Department> departments = new()
        {
            new() {DepartmentID = 1, Name = "IT", Location = "Chennai"},
            new() {DepartmentID = 2, Name = "Sales", Location = "Mumbai"},
            new() {DepartmentID = 3, Name = "HR", Location = "Sydney"},
            new() {DepartmentID = 4, Name = "Finance", Location = "Bangalore"},
            new() {DepartmentID = 5, Name = "Admin", Location = "Kolkata"},
        };
        private static readonly List<Department> _departmentLists = departments;
        public DepartmentsController() { }
        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to web app development using MVC";
            return View(_departmentLists);
        }
        public IActionResult Details(int id)
        {
            var department = _departmentLists.Where(d => d.DepartmentID == id).FirstOrDefault();
            ViewBag.msg1 = "This is the example for transferring data from Controller to View using ViewBag";
            if(department != null)
            {
                return View(department);
            }
            else
            {
                return View();
            }
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
                _departmentLists.Add(department);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var department = departments.FirstOrDefault(d => d.DepartmentID == id);
            if (department != null)
            {
                return View(department);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Department updatedDepartment)
        {
            if (ModelState.IsValid)
            {
                var department = _departmentLists.Where(d => d.DepartmentID == updatedDepartment.DepartmentID).FirstOrDefault();
                department.Name = updatedDepartment.Name;
                department.Location = updatedDepartment.Location;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var department = departments.FirstOrDefault(d => d.DepartmentID == id);
            if (department != null)
            {
                return View(department);
            }
            return View();
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var department = _departmentLists.Where(d => d.DepartmentID == id).FirstOrDefault();
                if(department != null)
                    _departmentLists.Remove(department);
            }
            return RedirectToAction("Index");
        }

    }
}
