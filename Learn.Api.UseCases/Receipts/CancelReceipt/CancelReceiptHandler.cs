using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learn.Api.UseCases.Receipts.CancelReceipt
{
    public class CancelReceiptHandler : ICancelReceiptInput
    {
        private readonly IReceiptRepository _repository;

        public CancelReceiptHandler(IReceiptRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CancelAsync(int receiptId)
        {
            // Valida si el recibo existe
            var allReceipts = await _repository.GetAllAsync();
            var receipt = allReceipts.FirstOrDefault(r => r.Id == receiptId);

            if (receipt == null)
                throw new KeyNotFoundException("El recibo no existe.");

            // Validam si ya está cancelado
            if (receipt.Status == ReceiptStatus.Cancelled)
                return false; // Ya está cancelado, no hace nada

            // Procede a cancelar el recibo
            return await _repository.CancelReceiptAsync(receiptId);
        }
    }
}
