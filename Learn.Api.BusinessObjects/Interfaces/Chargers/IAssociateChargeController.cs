using Learn.Api.Domain.Entities.Dtos.Chargers;

namespace Learn.Api.BusinessObjects.Interfaces.Chargers;

public interface IAssociateChargeController
{
    Task<ResponseAssociateCharge> AssociateAsync(string email, AssociateChargeDto dto);
}
