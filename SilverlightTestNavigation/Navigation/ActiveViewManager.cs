namespace Microsoft.Practices.Prism.Regions
{
    using System.ComponentModel;
    using System.Windows;

    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// Manage active view mapping of region
    /// </summary>
    public class ActiveViewManager
    {
        /// <summary>
        /// Holds reference to ActiveViewMapperBehavior.
        /// </summary>
        private ActiveViewMapperBehavior _behavior;

        /// <summary>
        /// The region host control.
        /// </summary>
        private DependencyObject _hostControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveViewManager"/> class.
        /// </summary>
        /// <param name="hostControl">Control that host region</param>
        /// <param name="observableRegion">The region</param>
        public ActiveViewManager(DependencyObject hostControl, ObservableObject<IRegion> observableRegion)
        {
            HostControl = hostControl;
            ObservableRegion = observableRegion;
            ObservableRegion.PropertyChanged += ObservableRegionOnPropertyChanged;
            EnsureBehaviorAdded();
        }

        /// <summary>
        /// Gets host control of region
        /// </summary>
        public DependencyObject HostControl
        {
            get
            {
                return _hostControl;
            } 
            private set
            {
                _hostControl = value;
                Behavior.HostControl = value;
            }
        }

        /// <summary>
        /// Gets region for a host control
        /// </summary>
        public ObservableObject<IRegion> ObservableRegion { get; private set; }

        /// <summary>
        /// Gets ActiveViewMapperBehavior of region
        /// </summary>
        private ActiveViewMapperBehavior Behavior
        {
            get
            {
                if (_behavior == null)
                {
                    this._behavior = ServiceLocator.Current.GetInstance<ActiveViewMapperBehavior>();
                }

                return _behavior;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is enabled tracking active view
        /// </summary>
        public bool IsViewTrackingEnabled
        {
            get
            {
                return Behavior.IsEnabled;
            }

            set
            {
                Behavior.IsEnabled = value;
            }
        }

        /// <summary>
        /// Ensures that behavior added to region
        /// </summary>
        public void EnsureBehaviorAdded()
        {
            if (ObservableRegion.Value != null
                && !ObservableRegion.Value.Behaviors.ContainsKey(ActiveViewMapperBehavior.BehaviorKey))
            {
                ObservableRegion.Value.Behaviors.Add(ActiveViewMapperBehavior.BehaviorKey, Behavior);
            }
        }

        /// <summary>
        /// Handles events of observable region
        /// </summary>
        /// <param name="sender">Observable region</param>
        /// <param name="args">The arguments</param>
        private void ObservableRegionOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Value")
            {
                EnsureBehaviorAdded();
            }
        }
    }
}