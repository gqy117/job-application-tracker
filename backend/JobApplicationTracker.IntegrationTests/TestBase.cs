using JobApplicationTracker.Controllers;
using JobApplicationTracker.Repository;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace JobApplicationTracker.IntegrationTests;

public class TestBase : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly HttpClient Client;
    protected readonly ApplicationDbContext ApplicationDbContext;
    private IServiceScope Scope;

    protected TestBase()
    {
        var appFactory = new WebApplicationFactory<ApplicationsController>()
            .WithWebHostBuilder(builder =>
            {

            });
            
        Client = appFactory.CreateClient();
        
        Scope = appFactory.Services.CreateScope();
        ApplicationDbContext = Scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
    
    public void Dispose()
    {
        ApplicationDbContext.Dispose();
        Scope.Dispose();
        Client.Dispose();
    }
}