using System.Net.Http.Json;
using FluentAssertions;
using JobApplicationTracker.Contracts;
using JobApplicationTracker.Repository.Models;

namespace JobApplicationTracker.IntegrationTests;

public class ApplicationsControllerTest : TestBase
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
}