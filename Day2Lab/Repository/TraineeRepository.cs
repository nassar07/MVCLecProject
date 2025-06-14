using Day2Lab.Models;

namespace Day2Lab.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        Context context;
        public TraineeRepository(Context _context)
        {
            context = _context;
        }
        public void Add(Trainee entity)
        {
            context.Trainees.Add(entity);
        }

        public void Delete(int id)
        {
            Trainee TraineeFromDb = GetById(id);
            context.Trainees.Remove(TraineeFromDb);
        }

        public List<Trainee> GetAll()
        {
            return context.Trainees.ToList();
        }

        public Trainee GetById(int id)
        {
            return context.Trainees.FirstOrDefault(t => t.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Trainee entity)
        {
            Trainee TraineeFromDb = GetById(entity.Id);

            TraineeFromDb.Name = entity.Name;
            TraineeFromDb.Address = entity.Address;
            TraineeFromDb.Image = entity.Image;
            TraineeFromDb.DeptId = entity.DeptId;
        }
    }
}
