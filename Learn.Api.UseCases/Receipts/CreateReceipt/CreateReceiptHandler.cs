using Learn.Api.BusinessObjects.Entities.Receipts;
using Learn.Api.BusinessObjects.Interfaces.Receipts;
using Learn.Api.Domain.Entities.Dtos.Receipts;
using System;
using System.Threading.Tasks;

namespace Learn.Api.UseCases.Receipts.CreateReceipt
{
    public class CreateReceiptHandler : ICreateReceiptInput
    {
        private readonly IReceiptRepository _repository;

        public CreateReceiptHandler(IReceiptRepository repository)
        {
            _repository = repository;
        }

        public async Task<Receipt> CreateAsync(CreateReceiptDto dto)
        { 
            // === Validaciones básicas ===
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(dto.HouseId))
                throw new ArgumentException("El ID de la casa no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(dto.ResidentName))
                throw new ArgumentException("El nombre del residente no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(dto.Concept))
                throw new ArgumentException("El concepto del recibo no puede estar vacío.");

            // Validar valores numéricos
            if (dto.Amount <= 0)
                throw new ArgumentException("El monto debe ser mayor a cero.");

            if (dto.Discount < 0)
                throw new ArgumentException("El descuento no puede ser negativo.");

            if (dto.Surcharge < 0)
                throw new ArgumentException("El recargo no puede ser negativo.");

            // Crear entidad con los valores validados
            var receipt = new Receipt(
                houseId: dto.HouseId,
                residentName: dto.ResidentName,
                concept: dto.Concept,
                amount: dto.Amount,
                discount: dto.Discount,
                surcharge: dto.Surcharge
    );

            // Guardar en base de datos
            await _repository.AddReceiptAsync(receipt);

            // Retornar el receipt creado
            return receipt;
        }
    }
}
