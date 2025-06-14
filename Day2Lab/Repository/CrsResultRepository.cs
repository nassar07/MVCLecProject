using Day2Lab.Models;

namespace Day2Lab.Repository
{
    public class CrsResultRepository : ICrsResultRepository
    {
        Context context;

        public CrsResultRepository(Context _context)
        {
            context = _context;
        }
        public void Add(CrsResult entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CrsResult> GetAll()
        {
            return context.CrsResults.ToList();
        }

        public CrsResult GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CrsResult? GetByTraineeIdAndCourseId(int traineeId, int courseId)
        {
            return context.CrsResults.FirstOrDefault(r => r.Trainee_Id == traineeId && r.Crs_Id == courseId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(CrsResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
