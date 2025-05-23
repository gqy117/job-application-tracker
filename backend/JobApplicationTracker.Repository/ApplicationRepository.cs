using JobApplicationTracker.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Repository;

public class ApplicationRepository(ApplicationDbContext db)
{
    public async Task<List<Application>> GetAllAsync()
    {
        return await db.Applications.ToListAsync();
    }

    public async Task<Application?> GetByIdAsync(int id)
    {
        return await db.Applications.FindAsync(id);
    }

    public async Task<Application> AddAsync(Application entity)
    {
        var entry = await db.Applications.AddAsync(entity);
        await db.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task UpdateAsync(Application entity)
    {
        if (!await db.Applications.AnyAsync(x => x.Id == entity.Id))
            return;

        await db.SaveChangesAsync();
    }
}