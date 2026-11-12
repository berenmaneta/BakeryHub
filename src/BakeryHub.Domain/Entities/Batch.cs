using System;
using BakeryHub.Domain.Enums;

namespace BakeryHub.Domain.Entities;

public class Batch
{
    public Guid Id { get; private set; }
    public Guid BakeryProfileId { get; private set; }
    public Guid ProductId { get; private set; } 
    public DateTime StartTime { get; private set; }
    public int DurationMinutes { get; private set; }
    public DateTime EstimatedReadyAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public BatchStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    protected Batch() { }

    public Batch(Guid bakeryProfileId, Guid productId, DateTime startTime, int durationMinutes)
    {
        if (durationMinutes <= 0)
            throw new ArgumentException("A duração da produção deve ser maior que zero.", nameof(durationMinutes));

        Id = Guid.NewGuid();
        BakeryProfileId = bakeryProfileId;
        ProductId = productId;
        StartTime = startTime;
        DurationMinutes = durationMinutes;
        EstimatedReadyAt = startTime.AddMinutes(durationMinutes);
        Status = BatchStatus.InProgress;
        CreatedAt = DateTime.UtcNow;
    }

    public void Complete()
    {
        if (Status == BatchStatus.Completed)
            throw new InvalidOperationException("Esta produção já foi concluída.");

        if (Status == BatchStatus.Canceled)
            throw new InvalidOperationException("Não é possível concluir uma produção cancelada.");

        Status = BatchStatus.Completed;
        CompletedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Cancel()
    {
        if (Status == BatchStatus.Completed)
            throw new InvalidOperationException("Não é possível cancelar uma produção já concluída.");

        Status = BatchStatus.Canceled;
        UpdatedAt = DateTime.UtcNow;
    }
}