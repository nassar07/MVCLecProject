namespace Day2Lab.Models
{
    public class InstructoreBL
    {
        Context context;

        public InstructoreBL()
        {
        }

        public InstructoreBL(Context _context)
        {
            context = _context;
        }
        public Instructor GetByID(int id)
        {
            return context.Instructores.FirstOrDefault(i=>i.Id==id);
        }
    }
}
