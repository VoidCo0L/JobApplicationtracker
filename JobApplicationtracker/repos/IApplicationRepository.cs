using JobApplicationTracker.Models;

namespace JobApplicationTracker.Repositories
{
    public interface IApplicationRepository
    {
        List<Application> GetAll();
        void Add(Application application);
        void Update(Application application);
        void Delete(Guid id);
        void SaveChanges();
    }
}
