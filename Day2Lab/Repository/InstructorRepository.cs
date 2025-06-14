using Day2Lab.Models;

namespace Day2Lab.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        Context context;
        public InstructorRepository(Context _context)
        {
            context = _context;
        }
        public void Add(Instructor entity)
        {
            context.Instructores.Add(entity);
        }

        public void Delete(int id)
        {
            Instructor instructorFromDb = GetById(id);
            context.Instructores.Remove(instructorFromDb);
        }

        public List<Instructor> GetAll()
        {
            return context.Instructores.ToList();
        }

        public Instructor GetById(int id)
        {
            return context.Instructores.FirstOrDefault(i => i.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Instructor entity)
        {
            Instructor instructorFromDb = GetById(entity.Id);
            instructorFromDb.Name = entity.Name;
            instructorFromDb.Address = entity.Address;
            instructorFromDb.Image = entity.Image;
            instructorFromDb.Salary = entity.Salary;
            instructorFromDb.DeptId = entity.DeptId;
            instructorFromDb.CourseId = entity.CourseId;
        }
    }
}
