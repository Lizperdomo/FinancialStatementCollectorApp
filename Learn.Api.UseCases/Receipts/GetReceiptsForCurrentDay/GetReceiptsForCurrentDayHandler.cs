using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learn.Api.UseCases.Receipts.GetReceiptsForCurrentDay
{
    public class GetReceiptsForCurrentDayHandler : IGetReceiptsForCurrentDayInput
    {
        private readonly IReceiptRepository _repository;

        public GetReceiptsForCurrentDayHandler(IReceiptRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Receipt>> GetAsync()
        {
            var receipts = await _repository.GetReceiptsForCurrentDayAsync();

            if (!receipts.Any())
                throw new Exception("No hay recibos registrados para el día de hoy.");

            return receipts;
        }
    }
}
