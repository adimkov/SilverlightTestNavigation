namespace Microsoft.Practices.Prism.Regions
{
    /// <summary>
    /// Extension methods for <see cref="RegionManager"/> class.
    /// </summary>
    public static class RegionMangerExtensions
    {
        /// <summary>
        /// Registers the view with region.
        /// </summary>
        /// <typeparam name="T">Type of the region.</typeparam>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="regionName">Name of the region.</param>
        public static void RegisterViewWithRegion<T>(this RegionManager regionManager, string regionName)
        {
            regionManager.RegisterViewWithRegion(regionName, typeof(T));
        }    
    }
}