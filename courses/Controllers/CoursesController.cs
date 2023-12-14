using courses.Database;
using courses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace courses.Controllers
{
    public class CoursesController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment webHostEnvironment;

        public CoursesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }



        public IActionResult GetIndexView()
        {
            return View("Index", _context.courses.ToList());
        }
        public IActionResult GetCreateView()
        {
            return View("CreateCourse");
        }
        [HttpPost]
        public IActionResult AddCourse(Course curs, IFormFile? imageFormFile)
        {
           

            _context.courses.Add(curs);
            _context.SaveChanges();
            return RedirectToAction("GetIndexView");
        }

        [HttpGet]
        public IActionResult GetDetailsView(int id)
        {
            Course course = _context.courses.FirstOrDefault(x => x.Id == id);
            ViewBag.CourseDetails = course;

            if (course != null)
            {
                return View("Details", course);
            }
            else
                return NotFound();
        }


        [HttpGet]
        public IActionResult GetEditView(int id)
        {
            Course cors = _context.courses.FirstOrDefault(y => y.Id == id);
            if (cors != null)
            {
                return View("Edit", cors);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Course curs, IFormFile? imageFormFile)
        {

            _context.courses.Update(curs);
            _context.SaveChanges();

            return RedirectToAction("GetIndexView");
        }
 
        [HttpGet]
        public IActionResult GetDeleteView(int id)
        {
            Course course = _context.courses.Include(d => d.Teacher).FirstOrDefault(d => d.Id == id);
            if (course != null)
            {
                return View("Delete", course);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Course course = _context.courses.Find(id);

            _context.courses.Remove(course);
            _context.SaveChanges();

            return RedirectToAction("GetIndexView");
        }
    }

}
