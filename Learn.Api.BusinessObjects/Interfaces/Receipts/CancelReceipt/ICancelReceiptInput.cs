using System.Threading.Tasks;

namespace Learn.Api.BusinessObjects.Interfaces.Receipts
{
    public interface ICancelReceiptInput
    {
        // Cancela el recibo con el ID indicado. Devuelve true si se logró cancelar.
        Task<bool> CancelAsync(int receiptId);
    }
}
