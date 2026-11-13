using BakeryHub.Domain.Interfaces;
using BakeryHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BakeryHub.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly BakeryHubDbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(BakeryHubDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public async Task<bool> SaveChangesAsync() => await _dbContext.SaveChangesAsync() > 0;
}