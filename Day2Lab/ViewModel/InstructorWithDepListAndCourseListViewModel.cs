using Day2Lab.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2Lab.ViewModel
{
    public class InstructorWithDepListAndCourseListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }

        public int DeptId { get; set; }
        public List<Department> departmentsList { get; set; }
        public int CourseId { get; set; }
        public List<Course> CoursesList { get; set; }
    }
}
