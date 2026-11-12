namespace BakeryHub.Domain.Entities;

public enum ApplicationStatus { Pending = 1, Approved = 2, Rejected = 3 }

public class BakeryApplication
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string TradeName { get; private set; }
    public string DocumentNumber { get; private set; }
    public string Phone { get; private set; }
    public string Address { get; private set; }
    public string Description { get; private set; }
    public ApplicationStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? ApprovedAt { get; private set; }
    public Guid? ApprovedByUserId { get; private set; }

    protected BakeryApplication() { }

    public BakeryApplication(Guid userId, string tradeName, string documentNumber, string phone, string address, string description)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        TradeName = tradeName;
        DocumentNumber = documentNumber;
        Phone = phone;
        Address = address;
        Description = description;
        Status = ApplicationStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    public void Approve(Guid adminUserId)
    {
        if (Status != ApplicationStatus.Pending) throw new InvalidOperationException("Apenas solicitações pendentes podem ser aprovadas.");
        Status = ApplicationStatus.Approved;
        ApprovedAt = DateTime.UtcNow;
        ApprovedByUserId = adminUserId;
    }

    public void Reject()
    {
        if (Status != ApplicationStatus.Pending) throw new InvalidOperationException("Apenas solicitações pendentes podem ser rejeitadas.");
        Status = ApplicationStatus.Rejected;
    }
}