using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class AccountController : Controller
    {
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            string username = form["username"];
            string password = form["password"];
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult SignUp()
        {
            UserViewModel _UserViewModel = new UserViewModel();
            return View(_UserViewModel);
        }
        [HttpGet]
        public JsonResult ChangeCityByCountry(int countryId)
        {
            UserViewModel user = new UserViewModel();
            return Json(user.getCitybyCountryId(Convert.ToInt32(countryId)));
        }
        [HttpPost]
        public IActionResult SignUp(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
