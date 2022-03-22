using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    /// <summary>
    ///     Computer details page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComputerDetailsPage : ContentPage
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public ComputerDetailsPage(string id)
        {
            var viewModel = new ComputerDetailsViewModel(id);
            BindingContext = viewModel;

            InitializeComponent();
        }
    }
}