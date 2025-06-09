using Day2Lab.Models;
using Day2Lab.Repository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Day2Lab.Controllers
{
    public class CourseController : Controller
    {
        //Context context = new Context();
        ICourseRepository CourseRepository;
        IDepartmentRepository DepartmentRepository;

        public CourseController(ICourseRepository courseRepo , IDepartmentRepository deptRepo)
        {
            CourseRepository = courseRepo;
            DepartmentRepository = deptRepo;
        }






        public IActionResult Index()
        {
            List<Course> courses = CourseRepository.GetAll();
            return View("Index" , courses);
        }


        public IActionResult New()
        {
            ViewBag.Depts = DepartmentRepository.GetAll();
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
                    //context.Courses.Add(NewCourse);
                    CourseRepository.Add(NewCourse);

                    //context.SaveChanges();
                    CourseRepository.Save();
                    return RedirectToAction("Index");

                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("Name", ex.InnerException.Message);
                }
            }
                //ViewBag.Depts = context.Departments.ToList();
                ViewBag.Depts = DepartmentRepository.GetAll();
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
