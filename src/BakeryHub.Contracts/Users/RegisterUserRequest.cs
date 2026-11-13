namespace BakeryHub.Contracts.Users;

public record RegisterUserRequest(
    string Name,
    string Email,
    string Password,
    string Phone
);