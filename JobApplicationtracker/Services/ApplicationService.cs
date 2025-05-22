using JobApplicationTracker.Models;
using JobApplicationTracker.Repositories;

namespace JobApplicationTracker.Services
{
    public class ApplicationService
    {
        private readonly IApplicationRepository _repository;

        public ApplicationService(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public void AddApplication(string companyName, string position, string status, string feedback)
        {
            var application = new Application
            {
                Id = Guid.NewGuid(),
                CompanyName = companyName,
                Position = position,
                DateApplied = DateTime.Now,
                Status = status,
                Feedback = feedback
            };

            _repository.Add(application);
            _repository.SaveChanges();
        }

        public List<Application> GetApplications() => _repository.GetAll();

        public void DeleteApplication(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
    }
}
