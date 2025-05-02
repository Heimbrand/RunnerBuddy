using Microsoft.EntityFrameworkCore;
using RunnerBuddy.Application.Interfaces;
using RunnerBuddy.Domain.Entities;
using RunnerBuddy.Persistance.Context;

namespace RunnerBuddy.Persistance.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly RunnerBuddyDbContext Context;
    public GenericRepository(RunnerBuddyDbContext context)
    {
        Context = context;
    }


    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
    public async Task<TEntity> GetById(int id)
    {
        return await Context.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
    }
    public async Task Add(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
        await Context.SaveChangesAsync();
    }
    public async Task Delete(TEntity entity)
    {
        await Task.Run(() => Context.Set<TEntity>().Remove(entity));
        await Context.SaveChangesAsync();
    }
    public async Task Update(TEntity entity)
    {
        await Task.Run(() => Context.Set<TEntity>().Update(entity));
        await Context.SaveChangesAsync();
    }
}