using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    /// <summary>
    ///     View image page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewImagePage : ContentPage
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public ViewImagePage(string imageUrl)
        {
            var viewModel = new ViewImageViewModel();
            viewModel.Image = imageUrl;
            BindingContext = viewModel;

            InitializeComponent();
        }
    }
}