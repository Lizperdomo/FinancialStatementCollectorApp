using System.Threading.Tasks;

namespace Learn.Api.BusinessObjects.Interfaces.Receipts
{
    public interface ICancelReceiptController
    {
        Task<bool> CancelAsync(int receiptId);
    }
}
