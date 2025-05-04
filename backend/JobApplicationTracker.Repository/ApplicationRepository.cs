using JobApplicationTracker.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Repository;

public class ApplicationRepository(ApplicationDbContext db)
{
    public async Task<List<Application>> GetAllAsync()
        => await db.Applications.ToListAsync();

    public async Task<Application?> GetByIdAsync(int id)
        => await db.Applications.FindAsync(id);

    public async Task<Application> AddAsync(Application entity)
    {
        var entry = await db.Applications.AddAsync(entity);
        await db.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<bool> UpdateAsync(Application entity)
    {
        if (!await db.Applications.AnyAsync(x => x.Id == entity.Id))
            return false;

        await db.SaveChangesAsync();
        return true;
    }
}