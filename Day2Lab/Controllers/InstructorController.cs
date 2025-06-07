using Day2Lab.Migrations;
using Day2Lab.Models;
using Day2Lab.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;

namespace Day2Lab.Controllers
{
    public class InstructorController : Controller
    {
        Context context = new Context();

        InstructoreBL instructoreBL = new InstructoreBL();

        public InstructorController()
        {

        }

        public IActionResult Index()
        {
            List<Instructor> instructores = context.Instructores.ToList();
            return View("Index" , instructores);
        }


        public IActionResult Details(int id)
        {
            Instructor instructor = instructoreBL.GetByID(id);

            return View("Details", instructor);

        }



        
        public IActionResult New()
        {
            //Instructor NewIns = context.Instructores.FirstOrDefault();
            InstructorWithDepListAndCourseListViewModel instructorVM = new();
            List<Department> departments = context.Departments.ToList();
            List<Course> courses = context.Courses.ToList();
            instructorVM.departmentsList = departments;
            instructorVM.CoursesList = courses;


            return View("New", instructorVM);

        }


        [HttpPost]
        public IActionResult SaveNew(InstructorWithDepListAndCourseListViewModel instructorVM)
        {
            Instructor NewIns = new Instructor();
            NewIns.Id = instructorVM.Id ;
            NewIns.Name = instructorVM.Name;
            NewIns.Image = instructorVM.Image;
            NewIns.Salary = instructorVM.Salary;
            NewIns.Address = instructorVM.Address;
            NewIns.DeptId = instructorVM.DeptId;
            NewIns.CourseId = instructorVM.CourseId;
            instructorVM.departmentsList = context.Departments.ToList();
            instructorVM.CoursesList = context.Courses.ToList();

            if (NewIns.Name != null && NewIns.Address != null)
            {
                context.Instructores.Add(NewIns);
                context.SaveChanges();

                return RedirectToAction("Index", "Instructor");
            }
            
            
            return View("New", instructorVM);
           



            
        }



















    }
}
