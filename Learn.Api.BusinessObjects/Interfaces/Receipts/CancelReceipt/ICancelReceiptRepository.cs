using System.Threading.Tasks;

namespace Learn.Api.BusinessObjects.Interfaces.Receipts
{
    public interface ICancelReceiptRepository
    {
        Task<bool> CancelAsync(int receiptId);
    }
}
