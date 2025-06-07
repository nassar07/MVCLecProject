using Microsoft.AspNetCore.Mvc;

namespace Day2Lab.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SetSession(string name ,int age)
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);
            return Content("Session Set Successfully");
        }

        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");
            return Content($"Name : {name} Age : {age}");
        }

        public IActionResult SetCookie(string name , int age)
        {
            HttpContext.Response.Cookies.Append("Name", name);
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(15);
            HttpContext.Response.Cookies.Append("Age", age.ToString(),options);
            return Content("Cookie Set Succuss");

        }

        public IActionResult GetCookie()
        {
            string name = HttpContext.Request.Cookies["Name"];
            string age = HttpContext.Request.Cookies["Age"];
            return Content($"Name : {name} Age : {age}");
        }






    }
}
