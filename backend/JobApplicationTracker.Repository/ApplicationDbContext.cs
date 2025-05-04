using JobApplicationTracker.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Repository;

public class ApplicationDbContext : DbContext
{
    public DbSet<Application> Applications  => Set<Application>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}