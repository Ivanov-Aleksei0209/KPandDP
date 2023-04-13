using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using AccountingForPotentiallyDangObj.Web.Services;
using Autofac;

namespace AccountingForPotentiallyDangObj.Web.Infrastructure
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JournalPdoService>().As<IJournalPdoService>();
            builder.RegisterType<PdoService>().As<IPdoService>();
            builder.RegisterType<SubjectService>().As<ISubjectService>();
            builder.RegisterType<InspectorService>().As<IInspectorService>();
            //builder.RegisterType<TechnicalConditional>().As<ITechnicalConditionalService>();
        }
    }
}
