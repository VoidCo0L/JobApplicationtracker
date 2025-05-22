namespace JobApplicationTracker.Models
{
    public class Application
    {
        public Guid Id { get; set; } // Unique identifier
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime DateApplied { get; set; }
        public string Status { get; set; }
        public string Feedback { get; set; }
    }
}
