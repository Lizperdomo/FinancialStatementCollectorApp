using Learn.Api.Domain.Entities.Dtos.Chargers;

namespace Learn.Api.BusinessObjects.Interfaces.Chargers;

public interface IAssociateChargeInput
{
    Task<ResponseAssociateCharge> HandleAsync(string email, AssociateChargeDto dto);
}
