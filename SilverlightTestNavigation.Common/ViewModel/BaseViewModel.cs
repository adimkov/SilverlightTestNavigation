namespace SilverlightTestNavigation.Common.ViewModel
{
    using System.ComponentModel;

    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.ViewModel;
    using Microsoft.Practices.ServiceLocation;

    using IContainer = Autofac.IContainer;

    /// <summary>
    /// Base class for all view model.
    /// </summary>
    public abstract class BaseViewModel : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        /// <remarks>DO NOT USE SERVICE LOCATOR!.</remarks>
        protected BaseViewModel()
        {
            if (!DesignerProperties.IsInDesignTool)
            {
                RegionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
                Container = ServiceLocator.Current.GetInstance<IContainer>();
            }
        }

        /// <summary>
        /// Gets the region manager.
        /// </summary>
        public IRegionManager RegionManager { get; private set; }

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>The container.</value>
        public IContainer Container { get; set; }
    }
}