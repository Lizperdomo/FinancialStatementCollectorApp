using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learn.Api.UseCases.Receipts.GetReceiptsByHouseOrResident
{
    public class GetReceiptsByHouseOrResidentHandler : IGetReceiptsByHouseOrResidentInput
    {
        private readonly IReceiptRepository _repository;

        public GetReceiptsByHouseOrResidentHandler(IReceiptRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Receipt>> GetAsync(string? houseId, string? residentName)
        {
            // Validar que al menos uno de los dos campos tenga valor
            bool isHouseIdEmpty = string.IsNullOrWhiteSpace(houseId);
            bool isResidentNameEmpty = string.IsNullOrWhiteSpace(residentName);

            if (isHouseIdEmpty && isResidentNameEmpty)
                throw new ArgumentException("Debe proporcionar el ID de la casa o el nombre del residente.");

            return await _repository.GetReceiptsByHouseIdOrResidentNameAsync(houseId, residentName);
        }
    }
}
