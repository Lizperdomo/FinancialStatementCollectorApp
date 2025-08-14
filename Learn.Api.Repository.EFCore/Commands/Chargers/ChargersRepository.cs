using Learn.Api.BusinessObjects.Entities.Chargers;
using Learn.Api.BusinessObjects.Interfaces.Chargers;
using Microsoft.EntityFrameworkCore;

namespace Learn.Api.Repository.EFCore.Commands.Chargers;

public class ChargersRepository(AppLearnContext ctx) : IChargersRepository
{
    public Task<Charge?> FindByEmailAsync(string email) =>
        ctx.Charges.Include(x => x.AssociatedCharges)
                   .FirstOrDefaultAsync(x => x.Email == email);

    public async Task<Charge> AddChargeAsync(Charge entity)
    {
        ctx.Charges.Add(entity);
        await ctx.SaveChangesAsync();
        return entity;
    }

    public async Task<AssociatedCharge> AddAssociatedAsync(AssociatedCharge entity)
    {
        ctx.AssociatedCharges.Add(entity);
        await ctx.SaveChangesAsync();
        return entity;
    }
}
