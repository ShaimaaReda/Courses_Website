using courses.Database;
using courses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace courses.Controllers
{
    public class StudentsController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment webHostEnvironment;

        public StudentsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult GetIndexView()
        {
            return View("Index", _context.Students.ToList());
        }
        public IActionResult GetCreateView() 
        {
            return View("CreateStudent");
        }
        [HttpPost]
        public IActionResult AddStudent(Student stud, IFormFile? imageFormFile)
        {
            if (imageFormFile != null)
            {
                string imgExtention = Path.GetExtension(imageFormFile.FileName);
                Guid imgGuid = Guid.NewGuid();
                string imageName = imgGuid + imgExtention;
                string imagePath = "\\Image\\" + imageName;
                stud.ImagePath = imagePath;
                string imgFullPath = webHostEnvironment.WebRootPath + imagePath;
                FileStream imgFileStream = new FileStream(imgFullPath, FileMode.Create);
                imageFormFile.CopyTo(imgFileStream);
                imgFileStream.Dispose();
            }
            else
            {
                stud.ImagePath = "\\Image\\No_Image.png";
            }
            _context.Students.Add(stud);
            _context.SaveChanges();
            return RedirectToAction("GetIndexView");
        }

        [HttpGet]
        public IActionResult GetDetailsView(int id) 
        {
            Student student = _context.Students.FirstOrDefault(x => x.Id == id);
            ViewBag.StudentDetails = student;

            if (student != null)
            {
                return View("Details", student);
            }
            else
                return NotFound();
        }
        [HttpGet]
        public IActionResult GetEditView(int id) 
        {
            Student student= _context.Students.FirstOrDefault(y => y.Id == id);
            if (student != null)
            {
                return View("Edit", student);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Student stud, IFormFile? imageFormFile)
        {
            if (stud.ImagePath != "\\Image\\No_Image.png")
            {
                string oldImagePath = webHostEnvironment.WebRootPath + stud.ImagePath;
                System.IO.File.Delete(oldImagePath);

            }
          
                string imgExtention = Path.GetExtension(imageFormFile.FileName);
                Guid imgGuid = Guid.NewGuid();
                string imageName = imgGuid + imgExtention;
                string imagePath = "\\Image\\" + imageName;
                stud.ImagePath = imagePath;
                string imgFullPath = webHostEnvironment.WebRootPath + imagePath;
                FileStream imgFileStream = new FileStream(imgFullPath, FileMode.Create);
                imageFormFile.CopyTo(imgFileStream);
                imgFileStream.Dispose();
        
            _context.Students.  Update(stud);
            _context.SaveChanges();

            return RedirectToAction("GetIndexView");   
        }
        [HttpGet]
        public IActionResult GetDeleteView(int id) 
        {
            Student student=_context.Students.FirstOrDefault(d=>d.Id == id);
            if(student != null)
            {
                return View("Delete",student);
            }
            else
                    return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            Student student = _context.Students.Find(id);

            if (student != null && student.ImagePath != "\\images\\No_Image.png")
            {
                string imgFullPath = webHostEnvironment.WebRootPath + student.ImagePath;
                System.IO.File.Delete(imgFullPath);
            }

            return RedirectToAction("GetIndexView");
        }
    }

}
