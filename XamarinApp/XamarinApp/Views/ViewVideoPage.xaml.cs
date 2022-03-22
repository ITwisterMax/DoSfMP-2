using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    /// <summary>
    ///     View video page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewVideoPage : ContentPage
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public ViewVideoPage(string videoUrl)
        {
            var viewModel = new ViewVideoViewModel();
            viewModel.Video = videoUrl;
            BindingContext = viewModel;

            InitializeComponent();
        }
    }
}