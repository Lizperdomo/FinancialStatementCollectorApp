using Learn.Api.BusinessObjects.Entities.Chargers;
using Learn.Api.BusinessObjects.Interfaces.Chargers;
using Learn.Api.Domain.Entities.Dtos.Chargers;

namespace Learn.Api.UseCases.Chargers;

public class RegisterChargeHandler(IChargersRepository repo) : IRegisterChargeInput
{
    public async Task<ResponseRegisterCharge> HandleAsync(string email, RegisterChargeDto r)
    {
        var folio = $"FOL-{Guid.NewGuid():N}".ToUpperInvariant();

        var entity = new Charge
        {
            Email = email,
            AgreementNumber = r.AgreementNumber,
            Description = r.Description,
            Debt = r.Debt,
            PaymentsCount = r.PaymentsCount,
            Amount = r.Amount,
            DueDate = r.DueDate,
            ReceiptFolio = folio
        };

        await repo.AddChargeAsync(entity);
        return new ResponseRegisterCharge(folio, "Registro creado");
    }
}
