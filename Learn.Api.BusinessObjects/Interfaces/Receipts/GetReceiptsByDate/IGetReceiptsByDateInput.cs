using Learn.Api.BusinessObjects.Entities.Receipts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learn.Api.BusinessObjects.Interfaces.Receipts
{
    public interface IGetReceiptsByDateInput
    {
        // Recibe una fecha como parámetro y devuelve los recibos creados ese día
        Task<IEnumerable<Receipt>> GetAsync(DateTime date);
    }
}
