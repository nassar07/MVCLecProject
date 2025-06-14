using Day2Lab.Models;

namespace Day2Lab.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        Context context;
        public DepartmentRepository(Context _context)
        {
            context = _context;
        }
        public void Add(Department entity)
        {
            context.Departments.Add(entity);
        }

        public void Delete(int id)
        {
            Department departmentFromDb = GetById(id);
            context.Departments.Remove(departmentFromDb);
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department entity)
        {
            Department departmentFromDb = GetById(entity.Id);
            departmentFromDb.Name = entity.Name;
            departmentFromDb.Manager = entity.Manager;
        }
    }
}
