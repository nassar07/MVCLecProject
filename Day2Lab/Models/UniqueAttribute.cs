using System.ComponentModel.DataAnnotations;

namespace Day2Lab.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Course CourseFromReq = (Course)validationContext.ObjectInstance;

            string name = value.ToString();

            Context context = new Context();

            Course CourseFromDb = context.Courses.FirstOrDefault(c => c.Name == name && c.DeptId == CourseFromReq.DeptId);

            if (CourseFromDb == null)
            {
                return ValidationResult.Success;
            }
            
            return new ValidationResult("This Course already exists in this Department");
        }
    }
}
