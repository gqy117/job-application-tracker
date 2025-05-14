using JobApplicationTracker.Contracts;
using JobApplicationTracker.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTracker.Controllers;

[ApiController]
[Route("applications")]
public class ApplicationsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<ApplicationDto>> Get()
    {
        return await mediator.Send(new GetAllApplicationsQuery());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApplicationDto>> GetById(int id)
    {
        var result = await mediator.Send(new GetApplicationByIdQuery(id));

        if (result == null)
            return NotFound();

        return result;
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreateApplicationDto dto)
    {
        await mediator.Send(new CreateApplicationCommand(dto.CompanyName, dto.Position));

        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateApplicationDto dto)
    {
        var result = await mediator.Send(new GetApplicationByIdQuery(id));
        if (result is null)
            return NotFound();

        await mediator.Send(new UpdateApplicationCommand(id, dto.Status));

        return NoContent();
    }
}