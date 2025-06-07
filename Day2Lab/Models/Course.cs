using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Day2Lab.Models
{
    public class Course
    {
        public int Id { get; set; }


        [Required]
        [MaxLength(20 , ErrorMessage ="Name Must Be Less Than 20 Char ")]
        [MinLength(2 , ErrorMessage ="Name Must Be More Than 2 Char")]
        [Unique]
        public string Name { get; set; }

        [Range(50,100)]
        public int Degree { get; set; }

        [Remote("LessThanDegree", "Course" ,AdditionalFields ="Degree")]
        public int MinDegree { get; set; }

        [Remote("CanDivby3" , "Course")]
        public int Crs_Houres { get; set; }

        [Remote("Not0dep" , "Course")]
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department? Department { get; set; }

        public List<Instructor>? Instructores { get; set; }

        public List<CrsResult>? CrsResults { get; set; }
    }
}
