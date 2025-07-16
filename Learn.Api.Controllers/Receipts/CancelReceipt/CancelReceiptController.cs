using Learn.Api.BusinessObjects.Interfaces.Receipts;

namespace Learn.Api.Controllers.Receipts.CancelReceipt
{
    public class CancelReceiptController(ICancelReceiptInput inputPort) : ICancelReceiptController
    {
        // Recibe el ID del recibo a cancelar
        public async Task<bool> CancelAsync(int receiptId)
        {
            return await inputPort.CancelAsync(receiptId);
        }
    }
}
