using System;

namespace BakeryHub.Contracts.Users;

public record UserResponse(
    Guid Id,
    string Name,
    string Email,
    string Phone,
    string Role
);