namespace BakeryHub.Domain.Entities;

public class NotificationPreference
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid BakeryProfileId { get; private set; }
    public int MinutesBefore { get; private set; }

    protected NotificationPreference() { }

    public NotificationPreference(Guid userId, Guid bakeryProfileId, int minutesBefore)
    {
        if (minutesBefore <= 0) throw new ArgumentException("Os minutos de antecedência devem ser maiores que zero.");

        Id = Guid.NewGuid();
        UserId = userId;
        BakeryProfileId = bakeryProfileId;
        MinutesBefore = minutesBefore;
    }

    public void UpdateMinutes(int minutesBefore)
    {
        if (minutesBefore <= 0) throw new ArgumentException("Os minutos de antecedência devem ser maiores que zero.");
        MinutesBefore = minutesBefore;
    }
}