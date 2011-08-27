namespace SilverlightTestNavigation
{
    using System.Windows;

    using Autofac;

    using Microsoft.Practices.Prism.AutofacExtensions;

    using SilverlightTestNavigation.View;

    public class Bootstrapper : AutofacBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<ShellView>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.RootVisual = (UIElement)Shell;   
        }

        protected override ContainerBuilder ConfigureContainer()
        {
            var containerBuilder = base.ConfigureContainer();

            containerBuilder.RegisterType<ShellView>();

            return containerBuilder;
        }
    }
}