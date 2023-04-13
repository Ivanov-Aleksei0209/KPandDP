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
            //CreateMap<JournalPdoDto, JournalPdo>();
            CreateMap<PdoDto, Pdo>();
            CreateMap<SubjectDto, Subject>();
            CreateMap<InspectorDto, Inspector>();

            // Services to DAL
            //CreateMap<JournalPdo, JournalPdoDto>();
            CreateMap<Pdo, PdoDto>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<Inspector, InspectorDto>();
            // Services to WEB
            //CreateMap<JournalPdoDto, JournalPdoViewModel>();
            CreateMap<PdoDto, PdoViewModel>()
                .ForMember(dest => dest.WithdrawalFromRegistration, opt => opt.MapFrom(src => src.WithdrawalFromRegistrationDateOnly))
                .ForMember(dest => dest.DateOfRegistration, opt => opt.MapFrom(src => src.DateOfRegistryDateOnly))
                .ForMember(dest => dest.InformationAboutTheTechnicalInspection, opt => opt.MapFrom(src => src.InformationAboutTheTechnicalInspectionDateOnly))
                .ForMember(dest => dest.InformationAboutTheLastSurvey, opt => opt.MapFrom(src => src.InformationAboutTheLastSurveyDateOnly))
                .ForMember(dest => dest.InformationAboutTheTechnicalDiagnostic, opt => opt.MapFrom(src => src.InformationAboutTheTechnicalDiagnosticDateOnly));
            CreateMap<ReportPdoDto, ReportPdoViewModel>();
            CreateMap<SubjectDto, SubjectViewModel>();
            CreateMap<InspectorDto, InspectorViewModel>();

            // WEB to Services
            //CreateMap<JournalPdoViewModel, JournalPdoDto>();
            CreateMap<PdoViewModel, PdoDto>();
            CreateMap<SubjectViewModel, SubjectDto>();
            CreateMap<InspectorViewModel, InspectorDto>();

        }

    }
}
