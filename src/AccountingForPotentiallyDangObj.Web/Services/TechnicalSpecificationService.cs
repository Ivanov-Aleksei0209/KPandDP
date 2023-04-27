using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using AccountingForPotentiallyDangObj.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForPotentiallyDangObj.Web.Services
{
    public class TechnicalSpecificationService : ITechnicalSpecificationService
    {
        private readonly IRepository<TechnicalSpecification> _repositoryTechnicalSpecification;
        private readonly IMapperConfig _mapperConfig;
        
        public TechnicalSpecificationService(IRepository<TechnicalSpecification> repositoryTechnicalSpecification, IMapperConfig mapperConfig)
        {

            _repositoryTechnicalSpecification = repositoryTechnicalSpecification;
            _mapperConfig = mapperConfig;
        }

        public async Task<TechnicalSpecificationDto> AddTechnicalSpecificationAsync(TechnicalSpecificationDto technicalSpecificationModelDto)
        {
            var technicalSpecificationModel = _mapperConfig.Mapper.Map<TechnicalSpecification>(technicalSpecificationModelDto);

            technicalSpecificationModel = await _repositoryTechnicalSpecification.AddAsync(technicalSpecificationModel);

            technicalSpecificationModelDto = _mapperConfig.Mapper.Map<TechnicalSpecificationDto>(technicalSpecificationModel);

            return technicalSpecificationModelDto;
        }



        public async Task<List<TechnicalSpecification>> AddTechnicalSpecificationsAsync(List<TechnicalSpecification> technicalSpecificationModels)
        {
            foreach (var technicalSpecificationModel in technicalSpecificationModels)
            {

                await _repositoryTechnicalSpecification.AddAsync(technicalSpecificationModel);

            }
            return technicalSpecificationModels;
        }

        public async Task<TechnicalSpecificationDto> UpdateTechnicalSpecificationAsync(TechnicalSpecificationDto technicalSpecificationModelDto)
        {

            var technicalSpecificationModel = _mapperConfig.Mapper.Map<TechnicalSpecification>(technicalSpecificationModelDto);

            technicalSpecificationModel = await _repositoryTechnicalSpecification.UpdateAsync(technicalSpecificationModel);

            technicalSpecificationModelDto = _mapperConfig.Mapper.Map<TechnicalSpecificationDto>(technicalSpecificationModel);

            return technicalSpecificationModelDto;
        }
    }
}
