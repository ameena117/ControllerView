using ControllerView.Data;
using ControllerView.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ControllerViewTask.Controllers
{
    public class StudentsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var allStudents = context.Students.ToList();
            return View(allStudents);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student newStudent)
        {
            context.Students.Add(newStudent);
            context.SaveChanges();
            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]

        public IActionResult View(int id)
        {
            var viewStudent = context.Students.Find(id);
            return View(viewStudent);
        }
        public IActionResult Update(int id)
        {
            var originStudent = context.Students.Find(id);
            return View(originStudent);
        }
        [HttpPost]
        public IActionResult Update(Student currentStudent)
        {
            var originStudent = context.Students.Find(currentStudent.Id);
            if (originStudent != null)
            {
                originStudent.FirstName = currentStudent.FirstName;
                originStudent.LastName = currentStudent.LastName;
                context.SaveChanges();
                return RedirectToAction(nameof(GetAll));
            }
            return Ok("notfound");

        }
        public IActionResult Delete(int id)
        {
            var DeleteStudent = context.Students.Find(id);
            if (DeleteStudent != null)
                context.Students.Remove(DeleteStudent);
            context.SaveChanges();
            return RedirectToAction(nameof(GetAll));
            return NotFound();
        }


    }
}
