namespace SilverlightTestNavigation.Module1.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Regions;

    using SilverlightTestNavigation.Common;
    using SilverlightTestNavigation.Common.ViewModel;
    using SilverlightTestNavigation.Module1.Model;

    /// <summary>
    /// View model for Navigation view.
    /// </summary>
    public class NavigationViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationViewModel"/> class.
        /// </summary>
        public NavigationViewModel()
        {
            LoadMenu();

            NavigationToCommand = new DelegateCommand<MenuItem>(NavigationToMethod);
        }

        /// <summary>
        /// Loads the menu.
        /// </summary>
        private void LoadMenu()
        {
            MenuItems = new ObservableCollection<MenuItem>();
            MenuItems.Add(new MenuItem("First window", "Module1View"));
            MenuItems.Add(new MenuItem("Second window", "Module1SecondView"));
        }

        /// <summary>
        /// Gets the navigation to command.
        /// </summary>
        public ICommand NavigationToCommand { get; private set; }

        /// <summary>
        /// Gets the menu items.
        /// </summary>
        public ObservableCollection<MenuItem> MenuItems { get; private set; }

        /// <summary>
        /// Executes command to navigate to view
        /// </summary>
        private void NavigationToMethod(MenuItem menuItem)
        {
            RegionManager.RequestNavigate(RegionNames.MainRegion, menuItem.ViewName);
        }
    }
}