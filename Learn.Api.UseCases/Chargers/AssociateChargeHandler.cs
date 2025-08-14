using Learn.Api.BusinessObjects.Entities.Chargers;
using Learn.Api.BusinessObjects.Interfaces.Chargers;
using Learn.Api.Domain.Entities.Dtos.Chargers;

namespace Learn.Api.UseCases.Chargers;

public class AssociateChargeHandler(IChargersRepository repo) : IAssociateChargeInput
{
    public async Task<ResponseAssociateCharge> HandleAsync(string email, AssociateChargeDto r)
    {
        var parent = await repo.FindByEmailAsync(email);
        if (parent is null) throw new KeyNotFoundException("Charge not found");

        var assoc = new AssociatedCharge
        {
            ChargeId = parent.Id,
            MiscIncomeType = r.MiscIncomeType,
            Amount = r.Amount
        };

        assoc = await repo.AddAssociatedAsync(assoc);
        return new ResponseAssociateCharge(assoc.Id, "Ingreso asociado");
    }
}
