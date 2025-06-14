using System.ComponentModel.DataAnnotations;

namespace Day2Lab.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var context = (Context)validationContext.GetService(typeof(Context));

            if (context == null)
            {
                throw new InvalidOperationException("Database context is not available");
            }

            Course courseFromReq = (Course)validationContext.ObjectInstance;
            string name = value?.ToString();

            var courseFromDb = context.Courses.FirstOrDefault(
                c => c.Name == name && c.DeptId == courseFromReq.DeptId);

            if (courseFromDb == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("This Course already exists in this Department");
        }
    }

}
