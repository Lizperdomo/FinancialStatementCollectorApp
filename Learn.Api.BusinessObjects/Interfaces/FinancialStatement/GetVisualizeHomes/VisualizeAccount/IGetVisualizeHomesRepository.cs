using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Api.BusinessObjects.Interfaces.FinancialStatement.GetVisualizeHomes.VisualizeAccount;

public interface IGetVisualizeHomesRepository
{
    Task<ResponseVisualizeHomes<VisualizeHomesDto>> GetAllHomesAsync();
    Task SaveChangesAsync();
}
