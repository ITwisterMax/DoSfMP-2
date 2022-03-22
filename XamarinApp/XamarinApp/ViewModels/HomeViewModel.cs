using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Services;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    /// <summary>
    ///     Home view model
    /// </summary>
    public class HomeViewModel : BaseViewModel
    {
        /// <summary>
        ///     Computers
        /// </summary>
        public List<Computer> Computers { get; set; }

        /// <summary>
        ///     Views visibilities
        /// </summary>
        public bool IsVisibleListView { get; set; }

        public bool IsVisibleGridView { get; set; }

        /// <summary>
        ///     Available commands
        /// </summary>
        public ICommand ChangeView { get; }

        public ICommand RedirectToAddComputerPage { get; }

        /// <summary>
        ///     Default constructor
        /// </summary>
        public HomeViewModel()
        {
            var firebaseDbService = DependencyService.Get<IFirebaseDbService>();

            ChangeView = new Command(OnChangeView);
            RedirectToAddComputerPage = new Command(OnAddComputer);

            if (Filters.isFilter)
            {
                Computers = firebaseDbService.GetComputersWithFilters();
            }    
            else
            {
                Computers = firebaseDbService.GetAllComputers();
            }

            IsVisibleListView = ViewControlService.IsVisibleListView;
            IsVisibleGridView = ! ViewControlService.IsVisibleListView;
        }

        /// <summary>
        ///     On change view action
        /// </summary>
        ///
        /// <param name="obj">Object</param>
        private void OnChangeView(object obj)
        {
            ViewControlService.IsVisibleListView = ! ViewControlService.IsVisibleListView;
                
            Application.Current.MainPage = new AppShell();
        }

        /// <summary>
        ///     On add computer click action
        /// </summary>
        ///
        /// <param name="obj">Object</param>
        private async void OnAddComputer(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddComputerPage));
        }
    }
}