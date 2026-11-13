using BakeryHub.Contracts.Users;

namespace BakeryHub.Application.UseCases.Users;

public interface IRegisterUserUseCase
{
    Task<UserResponse> ExecuteAsync(RegisterUserRequest request);
}