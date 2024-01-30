using Autofac;
using MediatR;
using System.Reflection;
using TestExecutionAec.Application.Commands;

namespace Susep.SARC.Application.Configurations
{
    public class MediatorModuleConfiguration : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(ProcessarDadosAecCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.Register<ServiceFactory>(context =>
            {
                IComponentContext componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

        }

    }

}

