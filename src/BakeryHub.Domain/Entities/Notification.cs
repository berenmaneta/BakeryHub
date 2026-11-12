using System;
using BakeryHub.Domain.Enums;

namespace BakeryHub.Domain.Entities;

public class Notification
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid BatchId { get; private set; }
    public string Title { get; private set; }
    public string Message { get; private set; }
    public DateTime ScheduledAt { get; private set; }
    public DateTime? SentAt { get; private set; }
    public NotificationStatus Status { get; private set; }

    protected Notification() { }

    public Notification(Guid userId, Guid batchId, string title, string message, DateTime scheduledAt)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        BatchId = batchId;
        Title = title;
        Message = message;
        ScheduledAt = scheduledAt; // RN-007: Recebe o momento calculado da notificação
        Status = NotificationStatus.Scheduled;
    }

    public void MarkAsSent()
    {
        Status = NotificationStatus.Sent;
        SentAt = DateTime.UtcNow;
    }

    public void MarkAsFailed()
    {
        Status = NotificationStatus.Failed;
    }
}