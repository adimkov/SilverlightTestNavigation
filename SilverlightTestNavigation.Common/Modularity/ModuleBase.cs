namespace SilverlightTestNavigation.Common.Modularity
{
    using Autofac;

    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;

    /// <summary>
    /// Base class for modules
    /// </summary>
    /// <remarks></remarks>
    public abstract class ModuleBase : IModule
    {
        /// <summary>
        /// Gets the IoC container.
        /// </summary>
        /// <remarks>The container can be completed by derived module.</remarks>
        protected IContainer Container { get; private set; }

        /// <summary>
        /// Gets the region manager.
        /// </summary>
        protected RegionManager RegionManager { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleBase"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="regionManager">The region manager.</param>
        public ModuleBase(IContainer container, RegionManager regionManager)
        {
            Container = container;
            RegionManager = regionManager;
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public abstract void Initialize();
    }
}