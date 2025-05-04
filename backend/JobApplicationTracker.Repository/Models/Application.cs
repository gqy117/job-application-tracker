namespace JobApplicationTracker.Repository.Models;

public class Application
{
    public int Id { get; set; }
    public string Position { get; set; } = default!;
    public string Company { get; set; } = default!;
    public string Status { get; set; } = "New";
    public DateTimeOffset DateApplied;
}