using JobApplicationTracker.Repository;
using JobApplicationTracker.Repository.Models;
using MediatR;

namespace JobApplicationTracker.Handlers;
public record CreateApplicationCommand(string Company, string Position) : IRequest;

public class CreateApplicationHandler(ApplicationRepository repository) : IRequestHandler<CreateApplicationCommand>
{
    public async Task Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
    {
        await repository.AddAsync(new Application
        {
            Company = command.Company,
            DateApplied = DateTime.Now,
            Position = command.Position,
            Status = "",
        });
    }
}