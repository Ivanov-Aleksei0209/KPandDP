using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.DtoModels;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.Models;
using AutoMapper;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // DAL to Services
            //CreateMap<JournalPdoDto, JournalPdo>();
            //CreateMap<PdoDto, ExcelModel>();
            CreateMap<SubjectDto, Subject>();

            // Services to DAL
            //CreateMap<JournalPdo, JournalPdoDto>();
            //CreateMap<ExcelModel, PdoDto>();
            CreateMap<Subject, SubjectDto>();

            // Services to WEB
            //CreateMap<JournalPdoDto, JournalPdoViewModel>();
            //CreateMap<PdoDto, PdoViewModel>()
            //    .ForMember(dest => dest.WithdrawalFromRegistration, opt => opt.MapFrom(src => src.WithdrawalFromRegistrationDateOnly))
            //    .ForMember(dest => dest.DateOfRegistration, opt => opt.MapFrom(src => src.DateOfRegistryDateOnly))
            //    .ForMember(dest => dest.InformationAboutTheTechnicalInspection, opt => opt.MapFrom(src => src.InformationAboutTheTechnicalInspectionDateOnly));
            //CreateMap<ReportPdoDto, ReportPdoViewModel>();
            //CreateMap<SubjectDto, SubjectViewModel>();

            // WEB to Services
            //CreateMap<JournalPdoViewModel, JournalPdoDto>();
            //CreateMap<PdoViewModel, PdoDto>();
            //CreateMap<SubjectViewModel, SubjectDto>();

        }

    }
}
