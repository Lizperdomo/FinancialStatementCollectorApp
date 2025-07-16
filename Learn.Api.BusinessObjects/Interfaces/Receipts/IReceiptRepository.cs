using Learn.Api.BusinessObjects.Entities.Receipts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learn.Api.BusinessObjects.Interfaces.Receipts
{
    public interface IReceiptRepository
    {
        Task<IEnumerable<Receipt>> GetAllAsync();  // Obtener todos los recibos
        Task<IEnumerable<Receipt>> GetReceiptsForCurrentMonthAsync();  // Recibos del mes actual
        Task<IEnumerable<Receipt>> GetReceiptsForCurrentDayAsync();    // Recibos del día actual
        Task<IEnumerable<Receipt>> GetReceiptsByHouseIdOrResidentNameAsync(string? houseId, string? residentName); // Buscar por casa o residente
        Task<IEnumerable<Receipt>> GetReceiptsByDateAsync(DateTime date);  // Buscar por fecha exacta
        Task AddReceiptAsync(Receipt receipt);     // Crear nuevo recibo
        Task<bool> CancelReceiptAsync(int receiptId); // Cancelar recibo por ID
    }
}
