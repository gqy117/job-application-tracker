using System.Net.Http.Json;
using FluentAssertions;
using JobApplicationTracker.Contracts;
using JobApplicationTracker.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.IntegrationTests;

public class ApplicationsControllerTest(CustomWebAppFactory appFactory) : TestBase(appFactory)
{
    [Fact]
    public async Task GetAll_ShouldReturnAllRecords()
    {
        // Arrange
        ApplicationDbContext.Applications.Add(new Application()
        {
            Id = 1,
            Company = "Company",
            Position = "Position",
            Status = "Status",
            DateApplied = DateTimeOffset.Now,
        });

        await ApplicationDbContext.SaveChangesAsync();

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
        ApplicationDbContext.Applications.Add(new Application()
        {
            Id = 1,
            Company = "Company",
            Position = "Position",
            Status = "Status",
            DateApplied = DateTimeOffset.Now,
        });
        ApplicationDbContext.Applications.Add(new Application()
        {
            Id = 2,
            Company = "Company2",
            Position = "Position2",
            Status = "Status",
            DateApplied = DateTimeOffset.Now,
        });

        await ApplicationDbContext.SaveChangesAsync();

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
        ApplicationDbContext.Applications.Add(new Application()
        {
            Id = 1,
            Company = "Company",
            Position = "Position",
            Status = "Interview",
            DateApplied = DateTimeOffset.Now,
        });

        await ApplicationDbContext.SaveChangesAsync();

        //Act
        var response = await Client.PutAsJsonAsync("/applications/1", "Offer");
        response.EnsureSuccessStatusCode();

        // Assert
        var response2 = await Client.GetAsync("/applications/1");
        response2.EnsureSuccessStatusCode();
        var actual = await response2.Content.ReadFromJsonAsync<ApplicationDto>();
        actual.Status.Should().Be("Offer");
    }
    
    [Fact]
    public async Task Add_ShouldReturnOneRecord()
    {
        //Act
        var response = await Client.PostAsJsonAsync("/applications", new CreateApplicationDto( "Company1", "Developer"));
        response.EnsureSuccessStatusCode();
        
        // Assert
        ApplicationDbContext.Applications.Count().Should().Be(1);
    }
}