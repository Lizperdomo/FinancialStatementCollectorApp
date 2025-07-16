using Learn.Api.BusinessObjects.Entities.Receipts;
using System.Threading.Tasks;

namespace Learn.Api.BusinessObjects.Interfaces.Receipts
{
    public interface ICreateReceiptRepository
    {
        Task CreateAsync(Receipt receipt);
    }
}
