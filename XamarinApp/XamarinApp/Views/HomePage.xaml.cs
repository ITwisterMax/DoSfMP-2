using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.Services;

namespace XamarinApp.Views
{
    /// <summary>
    ///     Home page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public HomePage()
        {
            InitializeComponent();
            FlowListView.Init();
        }

        /// <summary>
        ///     On computer info item click
        /// </summary>
        ///
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        public async void OnItemClicked(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new ComputerDetailsPage(((Computer)e.Item).Id));
        }
    }
}