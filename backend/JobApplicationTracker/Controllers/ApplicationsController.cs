using JobApplicationTracker.Contracts;
using JobApplicationTracker.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class ApplicationsController(ApplicationRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<ApplicationDto>> Get()
    {
        var result = await repository.GetAllAsync();
        
        return result.Select(x => new ApplicationDto(x.Id,
            x.Company,
            x.Position,
            x.Status,
            x.DateApplied
        ));
    }
}