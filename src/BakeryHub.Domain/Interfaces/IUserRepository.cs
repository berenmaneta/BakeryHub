using BakeryHub.Domain.Entities;

namespace BakeryHub.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}