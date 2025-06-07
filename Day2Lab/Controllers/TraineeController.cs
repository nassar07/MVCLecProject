using Day2Lab.Models;
using Day2Lab.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Day2Lab.Controllers
{
    public class TraineeController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            List<Trainee> trainees = context.Trainees.ToList();
            return View("Index" , trainees);
        }


        public IActionResult GetResult(int tid , int cid)
        {
            TraineeWithCourseAndResultViewModel TraineeVM = new();
            Trainee? trainee = context.Trainees.FirstOrDefault(t => t.Id == tid);
            Course? course = context.Courses.FirstOrDefault(c => c.Id == cid);
            CrsResult? result = context.CrsResults.FirstOrDefault(r => r.Trainee_Id == tid && r.Crs_Id == cid);

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
