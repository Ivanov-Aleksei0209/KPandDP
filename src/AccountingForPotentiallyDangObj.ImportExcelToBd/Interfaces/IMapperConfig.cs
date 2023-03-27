using AutoMapper;

namespace AccountingForPotentiallyDangObj.ImportExcelToBd.Interfaces
{
    public interface IMapperConfig
    {
        IMapper Mapper { get; }
    }
}
