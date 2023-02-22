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
            CreateMap<JournalPdoDto, JournalPdo>();

            // Services to DAL
            CreateMap<JournalPdo, JournalPdoDto>();

            // Services to WEB
            CreateMap<JournalPdoDto, JournalPdoViewModel>();

            // WEB to Services
            CreateMap<JournalPdoViewModel, JournalPdoDto>();
        }

    }
}
