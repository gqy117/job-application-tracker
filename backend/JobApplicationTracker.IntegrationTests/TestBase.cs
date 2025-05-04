using JobApplicationTracker.Repository;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace JobApplicationTracker.IntegrationTests;

public class TestBase : IDisposable
{
    protected readonly HttpClient Client;
    protected readonly ApplicationDbContext DbContext;
    protected IServiceScope Scope;
    protected WebApplicationFactory<Program> AppFactory;

    protected TestBase()
    {
        AppFactory = new WebApplicationFactory<Program>();
        Client = AppFactory.CreateClient();
        
        Scope = AppFactory.Services.CreateScope();

        DbContext = Scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        DbContext.Database.EnsureDeleted();
        DbContext.Database.EnsureCreated();
    }

    public void Dispose()
    {
        DbContext.Database.EnsureDeleted();
        DbContext.Dispose();
        Scope.Dispose();
        Client.Dispose();
    }
}