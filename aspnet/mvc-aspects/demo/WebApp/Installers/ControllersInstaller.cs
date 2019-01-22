using System.Web.Mvc;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Model;
using WebApp.Facades;
using WebApp.Services;

namespace WebApp.Installers
{
    using Plumbing;
    using System.Web.Hosting;

    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            container.Register(Component.For<IMailServiceFactory>().AsFactory());

            if (HostingEnvironment.IsDevelopmentEnvironment)
            {
                container.Register(
                    Component.For<IMailService>()
                        .ImplementedBy<DebugMailService>()
                        .Named("DebugMailService")
                        .LifestyleTransient());
            }
            else
            {
                container.Register(
                    Component.For<IMailService>()
                        .ImplementedBy<MailService>()
                        .Named("MailService")
                        .LifestyleTransient());
            }

            container.Register(
                Component.For<MailSettings>()
                    .ImplementedBy<MailSettings>()
                    .LifestyleTransient());

            container.Register(
                Component.For<MainFacade>()
                    .ImplementedBy<MainFacade>()
                    .LifestylePerWebRequest());

            container.Register(
                Component.For<IProductListQuery>()
                    .ImplementedBy<ProductListQuery>()
                    .LifestylePerWebRequest());

            container.Register(
                Component.For<DemoContext>()
                    .ImplementedBy<DemoContext>()
                    .LifestylePerWebRequest());

            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<IController>().
                    If(c => c.Name.EndsWith("Controller")).
                    LifestyleTransient());

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }
}