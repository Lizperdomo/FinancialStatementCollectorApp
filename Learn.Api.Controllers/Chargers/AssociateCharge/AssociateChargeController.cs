using Learn.Api.BusinessObjects.Interfaces.Chargers;
using Learn.Api.Domain.Entities.Dtos.Chargers;

namespace Learn.Api.Controllers.Chargers.AssociateCharge;

public class AssociateChargeController(IAssociateChargeInput input) : IAssociateChargeController
{
    public Task<ResponseAssociateCharge> AssociateAsync(string email, AssociateChargeDto dto)
        => input.HandleAsync(email, dto);
}
