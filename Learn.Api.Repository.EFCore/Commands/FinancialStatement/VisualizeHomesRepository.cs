using Learn.Api.Domain.Entities.Dtos.FinancialStatement;
using Learn.Api.Domain.Entities.Dtos;
using Learn.Api.BusinessObjects.Interfaces.FinancialStatement.GetVisualizeHomes.VisualizeAccount;
using Learn.Api.BusinessObjects.Interfaces.FinancialStatement.GetVisualizeHomes;
using Learn.Api.Domain.Entities.Dtos;


namespace Learn.Api.Repository.EFCore.Commands.FinancialStatement;
   internal class VisualizeHomesRepository(AppLearnContext context) : IGetVisualizeHomesRepository
{
        public async Task<ResponseVisualizeHomes<VisualizeHomesDto>> GetAllHomesAsync()
    {
        var response = new ResponseVisualizeHomes<VisualizeHomesDto>
        {
            Items = context.VisualizeHomes.Select(
                visualizeHomes => new VisualizeHomesDto
                (
                    visualizeHomes.Code,
                    visualizeHomes.NameResident,
                    visualizeHomes.Address,
                    visualizeHomes.Status,
                    visualizeHomes.Service,
                    visualizeHomes.FinancialStatement
                )
            ).ToList()
        };

        return response;
    }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }

