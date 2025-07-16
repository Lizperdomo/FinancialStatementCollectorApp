using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learn.Api.UseCases.Receipts.GetReceiptsForCurrentMonth
{
    public class GetReceiptsForCurrentMonthHandler : IGetReceiptsForCurrentMonthInput
    {
        private readonly IReceiptRepository _repository;

        public GetReceiptsForCurrentMonthHandler(IReceiptRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Receipt>> GetAsync()
        {
            var receipts = await _repository.GetReceiptsForCurrentMonthAsync();

            if (!receipts.Any())
                throw new Exception("No hay recibos registrados en el mes actual.");

            return receipts;
        }
    }
}
