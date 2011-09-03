namespace SilverlightTestNavigation.Module1
{
    using Autofac;

    using Microsoft.Practices.Prism.Regions;

    using SilverlightTestNavigation.Common;
    using SilverlightTestNavigation.Common.Modularity;
    using SilverlightTestNavigation.Module1.View;

    /// <summary>
    /// Module initializer of the Module.
    /// </summary>
    public class Module1Init : ModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Module1Init"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="regionManager">The region manager.</param>
        public Module1Init(IContainer container, IRegionManager regionManager)
            : base(container, regionManager)
        {
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public override void Initialize()
        {
            RegionManager.RegisterViewWithRegion<NavigationView>(RegionNames.NavigationRegion);
            
            RegionManager.RegisterViewWithRegion<Module1View>(RegionNames.MainRegion);
            RegionManager.RegisterViewWithRegion<Module1SecondView>(RegionNames.MainRegion);
        }
    }
}