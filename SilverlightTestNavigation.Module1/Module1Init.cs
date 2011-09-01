﻿namespace SilverlightTestNavigation.Module1
{
    using Autofac;

    using Microsoft.Practices.Prism.Regions;

    using SilverlightTestNavigation.Common.Modularity;
    using SilverlightTestNavigation.Module1.View;

    /// <summary>
    /// Module initializer of the Module.
    /// </summary>
    public class Module1Init : ModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleBase"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="regionManager">The region manager.</param>
        /// <remarks></remarks>
        public Module1Init(IContainer container, RegionManager regionManager)
            : base(container, regionManager)
        {
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public override void Initialize()
        {
            RegionManager.AddToRegion("MainRegion", new Module1View());
        }
    }
}