using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.Domain.Entities.Dtos.Receipts;

namespace Learn.Api.BusinessObjects.Interfaces.Receipts
{
    public interface ICreateReceiptController
    {
        Task<Receipt> CreateAsync(CreateReceiptDto dto);
    }
}
