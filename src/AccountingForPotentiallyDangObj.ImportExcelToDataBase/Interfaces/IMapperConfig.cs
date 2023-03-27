using AutoMapper;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.Interfaces
{
    public interface IMapperConfig
    {
        IMapper Mapper { get; }
    }
}
