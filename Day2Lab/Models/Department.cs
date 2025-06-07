namespace Day2Lab.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }

        public List<Course> courses { get; set; }

        public List<Trainee> trainees { get; set; }

        public List<Instructor> instructores { get; set; }
    }
}
