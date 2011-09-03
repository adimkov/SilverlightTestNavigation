namespace SilverlightTestNavigation.Module1.Model
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Menu item of navigation panel.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        public MenuItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="viewName">Name of the view.</param>
        public MenuItem(string title, string viewName)
        {
            this.Title = title;
            this.ViewName = viewName;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title{ get; set; }

        /// <summary>
        /// Gets or sets the name of the view.
        /// </summary>
        /// <value>
        /// The name of the view.
        /// </value>
        public string ViewName { get; set; }

        /// <summary>
        /// Gets the children.
        /// </summary>
        public ObservableCollection<MenuItem> Children { get; private set; }
    }
}