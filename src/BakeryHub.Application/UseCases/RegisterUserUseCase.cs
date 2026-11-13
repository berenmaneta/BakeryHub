using BakeryHub.Application.UseCases.Users;
using BakeryHub.Contracts.Users;
using BakeryHub.Domain.Entities;
using BakeryHub.Domain.Interfaces;
using BCrypt.Net;

namespace BakeryHub.Application.UseCases.Users;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserRepository _userRepository;

    public RegisterUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> ExecuteAsync(RegisterUserRequest request)
    {
        // 1. Regra de Negócio: E-mail não pode ser duplicado
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null)
        {
            throw new Exception("Este e-mail já está em uso.");
        }

        // 2. Mapeamento e Criptografia usando o Construtor da Entidade
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User(
            request.Name,
            request.Email,
            passwordHash,
            request.Phone
        );

        // 3. Persistência
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        // 4. Retorno (escondendo a senha)
        return new UserResponse(
            user.Id,
            user.Name,
            user.Email,
            user.Phone,
            user.Role
        );
    }
}