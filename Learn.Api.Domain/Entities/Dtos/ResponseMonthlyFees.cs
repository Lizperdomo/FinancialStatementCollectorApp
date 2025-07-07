namespace Learn.Api.Domain.Entities.Dtos;

public class ResponseMonthlyFees<T>
{
    public IEnumerable<T> Items { get; set; }

}

