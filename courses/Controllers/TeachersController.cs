using courses.Database;
using courses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace courses.Controllers
{
    public class TeachersController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment webHostEnvironment;

        public TeachersController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult GetIndexView()
        {
            return View("Index", _context.teachers.ToList());
        }
        public IActionResult GetCreateView()
        {
            return View("CreateTeacher");
        }
        [HttpPost]
        public IActionResult AddTeacher(Teacher stud)
        {
           
            _context.teachers.Add(stud);
            _context.SaveChanges();
            return RedirectToAction("GetIndexView");
        }

        [HttpGet]
        public IActionResult GetDetailsView(int id)
        {
            Teacher Teacher = _context.teachers.FirstOrDefault(x => x.Id == id);
            ViewBag.TeacherDetails = Teacher;

            if (Teacher != null)
            {
                return View("Details", Teacher);
            }
            else
                return NotFound();
        }
        [HttpGet]
        public IActionResult GetEditView(int id)
        {
            Teacher Teacher = _context.teachers.FirstOrDefault(y => y.Id == id);
            if (Teacher != null)
            {
                return View("Edit", Teacher);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Teacher stud)
        {
           

            _context.teachers.Update(stud);
            _context.SaveChanges();

            return RedirectToAction("GetIndexView");
        }
        [HttpGet]
        public IActionResult GetDeleteView(int id)
        {
            Teacher teacher = _context.teachers.Include(d => d.Course).FirstOrDefault(d => d.Id == id);
            if (teacher != null)
            {
                return View("Delete", teacher);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Teacher teacher = _context.teachers.Find(id);

            _context.Remove(teacher);
            _context.SaveChanges();

            return RedirectToAction("GetIndexView");
        }
    }

}

