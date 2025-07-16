using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.Domain.Entities.Dtos.Receipts;
using System.Threading.Tasks;

namespace Learn.Api.BusinessObjects.Interfaces.Receipts
{
    public interface ICreateReceiptInput
    {
        Task<Receipt> CreateAsync(CreateReceiptDto dto);
    }
}
