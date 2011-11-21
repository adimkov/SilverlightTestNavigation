// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Module1SecondViewModel.cs" author="Anton Dimkov">
//   Copyright (c) Anton Dimkov 2011. All rights reserved.
// </copyright>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SilverlightTestNavigation.Module1.ViewModel
{
    using System.Linq;
    using System.Windows.Input;

    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Regions;

    using SilverlightTestNavigation.Common;
    using SilverlightTestNavigation.Common.ViewModel;

    public class Module1SecondViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        /// <remarks>DO NOT USE SERVICE LOCATOR!.</remarks>
        public Module1SecondViewModel()
        {
            NavigateToChildCommand = new DelegateCommand(NavigateToChildCommandExecute);
            ResetCommand = new DelegateCommand(ResetCommandExecute);
        }

        /// <summary>
        /// Gets or sets the navigate to child command.
        /// </summary>
        /// <value>
        /// The navigate to child command.
        /// </value>
        public ICommand NavigateToChildCommand { get; set; }

        /// <summary>
        /// Gets or sets the reset command.
        /// </summary>
        /// <value>
        /// The reset command.
        /// </value>
        public ICommand ResetCommand { get; set; }

        /// <summary>
        /// Executes the navigate to child command.
        /// </summary>
        private void NavigateToChildCommandExecute()
        {
            RegionManager.RequestNavigate(RegionNames.SecondRegion, "Module1NestedView");
        }

        /// <summary>
        /// Executes the reset command.
        /// </summary>
        private void ResetCommandExecute()
        {
            var region = RegionManager.Regions[RegionNames.SecondRegion];

            var activeViews = region.ActiveViews.ToList();

            foreach (var activeView in activeViews)
            {
                region.Deactivate(activeView);
            }
        }
    }
}