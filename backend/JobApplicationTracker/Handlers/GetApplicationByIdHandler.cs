using JobApplicationTracker.Contracts;
using JobApplicationTracker.Repository;
using MediatR;

namespace JobApplicationTracker.Handlers;

public class GetApplicationByIdHandler(ApplicationRepository repository)
    : IRequestHandler<GetApplicationByIdQuery, ApplicationDto>
{
    public async Task<ApplicationDto> Handle(GetApplicationByIdQuery query, CancellationToken cancellationToken)
    {
        var app = await repository.GetByIdAsync(query.Id);
        if (app is null)
            return null;

        return new ApplicationDto(app.Id,
            app.Company,
            app.Position,
            app.Status,
            app.DateApplied
        );
    }
}

public record GetApplicationByIdQuery(int Id) : IRequest<ApplicationDto>;