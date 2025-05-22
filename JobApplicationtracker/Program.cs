using JobApplicationTracker.Repositories;
using JobApplicationTracker.Services;

var repository = new JsonFileApplicationRepository();
var service = new ApplicationService(repository);

while (true)
{
    Console.WriteLine("\n=== Job Application Tracker ===");
    Console.WriteLine("1. Add Application");
    Console.WriteLine("2. View Applications");
    Console.WriteLine("3. Delete Application");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Company Name: ");
            var company = Console.ReadLine();
            Console.Write("Position: ");
            var position = Console.ReadLine();
            Console.Write("Status: ");
            var status = Console.ReadLine();
            Console.Write("Feedback: ");
            var feedback = Console.ReadLine();

            service.AddApplication(company, position, status, feedback);
            Console.WriteLine("Application added!");
            break;

        case "2":
            var apps = service.GetApplications();
            if (apps.Count == 0)
            {
                Console.WriteLine("No applications found.");
            }
            else
            {
                foreach (var app in apps)
                {
                    Console.WriteLine($"\nID: {app.Id}\nCompany: {app.CompanyName}\nPosition: {app.Position}\nDate Applied: {app.DateApplied}\nStatus: {app.Status}\nFeedback: {app.Feedback}\n");
                }
            }
            break;

        case "3":
            Console.Write("Enter Application ID to delete: ");
            var idInput = Console.ReadLine();
            if (Guid.TryParse(idInput, out var id))
            {
                service.DeleteApplication(id);
                Console.WriteLine("Application deleted.");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            break;

        case "4":
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}
