using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using JobApplicationTracker.Contracts;
using JobApplicationTracker.Repository;
using JobApplicationTracker.Repository.Models;
using Microsoft.Extensions.DependencyInjection;

namespace JobApplicationTracker.IntegrationTests;

public class ApplicationsControllerTest() : TestBase()
{
    [Fact]
    public async Task GetAll_ShouldReturnAllRecords()
    {
        // Arrange
        DbContext.Applications.Add(new Application()
        {
            Id = 1,
            Company = "Company",
            Position = "Position",
            Status = "Status",
            DateApplied = DateTimeOffset.Now,
        });

        await DbContext.SaveChangesAsync();

        //Act
        var response = await Client.GetAsync("/applications");
        response.EnsureSuccessStatusCode();
        var list = await response.Content.ReadFromJsonAsync<List<ApplicationDto>>();

        // Assert
        list?.Count.Should().Be(1);
    }
    
    [Fact]
    public async Task GetById_ShouldReturnOneRecord()
    {
        // Arrange
        DbContext.Applications.Add(new Application()
        {
            Id = 1,
            Company = "Company",
            Position = "Position",
            Status = "Status",
            DateApplied = DateTimeOffset.Now,
        });
        DbContext.Applications.Add(new Application()
        {
            Id = 2,
            Company = "Company2",
            Position = "Position2",
            Status = "Status",
            DateApplied = DateTimeOffset.Now,
        });

        await DbContext.SaveChangesAsync();

        //Act
        var response = await Client.GetAsync("/applications/2");
        response.EnsureSuccessStatusCode();
        var actual = await response.Content.ReadFromJsonAsync<ApplicationDto>();

        // Assert
        actual?.Id.Should().Be(2);
    }
    
    [Fact]
    public async Task Update_ShouldReturnOneRecord()
    {
        // Arrange
        DbContext.Applications.Add(new Application()
        {
            Id = 1,
            Company = "Company",
            Position = "Position",
            Status = "Interview",
            DateApplied = DateTimeOffset.Now,
        });

        await DbContext.SaveChangesAsync();

        //Act
        var response = await Client.PutAsJsonAsync("/applications/1", "Offer");
        response.EnsureSuccessStatusCode();

        // Assert
        using var scope = AppFactory.Services.CreateScope();
        await using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var result = await context.FindAsync<Application>(1);
        result?.Status.Should().Be("Offer");
    }
    
    [Fact]
    public async Task Add_ShouldReturnOneRecord()
    {
        //Act
        var response = await Client.PostAsJsonAsync("/applications", new CreateApplicationDto( "Company1", "Developer"));
        response.EnsureSuccessStatusCode();
        
        // Assert
        DbContext.Applications.Count().Should().Be(1);
    }
    
    [Fact]
    public async Task Add_ShouldReturn400_WhenCompanyIsEmpty()
    {
        //Act
        var response = await Client.PostAsJsonAsync("/applications", new CreateApplicationDto( "", ""));

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}