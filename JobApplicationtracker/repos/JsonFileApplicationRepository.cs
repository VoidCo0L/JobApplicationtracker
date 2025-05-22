using JobApplicationTracker.Models;
using Newtonsoft.Json;

namespace JobApplicationTracker.Repositories
{
    public class JsonFileApplicationRepository : IApplicationRepository
    {
        private readonly string _filePath = "applications.json";
        private List<Application> _applications;

        public JsonFileApplicationRepository()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _applications = JsonConvert.DeserializeObject<List<Application>>(json) ?? new List<Application>();
            }
            else
            {
                _applications = new List<Application>();
            }
        }

        public List<Application> GetAll() => _applications;

        public void Add(Application application)
        {
            _applications.Add(application);
        }

        public void Update(Application application)
        {
            var index = _applications.FindIndex(a => a.Id == application.Id);
            if (index != -1)
                _applications[index] = application;
        }

        public void Delete(Guid id)
        {
            _applications.RemoveAll(a => a.Id == id);
        }

        public void SaveChanges()
        {
            var json = JsonConvert.SerializeObject(_applications, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
