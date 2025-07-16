using Learn.Api.BusinessObjects.Entities.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learn.Api.BusinessObjects.Interfaces.Receipts
{
    public interface IGetReceiptsByHouseOrResidentInput
    {
        Task<IEnumerable<Receipt>> GetAsync(string? houseId, string? residentName);
    }
}
