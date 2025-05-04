using JobApplicationTracker.Contracts;
using JobApplicationTracker.Repository;
using JobApplicationTracker.Repository.Models;
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
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApplicationDto>> GetById(int id)
    {
        var app = await repository.GetByIdAsync(id);
        if (app is null) 
            return NotFound();

        return new ApplicationDto(app.Id,
            app.Company,
            app.Position,
            app.Status,
            app.DateApplied
        );
    }
    
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreateApplicationDto dto)
    {
        await repository.AddAsync(new Application
        {
            Company = dto.CompanyName,
            DateApplied = DateTime.Now,
            Position = dto.Position,
            Status = "",
        });
        
        return NoContent();
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] string status)
    {
        var app = await repository.GetByIdAsync(id);
        if (app is null) 
            return NotFound();

        app.Status = status;
        
        await repository.UpdateAsync(app);

        return NoContent();
    }
}