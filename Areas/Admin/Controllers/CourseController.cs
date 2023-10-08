using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace OnlineCourses.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public CourseController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            List<Courses> coursesList = _databaseContext.Courses.ToList();
            return View(coursesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Courses course) { 
            if(ModelState.IsValid)
            {
                _databaseContext.Courses.Add(course);
                _databaseContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else { return View(); }
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Courses? courseFromDB = _databaseContext.Courses.FirstOrDefault(c => c.Id == id);
            if(courseFromDB == null)
            {
                return NotFound();
            }
            return View(courseFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Courses course)
        {
            if (ModelState.IsValid)
            {
                _databaseContext.Courses.Update(course);
                _databaseContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Courses? courseFromDB = _databaseContext.Courses.FirstOrDefault(c => c.Id == id);
            if (courseFromDB == null)
            {
                return NotFound();
            }
            return View(courseFromDB);
        }

        [HttpPost]
        public IActionResult Delete(Courses course)
        {
            _databaseContext.Courses.Remove(course);
            _databaseContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
