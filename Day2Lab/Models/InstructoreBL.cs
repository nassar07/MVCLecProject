namespace Day2Lab.Models
{
    public class InstructoreBL
    {
        public Instructor GetByID(int id)
        {
            Context context = new Context();
            return context.Instructores.FirstOrDefault(i=>i.Id==id);
        }
    }
}
