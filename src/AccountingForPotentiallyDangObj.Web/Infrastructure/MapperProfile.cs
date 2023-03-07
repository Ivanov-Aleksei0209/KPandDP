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
            CreateMap<PdoDto, Pdo>();

            // Services to DAL
            CreateMap<JournalPdo, JournalPdoDto>();
            CreateMap<Pdo, PdoDto>();

            // Services to WEB
            CreateMap<JournalPdoDto, JournalPdoViewModel>();
            CreateMap<PdoDto, PdoViewModel>()
                .ForMember(dest => dest.WithdrawalFromRegistration, opt => opt.MapFrom(src => src.WithdrawalFromRegistrationDateOnly))
                .ForMember(dest1 => dest1.DateOfRegistration, opt1 => opt1.MapFrom(src1 => src1.DateOfRegistryDateOnly))
                .ForMember(dest2 => dest2.InformationAboutTheTechnicalInspection, opt2 => opt2.MapFrom(src2 => src2.InformationAboutTheTechnicalInspectionDateOnly));

            // WEB to Services
            CreateMap<JournalPdoViewModel, JournalPdoDto>();
            CreateMap<PdoViewModel, PdoDto>();
        }

    }
}
