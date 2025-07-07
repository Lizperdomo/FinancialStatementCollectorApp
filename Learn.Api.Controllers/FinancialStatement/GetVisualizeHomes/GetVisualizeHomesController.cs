using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.BusinessObjects.Interfaces.FinancialStatement.GetVisualizeHomes.VisualizeAccount;

namespace Learn.Api.Controllers.FinancialStatement.GetVisualizeHomes;

public class GetVisualizeHomesController(IGetVisualizeHomesInput inputPort) : IGetVisualizeHomesController
{
    public async Task<ResponseVisualizeHomes<VisualizeHomesDto>> GetAllHomesAsync()
    {
        return await inputPort.GetAllHomesAsync();
    }
}
