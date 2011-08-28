namespace Microsoft.Practices.Prism.Regions
{
    using System.Collections.Specialized;

    /// <summary>
    /// Mapping in the browser navigation bar an active view in a region.
    /// </summary>
    public class ActiveViewMapperBehavior : RegionBehavior
    {
        /// <summary>
        /// The key of behavior.
        /// </summary>
        public const string BehaviorKey = "ActiveViewMapperBehavior";

        /// <summary>
        /// Holds reference to navigation bar.
        /// </summary>
        private INavigationBar _navigatioBar;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveViewMapperBehavior"/> class. 
        /// </summary>
        /// <param name="navigatioBar">
        /// Navigation bar.
        /// </param>
        public ActiveViewMapperBehavior(INavigationBar navigatioBar)
        {
            _navigatioBar = navigatioBar;
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
        }

        /// <summary>
        /// Handles event of changing active view collection.
        /// </summary>
        /// <param name="sender">The region.</param>
        /// <param name="args">The arguments.</param>
        private void ActiveViewsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            string newViewName = string.Empty;
            string oldViewName = string.Empty;
            
            if (args.NewItems.Count > 0)
            {
                 newViewName = args.NewItems[0].GetType().Name;
            }

            if (args.OldItems.Count > 0)
            {
                oldViewName = args.OldItems[0].GetType().Name;
            }

            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    _navigatioBar.AddFragment(newViewName);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    _navigatioBar.RemoveFragment(oldViewName);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    _navigatioBar.ReplaceFragment(oldViewName, newViewName);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    _navigatioBar.ClearFragments();
                    break;
            }
        }
    }
}