using Day2Lab.Migrations;
using Day2Lab.Models;
using Day2Lab.Repository;
using Day2Lab.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;

namespace Day2Lab.Controllers
{
    public class InstructorController : Controller
    {
        //Context context = new Context();

        IInstructorRepository instructorRepository;
        IDepartmentRepository DepartmentRepository;
        ICourseRepository courseRepository;

        InstructoreBL instructoreBL = new InstructoreBL();

        public InstructorController(IInstructorRepository insRepo , IDepartmentRepository deptRepo , ICourseRepository courseRepo)
        {
            instructorRepository = insRepo;
            DepartmentRepository = deptRepo;
            courseRepository = courseRepo;
        }

        public IActionResult Index()
        {
            //List<Instructor> instructores = context.Instructores.ToList();
            List<Instructor> instructores = instructorRepository.GetAll();
            return View("Index" , instructores);
        }


        public IActionResult Details(int id)
        {
            //Instructor instructor = instructoreBL.GetByID(id);
            Instructor instructor = instructorRepository.GetById(id);

            return View("Details", instructor);

        }



        
        public IActionResult New()
        {
            //Instructor NewIns = context.Instructores.FirstOrDefault();
            InstructorWithDepListAndCourseListViewModel instructorVM = new();
            //List<Department> departments = context.Departments.ToList();
            List<Department> departments = DepartmentRepository.GetAll();
            //List<Course> courses = context.Courses.ToList();
            List<Course> courses = courseRepository.GetAll();
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
            //instructorVM.departmentsList = context.Departments.ToList();
            instructorVM.departmentsList = DepartmentRepository.GetAll();
            //instructorVM.CoursesList = context.Courses.ToList();
            instructorVM.CoursesList = courseRepository.GetAll();

            if (NewIns.Name != null && NewIns.Address != null)
            {
                //context.Instructores.Add(NewIns);
                instructorRepository.Add(NewIns);
                //context.SaveChanges();
                instructorRepository.Save();

                return RedirectToAction("Index", "Instructor");
            }
            
            
            return View("New", instructorVM);
           



            
        }



















    }
}
