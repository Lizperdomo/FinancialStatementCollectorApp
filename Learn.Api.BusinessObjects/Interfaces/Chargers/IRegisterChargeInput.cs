using Learn.Api.Domain.Entities.Dtos.Chargers;

namespace Learn.Api.BusinessObjects.Interfaces.Chargers;

public interface IRegisterChargeInput
{
    Task<ResponseRegisterCharge> HandleAsync(string email, RegisterChargeDto dto);
}
