using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learn.Api.UseCases.Receipts.GetReceiptsByDate
{
    public class GetReceiptsByDateHandler : IGetReceiptsByDateInput
    {
        private readonly IReceiptRepository _repository;

        public GetReceiptsByDateHandler(IReceiptRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Receipt>> GetAsync(DateTime date)
        {
            // Validar que la fecha no sea futura
            if (date.Date > DateTime.UtcNow.Date)
                throw new ArgumentException("No se pueden consultar recibos de una fecha futura.");

            return await _repository.GetReceiptsByDateAsync(date);
        }
    }
}
