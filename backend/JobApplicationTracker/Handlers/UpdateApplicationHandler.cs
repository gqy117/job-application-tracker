using JobApplicationTracker.Repository;
using MediatR;

namespace JobApplicationTracker.Handlers;

public record UpdateApplicationCommand(int Id, string Status) : IRequest;

public class UpdateApplicationHandler(ApplicationRepository repository) : IRequestHandler<UpdateApplicationCommand>
{
    public async Task Handle(UpdateApplicationCommand command, CancellationToken cancellationToken)
    {
        var app = await repository.GetByIdAsync(command.Id);
        app!.Status = command.Status;

        await repository.UpdateAsync(app);
    }
}