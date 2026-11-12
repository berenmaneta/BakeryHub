namespace BakeryHub.Domain.Entities;

public class Subscription
{
    public Guid Id { get; private set; }
    public Guid CustomerUserId { get; private set; }
    public Guid BakeryProfileId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected Subscription() { }

    public Subscription(Guid customerUserId, Guid bakeryProfileId)
    {
        Id = Guid.NewGuid();
        CustomerUserId = customerUserId;
        BakeryProfileId = bakeryProfileId;
        CreatedAt = DateTime.UtcNow;
    }
}