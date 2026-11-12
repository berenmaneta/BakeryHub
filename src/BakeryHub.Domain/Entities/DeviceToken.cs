using System;

namespace BakeryHub.Domain.Entities;

public class DeviceToken
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Token { get; private set; }
    public string Platform { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? LastUsedAt { get; private set; }

    protected DeviceToken() { }

    public DeviceToken(Guid userId, string token, string platform)
    {
        if (string.IsNullOrWhiteSpace(token)) throw new ArgumentException("O token é obrigatório.");

        Id = Guid.NewGuid();
        UserId = userId;
        Token = token;
        Platform = platform; // Ex: "Android" ou "iOS"
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateLastUsed()
    {
        LastUsedAt = DateTime.UtcNow;
    }
}