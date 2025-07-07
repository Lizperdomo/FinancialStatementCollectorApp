namespace Learn.Api.Domain.Entities.Dtos;

public class ResponseSearchAccount<T>
{
    public IEnumerable<T> Items { get; set; }

}

