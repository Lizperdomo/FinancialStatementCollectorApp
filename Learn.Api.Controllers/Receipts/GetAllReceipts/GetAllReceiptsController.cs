using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;

namespace Learn.Api.Controllers.Receipts.GetAllReceipts
{
    public class GetAllReceiptsController(IGetAllReceiptsInput inputPort) : IGetAllReceiptsController
    {
        public async Task<IEnumerable<Receipt>> GetAsync()
        {
            return await inputPort.GetAsync();
        }
    }
}
