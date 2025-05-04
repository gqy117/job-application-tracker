namespace JobApplicationTracker.Contracts;

public record ApplicationDto(int Id, string CompanyName, string Position, string Status, DateTimeOffset DateApplied);