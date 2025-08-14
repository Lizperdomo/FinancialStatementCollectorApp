using Learn.Api.BusinessObjects.Interfaces.Chargers;
using Learn.Api.Domain.Entities.Dtos.Chargers;

namespace Learn.Api.Controllers.Chargers.RegisterCharge;

public class RegisterChargeController(IRegisterChargeInput input) : IRegisterChargeController
{
    public Task<ResponseRegisterCharge> RegisterAsync(string email, RegisterChargeDto dto)
        => input.HandleAsync(email, dto);
}
