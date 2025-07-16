using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;

namespace Learn.Api.Controllers.Receipts.GetReceiptsForCurrentDay
{
    public class GetReceiptsForCurrentDayController(IGetReceiptsForCurrentDayInput inputPort) : IGetReceiptsForCurrentDayController
    {
        public async Task<IEnumerable<Receipt>> GetAsync()
        {
            return await inputPort.GetAsync();
        }
    }
}
