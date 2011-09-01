namespace SilverlightTestNavigation
{
    using System;
    using System.Windows;

    using Autofac;

    using Microsoft.Practices.Prism.AutofacExtensions;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;

    using SilverlightTestNavigation.View;

    /// <summary>
    /// Application bootstrapper
    /// </summary>
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
            containerBuilder.RegisterType<BrowserNavigationBar>().As<INavigationBar>();
            containerBuilder.Register(x => Container).As<IContainer>();
            return containerBuilder;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var moduleCatalog = Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(
                new Uri("/SilverlightTestNavigation;component/ModulesCatalog.xaml", UriKind.Relative));

            return moduleCatalog;
        }
    }
}