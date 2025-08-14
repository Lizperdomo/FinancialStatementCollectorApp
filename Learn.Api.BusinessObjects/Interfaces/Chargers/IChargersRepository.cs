using Learn.Api.BusinessObjects.Entities.Chargers;

namespace Learn.Api.BusinessObjects.Interfaces.Chargers;

public interface IChargersRepository
{
    Task<Charge?> FindByEmailAsync(string email);
    Task<Charge> AddChargeAsync(Charge entity);
    Task<AssociatedCharge> AddAssociatedAsync(AssociatedCharge entity);
}
