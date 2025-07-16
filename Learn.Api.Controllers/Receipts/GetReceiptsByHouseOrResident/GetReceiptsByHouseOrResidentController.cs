using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;

namespace Learn.Api.Controllers.Receipts.GetReceiptsByHouseOrResident
{
    public class GetReceiptsByHouseOrResidentController(IGetReceiptsByHouseOrResidentInput inputPort)
        : IGetReceiptsByHouseOrResidentController
    {
        public async Task<IEnumerable<Receipt>> GetAsync(string? houseId, string? residentName)
        {
            return await inputPort.GetAsync(houseId, residentName);
        }
    }
}
