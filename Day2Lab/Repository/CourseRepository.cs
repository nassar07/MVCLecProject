using Day2Lab.Models;

namespace Day2Lab.Repository
{
    public class CourseRepository : ICourseRepository
    {
        Context context;
        public CourseRepository(Context _context)
        {
            context = _context ;
        }

        public void Add(Course entity)
        {
            context.Courses.Add(entity);
        }

        public void Delete(int id)
        {
            Course CourseFromDb = GetById(id);
            context.Courses.Remove(CourseFromDb);
        }

        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.FirstOrDefault(c => c.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Course entity)
        {
            Course CourseFromDb = GetById(entity.Id);
            
            CourseFromDb.Name = entity.Name;
            CourseFromDb.Degree = entity.Degree;
            CourseFromDb.MinDegree = entity.MinDegree;
            CourseFromDb.Crs_Houres = entity.Crs_Houres;
            CourseFromDb.DeptId = entity.DeptId; 
        }
    }
}
