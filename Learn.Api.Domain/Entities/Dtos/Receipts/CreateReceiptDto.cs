namespace Learn.Api.Domain.Entities.Dtos.Receipts
{
    // DTO para la creación de un nuevo recibo
    public class CreateReceiptDto
    {
        public string HouseId { get; set; } = string.Empty;          // ID de la casa o propiedad
        public string ResidentName { get; set; } = string.Empty;     // Nombre del residente
        public string Concept { get; set; } = string.Empty;          // Concepto del pago
        public decimal Amount { get; set; }                          // Monto base del recibo
        public decimal Discount { get; set; }                        // Descuento aplicado
        public decimal Surcharge { get; set; }                       // Recargo aplicado
    }
}
