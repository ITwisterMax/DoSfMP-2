using Xamarin.Forms;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    /// <summary>
    ///     Home horizontal view model
    /// </summary>
    class HomeHorizontalViewModel
    {
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
