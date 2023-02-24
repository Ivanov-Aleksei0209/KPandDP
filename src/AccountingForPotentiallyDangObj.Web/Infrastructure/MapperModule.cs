using AccountingForPotentiallyDangObj.Web.Interfaces;
using Autofac;

namespace AccountingForPotentiallyDangObj.Web.Infrastructure
{
    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MapperConfig>().As<IMapperConfig>().WithParameter("profile", new MapperProfile());
        }
    }
}
