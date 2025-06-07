using Day2Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day2Lab.Controllers
{
    public class CourseController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            List<Course> courses = context.Courses.ToList();
            return View("Index" , courses);
        }


        public IActionResult New()
        {
            ViewBag.Depts = context.Departments.ToList();
            return View("New");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Course NewCourse)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    context.Courses.Add(NewCourse);
                    context.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("Name", ex.InnerException.Message);
                }
            }
                ViewBag.Depts = context.Departments.ToList();
                return View("New", NewCourse);

        }




        public IActionResult LessThanDegree(int MinDegree , int Degree)
        {
            if (MinDegree < Degree)
            {
                return Json(true);
            }
            else
            {
                return Json("Min Degree must be less than Degree");
            }
        }


        public IActionResult CanDivby3(int Crs_Houres)
        {
            if (Crs_Houres % 3 == 0)
            {
                return Json(true);
            }
            else
            {
                return Json("Crs Houres must be divisible by 3");
            }
        }


        public IActionResult Not0dep(int DeptId)
        {
            if (DeptId != 0)
            {
                return Json(true);
            }
            else
            {
                return Json("Please Select a Department");
            }

        }


        }
}
