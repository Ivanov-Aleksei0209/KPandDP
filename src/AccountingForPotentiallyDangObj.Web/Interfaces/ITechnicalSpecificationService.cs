using AccountingForPotentiallyDangObj.Web.DtoModels;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface ITechnicalSpecificationService
    {
        Task<TechnicalSpecificationDto> AddTechnicalSpecificationAsync(TechnicalSpecificationDto technicalSpecificationModelDto);

        Task<TechnicalSpecificationDto> UpdateTechnicalSpecificationAsync(TechnicalSpecificationDto technicalSpecificationModelDto);
    }
}
