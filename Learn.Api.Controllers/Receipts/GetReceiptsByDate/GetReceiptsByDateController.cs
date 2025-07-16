using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;

namespace Learn.Api.Controllers.Receipts.GetReceiptsByDate
{
    public class GetReceiptsByDateController(IGetReceiptsByDateInput inputPort) : IGetReceiptsByDateController
    {
        public async Task<IEnumerable<Receipt>> GetAsync(DateTime date)
        {
            return await inputPort.GetAsync(date);
        }
    }
}
