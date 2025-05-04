using JobApplicationTracker.Repository;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace JobApplicationTracker.IntegrationTests;

public class TestBase : IDisposable
{
    protected readonly HttpClient Client;
    protected readonly ApplicationDbContext ApplicationDbContext;
    protected IServiceScope Scope;

    protected TestBase()
    {
        var appFactory = new WebApplicationFactory<Program>();
        Client = appFactory.CreateClient();
        
        Scope = appFactory.Services.CreateScope();

        ApplicationDbContext = Scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        ApplicationDbContext.Database.EnsureDeleted();
        ApplicationDbContext.Database.EnsureCreated();
    }

    public void Dispose()
    {
        ApplicationDbContext.Database.EnsureDeleted();
        ApplicationDbContext.Dispose();
        Scope.Dispose();
        Client.Dispose();
    }
}