using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Models;
using AutoMapper;

namespace AccountingForPotentiallyDangObj.Web.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            // DAL to Services
            CreateMap<InspectorDto, Inspector>();

            // Services to DAL
            CreateMap<Inspector, InspectorDto>();

            // Services to WEB
            CreateMap<InspectorDto, InspectorViewModel>();

            // WEB to Services
            CreateMap<InspectorViewModel, InspectorDto>(); 
        }
    }
}
