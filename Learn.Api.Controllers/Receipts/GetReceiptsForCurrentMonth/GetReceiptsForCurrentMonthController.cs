using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;

namespace Learn.Api.Controllers.Receipts.GetReceiptsForCurrentMonth
{
    public class GetReceiptsForCurrentMonthController(IGetReceiptsForCurrentMonthInput inputPort) : IGetReceiptsForCurrentMonthController
    {
        public async Task<IEnumerable<Receipt>> GetAsync()
        {
            return await inputPort.GetAsync();
        }
    }
}
