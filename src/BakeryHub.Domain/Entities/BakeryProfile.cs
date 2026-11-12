using System;

namespace BakeryHub.Domain.Entities;

public class BakeryProfile
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string TradeName { get; private set; }
    public string Description { get; private set; }
    public string Phone { get; private set; }
    public string Address { get; private set; }
    public string? LogoUrl { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    protected BakeryProfile() { }

    public BakeryProfile(Guid userId, string tradeName, string description, string phone, string address)
    {
        if (string.IsNullOrWhiteSpace(tradeName))
            throw new ArgumentException("O nome fantasia é obrigatório.", nameof(tradeName));

        Id = Guid.NewGuid();
        UserId = userId;
        TradeName = tradeName;
        Description = description;
        Phone = phone;
        Address = address;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateProfile(string tradeName, string description, string phone, string address)
    {
        if (string.IsNullOrWhiteSpace(tradeName))
            throw new ArgumentException("O nome fantasia é obrigatório.", nameof(tradeName));

        TradeName = tradeName;
        Description = description;
        Phone = phone;
        Address = address;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateLogo(string logoUrl)
    {
        if (string.IsNullOrWhiteSpace(logoUrl))
            throw new ArgumentException("A URL da logo não pode estar vazia.", nameof(logoUrl));

        LogoUrl = logoUrl;
        UpdatedAt = DateTime.UtcNow;
    }
}