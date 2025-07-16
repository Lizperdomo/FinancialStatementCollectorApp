using Learn.Api.BusinessObjects.Entities.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learn.Api.BusinessObjects.Interfaces.Receipts
{
    public interface IGetReceiptsForCurrentMonthInput
    {
        // Devuelve los recibos creados durante el mes actual
        Task<IEnumerable<Receipt>> GetAsync();
    }
}
