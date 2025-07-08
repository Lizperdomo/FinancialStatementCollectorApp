using Learn.Api.Business.Objects.Interfaces.FinancialStatement.VisualizeAccount;
using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.Domain.Entities.Dtos.FinancialStatement;


namespace Learn.Api.Controllers.FinancialStatement.GetVisualizeAccount;

internal class GetVizualizeAccountController(IGetVisualizeAccountInputPort inputPort) : IGetVisualizeAccountController
{
    public async Task<ResponseVisualizeAccount<VisualizeAccountDto>> GetAllFinancialStatementAsync(bool status)
    {
        return await inputPort.GetAllFinancialStatementAsync(status);
    }
}


    
