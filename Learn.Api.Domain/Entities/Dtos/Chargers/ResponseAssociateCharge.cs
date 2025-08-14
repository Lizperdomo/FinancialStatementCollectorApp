namespace Learn.Api.Domain.Entities.Dtos.Chargers;

public class ResponseAssociateCharge(Guid associatedId, string message)
{
    public Guid AssociatedId => associatedId;
    public string Message => message;
}
