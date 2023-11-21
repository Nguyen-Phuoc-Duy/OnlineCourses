using Microsoft.AspNetCore.Mvc;
using Models;

namespace OnlineCourses.Areas.User.Controllers
{
    [Area("User")]
    public class AuthController : Controller
    {
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Users user)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }
    }
}
