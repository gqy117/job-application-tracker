using JobApplicationTracker.Contracts;
using JobApplicationTracker.Repository;
using MediatR;

namespace JobApplicationTracker.Handlers;

public record GetAllApplicationsQuery : IRequest<List<ApplicationDto>>;

public class GetAllApplicationsHandler(ApplicationRepository repository) : IRequestHandler<GetAllApplicationsQuery, List<ApplicationDto>>
{
    public async Task<List<ApplicationDto>> Handle(GetAllApplicationsQuery query, CancellationToken cancellationToken)
    {
        var result = await repository.GetAllAsync();

        return result.Select(x => new ApplicationDto(x.Id,
            x.Company,
            x.Position,
            x.Status,
            x.DateApplied
        ))
        .ToList();
    }
}