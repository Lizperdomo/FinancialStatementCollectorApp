using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learn.Api.UseCases.Receipts.GetAllReceipts
{
    public class GetAllReceiptsHandler : IGetAllReceiptsInput
    {
        private readonly IReceiptRepository _repository;

        public GetAllReceiptsHandler(IReceiptRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Receipt>> GetAsync()
        {
            var receipts = await _repository.GetAllAsync();

            // Validación opcional: si no hay recibos, lanzar excepción
            if (!receipts.Any())
                throw new Exception("No se encontraron recibos registrados.");

            return receipts;
        }
    }
}
