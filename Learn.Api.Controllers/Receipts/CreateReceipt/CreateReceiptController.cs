using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using Learn.Api.Domain.Entities.Dtos.Receipts;

namespace Learn.Api.Controllers.Receipts.CreateReceipt
{
    public class CreateReceiptController(ICreateReceiptInput inputPort) : ICreateReceiptController
    {
        // Se recibe un DTO
        public async Task<Receipt> CreateAsync(CreateReceiptDto dto)
        {
            return await inputPort.CreateAsync(dto);
        }
    }
}
