using Day2Lab.Models;
using Day2Lab.Repository;
using Day2Lab.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Day2Lab.Controllers
{
    public class TraineeController : Controller
    {
        //Context context = new Context();
        ITraineeRepository traineeRepository;
        ICourseRepository courseRepository;
        ICrsResultRepository crsResultRepository;

        public TraineeController(ITraineeRepository traineeRepo , ICourseRepository courseRepo , ICrsResultRepository crsResultRepo)
        {
            traineeRepository = traineeRepo;
            courseRepository = courseRepo;
            crsResultRepository = crsResultRepo;
        }
        public IActionResult Index()
        {
            //List<Trainee> trainees = context.Trainees.ToList();
            List<Trainee> trainees = traineeRepository.GetAll();
            return View("Index" , trainees);
        }


        public IActionResult GetResult(int tid , int cid)
        {
            TraineeWithCourseAndResultViewModel TraineeVM = new();
            //Trainee? trainee = context.Trainees.FirstOrDefault(t => t.Id == tid);
            Trainee? trainee = traineeRepository.GetById(tid);
            //Course? course = context.Courses.FirstOrDefault(c => c.Id == cid);
            Course? course = courseRepository.GetById(cid);
            //CrsResult? result = context.CrsResults.FirstOrDefault(r => r.Trainee_Id == tid && r.Crs_Id == cid);
            CrsResult? result = crsResultRepository.GetByTraineeIdAndCourseId(tid, cid);

            TraineeVM.TraineeName = trainee?.Name;
            TraineeVM.CourseName = course?.Name;
            TraineeVM.Degree = result?.Degree ?? 0;

            if (result == null)
            {
                return NotFound("Result not found for the specified trainee and course.");
            }
            return View("GetResult", TraineeVM);

        }










    }
}
