namespace Learn.Api.Domain.Entities.Dtos.Chargers;

public class ResponseRegisterCharge(string receiptFolio, string message)
{
    public string ReceiptFolio => receiptFolio;
    public string Message => message;
}
