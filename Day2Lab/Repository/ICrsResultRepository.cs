using Day2Lab.Models;

namespace Day2Lab.Repository
{
    public interface ICrsResultRepository : IRepository<CrsResult>
    {
        public CrsResult? GetByTraineeIdAndCourseId(int traineeId, int courseId);
    }
}
