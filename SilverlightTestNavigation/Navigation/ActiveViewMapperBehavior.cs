namespace Microsoft.Practices.Prism.Regions
{
    using System.Collections.Specialized;
    using System.Linq;
    using System.Windows;

    using Microsoft.Practices.Prism.Regions.Behaviors;

    /// <summary>
    /// Mapping in the browser navigation bar an active view in a region.
    /// </summary>
    public class ActiveViewMapperBehavior : RegionBehavior, IHostAwareRegionBehavior
    {
        /// <summary>
        /// The key of behavior.
        /// </summary>
        public const string BehaviorKey = "ActiveViewMapperBehavior";

        /// <summary>
        /// The fragment builder.
        /// </summary>
        private readonly IFragmentBuilder _fragmentBuilder;

        /// <summary>
        /// Holds reference to navigation bar.
        /// </summary>
        private readonly INavigationBar _navigatioBar;

        private DependencyObject _hostControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveViewMapperBehavior"/> class.
        /// </summary>
        /// <param name="navigatioBar">Navigation bar.</param>
        /// <param name="fragmentBuilder">The fragment builder.</param>
        public ActiveViewMapperBehavior(INavigationBar navigatioBar, IFragmentBuilder fragmentBuilder)
        {
            _navigatioBar = navigatioBar;
            _fragmentBuilder = fragmentBuilder;
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.DependencyObject"/> that the <see cref="T:Microsoft.Practices.Prism.Regions.IRegion"/> is attached to.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Windows.DependencyObject"/> that the <see cref="T:Microsoft.Practices.Prism.Regions.IRegion"/> is attached to.
        ///             This is usually a <see cref="T:System.Windows.FrameworkElement"/> that is part of the tree.
        /// </value>
        public DependencyObject HostControl
        {
            get
            {
                return _hostControl;
            }

            set
            {
                _hostControl = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether enabled or disabled mapping of active view in navigation bar.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Attaches behavior to region.
        /// </summary>
        protected override void OnAttach()
        {
            Region.ActiveViews.CollectionChanged += ActiveViewsOnCollectionChanged;
            ((FrameworkElement)HostControl).Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var aciveView = Region.ActiveViews.FirstOrDefault();
            if (aciveView != null)
            {
                _fragmentBuilder.ActiveViewInRegion(aciveView.GetType().Name, Region.Name);
            }

            FlipFragments();
        }

        /// <summary>
        /// Handles event of changing active view collection.
        /// </summary>
        /// <param name="sender">The region.</param>
        /// <param name="args">The arguments.</param>
        private void ActiveViewsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var newViewName = args.NewItems[0].GetType().Name;
                    _fragmentBuilder.ActiveViewInRegion(newViewName, Region.Name);
                    break;
                case NotifyCollectionChangedAction.Remove:
                case NotifyCollectionChangedAction.Reset:
                    _fragmentBuilder.DeactivateRegion(Region.Name);
                    break;
            }

            FlipFragments();
        }

        /// <summary>
        /// Flips the fragments.
        /// </summary>
        private void FlipFragments()
        {
            _navigatioBar.ClearFragments();
            foreach (var fragment in _fragmentBuilder.BuildFragments())
            {
                _navigatioBar.AddFragment(fragment);
            }
        }
    }
}