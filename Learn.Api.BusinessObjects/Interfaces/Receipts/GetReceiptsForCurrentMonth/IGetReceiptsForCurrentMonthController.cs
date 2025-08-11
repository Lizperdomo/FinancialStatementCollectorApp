using Learn.Api.BusinessObjects.Entities.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learn.Api.BusinessObjects.Interfaces.Receipts
{
    public interface IGetReceiptsForCurrentMonthController
    {
        Task<IEnumerable<Receipt>> GetAsync();
    }
}
