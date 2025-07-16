using Learn.Api.BusinessObjects.Entities.Receipts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learn.Api.BusinessObjects.Interfaces.Receipts
{
    public interface IGetReceiptsByDateController
    {
        Task<IEnumerable<Receipt>> GetAsync(DateTime date);
    }
}
