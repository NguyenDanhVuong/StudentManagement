using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View(_context.Students.ToList());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Redirect("/Student/Index");
        }

        //Edit Student


        // Update Student
        [HttpPost]
        [Route("Student/Edit/{id}")]
        public IActionResult Update(long id, Student student)
        {
            var updateStudent = _context.Students.Find(id);
            updateStudent = student;
            _context.Students.Update(updateStudent);
            return Redirect("/Student/Index");
        }

        //Delete Student
        [HttpDelete("{id}")]
        [Route("Student/Delete/{id}")]
        public IActionResult Delete(long id)
        {
            var deleteStudent = _context.Students.Find(id);
            _context.Students.Remove(deleteStudent);
            _context.SaveChanges();
            return Redirect("/Student/Index");
        }
    }
}
