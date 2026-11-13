using System;

namespace BakeryHub.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public string Phone { get; private set; } = string.Empty;
    public string Role { get; private set; } = "Customer";

    protected User() { }

    public User(string name, string email, string passwordHash, string phone)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome é obrigatório.", nameof(name));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("O e-mail é obrigatório.", nameof(email));

        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Phone = phone;
        Role = "Customer";
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        if (!IsActive)
            throw new InvalidOperationException("O usuário já está inativo.");

        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }
}