using AccountingForPotentiallyDangObj.Web.Interfaces;
using AccountingForPotentiallyDangObj.Web.Service;
using Autofac;

namespace AccountingForPotentiallyDangObj.Web.Infrastructure
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InspectorService>().As<IInspectorService>();
        }
    }
}
