namespace Learn.Api.Domain.Entities.Dtos;

public class ResponseVisualizeAccount<T>
{
    public IEnumerable<T> Items { get; set; }

}
