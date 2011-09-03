namespace Microsoft.Practices.Prism.Regions
{
    using System.ComponentModel;
    using System.Windows;

    /// <summary>
    /// Extended region manager to enable map active view into navigation bar.
    /// </summary>
    public class ActiveRegionManager : RegionManager
    {
        /// <summary>
        /// Attached property to enable or disable mapping active view to navigation bar.
        /// </summary>
        public static readonly DependencyProperty IsViewTrackingEnabledProperty = DependencyProperty.RegisterAttached(
            "IsViewTrackingEnabled", typeof(bool), typeof(ActiveRegionManager), new PropertyMetadata(OnIsViewTrackingEnabledChanged));

        /// <summary>
        /// Attached property of ActiveViewManager.
        /// </summary>
        public static readonly DependencyProperty ActiveViewManagerProperty = DependencyProperty.RegisterAttached(
            "ActiveViewManager", typeof(ActiveViewManager), typeof(ActiveRegionManager), new PropertyMetadata(null));

        /// <summary>
        /// Sets value to ActiveViewManager property. 
        /// </summary>
        /// <param name="o">Host control.</param>
        /// <param name="value"><see cref="ActiveViewManager"/> that belongs to host controls.</param>
        public static void SetActiveViewManager(DependencyObject o, ActiveViewManager value)
        {
            o.SetValue(ActiveViewManagerProperty, value);
        }

        /// <summary>
        /// Gets value of ActiveViewManager property.
        /// </summary>
        /// <param name="o">Host control.</param>
        /// <returns><see cref="ActiveViewManager"/> that belongs to host controls.</returns>
        public static ActiveViewManager GetActiveViewManager(DependencyObject o)
        {
            return (ActiveViewManager)o.GetValue(ActiveViewManagerProperty);
        }

        /// <summary>
        /// Sets value of IsViewTrackingEnabled property.
        /// </summary>
        /// <param name="o">Host control.</param>
        /// <param name="value">Enable or disable view tracking.</param>
        public static void SetIsViewTrackingEnabled(DependencyObject o, bool value)
        {
            o.SetValue(IsViewTrackingEnabledProperty, value);
        }

        /// <summary>
        /// Gets value of IsViewTrackingEnabled property. 
        /// </summary>
        /// <param name="o">Host control.</param>
        /// <returns>Enabled or disabled view tracking.</returns>
        public static bool GetIsViewTrackingEnabled(DependencyObject o)
        {
            return (bool)o.GetValue(IsViewTrackingEnabledProperty);
        }

        /// <summary>
        /// Handles events of changing IsViewTrackingEnabled property.
        /// </summary>
        /// <param name="d">Host control.</param>
        /// <param name="e">Arguments of event.</param>
        private static void OnIsViewTrackingEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.IsInDesignTool)
            {
                return;
            }

            EnsureActiveViewManagerAssigned(d).IsViewTrackingEnabled = (bool)e.NewValue;
        }

        /// <summary>
        /// Ensures that <see cref="ActiveViewManager"/> assigned to host object.
        /// </summary>
        /// <param name="d">Host control.</param>
        /// <returns><see cref="ActiveViewManager"/> that belongs to host controls.</returns>
        private static ActiveViewManager EnsureActiveViewManagerAssigned(DependencyObject d)
        {
            var activeViewManager = GetActiveViewManager(d);
            if (activeViewManager == null)
            {
                var regionWrapper = GetObservableRegion(d);
                activeViewManager = new ActiveViewManager(d, regionWrapper);
                SetActiveViewManager(d, activeViewManager);
            }

            return activeViewManager;
        }
    }
}