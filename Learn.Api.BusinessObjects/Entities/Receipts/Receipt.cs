using System;

namespace Learn.Api.BusinessObjects.Entities.Receipts
{
    public class Receipt
    {
        public int Id { get; protected set; }  // Identificador único (clave primaria)

        public string Folio { get; protected set; } = string.Empty;  // Folio único generado automáticamente

        public string HouseId { get; protected set; } = string.Empty;        // ID de la casa
        public string ResidentName { get; protected set; } = string.Empty;   // Nombre del residente
        public string Concept { get; protected set; } = string.Empty;        // Descripción del concepto

        public decimal Amount { get; protected set; }      // Monto base
        public decimal Discount { get; protected set; }    // Descuento aplicado
        public decimal Surcharge { get; protected set; }   // Recargo aplicado

        // Total calculado automáticamente
        public decimal Total => Amount - Discount + Surcharge;

        public DateTime CreatedAt { get; protected set; }          // Fecha de creación
        public ReceiptStatus Status { get; protected set; }        // Estado del recibo

        // Constructor para EF Core
        protected Receipt() { }

        // Constructor para crear un nuevo recibo
        public Receipt(string houseId, string residentName, string concept, decimal amount, decimal discount, decimal surcharge)
        {
            Folio = GenerateFolio();           // Se genera un folio único
            HouseId = houseId;
            ResidentName = residentName;
            Concept = concept;
            Amount = amount;
            Discount = discount;
            Surcharge = surcharge;
            CreatedAt = DateTime.UtcNow;
            Status = ReceiptStatus.Active;
        }

        // Método para cancelar el recibo si aún no está cancelado
        public void Cancel()
        {
            if (Status == ReceiptStatus.Cancelled) return;
            Status = ReceiptStatus.Cancelled;
        }

        // Método auxiliar para generar un folio alfanumérico corto
        private string GenerateFolio()
        {
            return $"RCPT-{Guid.NewGuid().ToString("N")[..8].ToUpper()}";
        }
    }

    // Estados posibles de un recibo
    public enum ReceiptStatus
    {
        Active = 1,
        Cancelled = 2
    }
}
