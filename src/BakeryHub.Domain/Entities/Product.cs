using System;

namespace BakeryHub.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public Guid BakeryProfileId { get; private set; }
    public string Name { get; private set; }
    public int DefaultDurationMinutes { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    protected Product() { }

    public Product(Guid bakeryProfileId, string name, int defaultDurationMinutes)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("O nome do produto é obrigatório.");
        if (defaultDurationMinutes <= 0) throw new ArgumentException("A duração padrão deve ser maior que zero.");

        Id = Guid.NewGuid();
        BakeryProfileId = bakeryProfileId;
        Name = name;
        DefaultDurationMinutes = defaultDurationMinutes;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string name, int defaultDurationMinutes)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("O nome do produto é obrigatório.");
        if (defaultDurationMinutes <= 0) throw new ArgumentException("A duração padrão deve ser maior que zero.");

        Name = name;
        DefaultDurationMinutes = defaultDurationMinutes;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }
}