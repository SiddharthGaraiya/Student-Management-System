using Microsoft.AspNetCore.Mvc;
using Student_Management.Data;
using Student_Management.Models;

namespace Student_Management.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> students =_context.Students.ToList(); 
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create([Bind("Name , Email, Course, EnrollmentDate")]Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return View(student);
            }
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, Name , Email, Course, EnrollmentDate")] Student student) {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

    }
}
