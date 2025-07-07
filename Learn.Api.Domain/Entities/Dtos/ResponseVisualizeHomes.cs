using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Api.Domain.Entities.Dtos;

public class ResponseVisualizeHomes<T>
{
    public IEnumerable<T> Items { get; set; }
}
