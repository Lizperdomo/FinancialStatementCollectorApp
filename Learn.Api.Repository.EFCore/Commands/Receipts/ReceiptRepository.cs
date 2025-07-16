

using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using Microsoft.EntityFrameworkCore;

namespace Learn.Api.Repository.EFCore.Commands.Receipts
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly AppLearnContext _context;

        public ReceiptRepository(AppLearnContext context)
        {
            _context = context;
        }

        //Crear recibo
        public async Task AddReceiptAsync(Receipt receipt)
        {
            // Agrega el recibo al DbContext
            await _context.Receipts.AddAsync(receipt);

            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        //Cancelar recibo
        public async Task<bool> CancelReceiptAsync(int receiptId)
        {
            // Buscar el recibo por ID
            var receipt = await _context.Receipts.FirstOrDefaultAsync(r => r.Id == receiptId);

            // Si no se encuentra, no se puede cancelar
            if (receipt is null)
                return false;

            // Si ya está cancelado, no se hace nada
            if (receipt.Status == ReceiptStatus.Cancelled)
                return false;

            // Cambiar el estado a cancelado
            receipt.Cancel();

            // Guardar los cambios
            await _context.SaveChangesAsync();

            return true;
        }

        //Obtener todos los recibos
        public async Task<IEnumerable<Receipt>> GetAllAsync()
        {
            return await _context.Receipts.ToListAsync();
        }

        //Recibos por dia especifico
        public async Task<IEnumerable<Receipt>> GetReceiptsByDateAsync(DateTime date)
        {
            return await _context.Receipts
                .Where(r => r.CreatedAt.Date == date.Date)
                .ToListAsync();
        }

        //Recibos pod HouseId o nombre de residente
        public async Task<IEnumerable<Receipt>> GetReceiptsByHouseIdOrResidentNameAsync(string? houseId, string? residentName)
        {
            // Si no se proporciona ningún criterio, devolvemos una lista vacía
            if (string.IsNullOrWhiteSpace(houseId) && string.IsNullOrWhiteSpace(residentName))
                return Enumerable.Empty<Receipt>();

            // Comienza con la colección completa
            var query = _context.Receipts.AsQueryable();

            // Filtrar por houseId si se proporciona
            if (!string.IsNullOrWhiteSpace(houseId))
                query = query.Where(r => r.HouseId.Contains(houseId));

            // Filtrar por nombre del residente si se proporciona
            if (!string.IsNullOrWhiteSpace(residentName))
                query = query.Where(r => r.ResidentName.Contains(residentName));

            return await query.ToListAsync();
        }

        //Obtener los recibos de el dia en que se encuentre
        public async Task<IEnumerable<Receipt>> GetReceiptsForCurrentDayAsync()
        {
            var today = DateTime.UtcNow.Date;

            return await _context.Receipts
                .Where(r => r.CreatedAt.Date == today)
                .ToListAsync();
        }

        //Obtener los recibos del mes en que se encuentra
        public async Task<IEnumerable<Receipt>> GetReceiptsForCurrentMonthAsync()
        {
            var now = DateTime.UtcNow;
            var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
            var firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);

            return await _context.Receipts
                .Where(r => r.CreatedAt >= firstDayOfMonth && r.CreatedAt < firstDayOfNextMonth)
                .ToListAsync();
        }
    }
}
