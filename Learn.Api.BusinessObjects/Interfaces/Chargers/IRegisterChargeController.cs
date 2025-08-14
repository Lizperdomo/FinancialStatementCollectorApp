using Learn.Api.Domain.Entities.Dtos.Chargers;

namespace Learn.Api.BusinessObjects.Interfaces.Chargers;

public interface IRegisterChargeController
{
    Task<ResponseRegisterCharge> RegisterAsync(string email, RegisterChargeDto dto);
}
