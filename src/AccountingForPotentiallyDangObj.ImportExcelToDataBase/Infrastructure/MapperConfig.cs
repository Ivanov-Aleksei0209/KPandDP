using AccountingForPotentiallyDangObj.ImportExcelToDataBase.Interfaces;
using AutoMapper;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.Infrastructure
{
    public class MapperConfig : IMapperConfig
    {
        public MapperConfig(Profile profile)
        {
            Mapper = new MapperConfiguration(m => m.AddProfile(profile)).CreateMapper();
        }

        public IMapper Mapper
        {
            get; private set;
        }
    }
}
