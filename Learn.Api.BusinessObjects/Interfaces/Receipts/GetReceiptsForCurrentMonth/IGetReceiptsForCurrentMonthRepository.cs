using Learn.Api.BusinessObjects.Entities.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learn.Api.BusinessObjects.Interfaces.Receipts
{
    public interface IGetReceiptsForCurrentMonthRepository
    {
        Task<IEnumerable<Receipt>> GetAsync();
    }
}
