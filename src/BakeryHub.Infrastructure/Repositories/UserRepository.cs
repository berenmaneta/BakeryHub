using BakeryHub.Domain.Entities;
using BakeryHub.Domain.Interfaces;
using BakeryHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BakeryHub.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(BakeryHubDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }
}