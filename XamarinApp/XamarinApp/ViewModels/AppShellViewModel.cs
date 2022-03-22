using System.Collections.Generic;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Services;

namespace XamarinApp.ViewModels
{
    /// <summary>
    ///     App shell view model
    /// </summary>
    public class AppShellViewModel : BaseViewModel
    {
        /// <summary>
        ///     Firebase database instance
        /// </summary>
        private readonly IFirebaseDbService firebaseDbService;

        /// <summary>
        ///     Computers
        /// </summary>
        public List<Computer> Computers { get; set; }

        /// <summary>
        ///     Views visibilities
        /// </summary>
        public bool IsHorizontal { get; set; }

        public bool IsVertical { get; set; }

        /// <summary>
        ///     Default constructor
        /// </summary>
        public AppShellViewModel()
        {
            firebaseDbService = DependencyService.Get<IFirebaseDbService>();

            if (Filters.isFilter)
            {
                Computers = firebaseDbService.GetComputersWithFilters();
            }
            else
            {
                Computers = firebaseDbService.GetAllComputers();
            }

            IsHorizontal = ViewControlService.IsHorizontal;
            IsVertical = ! ViewControlService.IsHorizontal;
        }
    }
}