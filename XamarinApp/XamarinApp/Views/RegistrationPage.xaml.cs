using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    /// <summary>
    ///     Registration page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public RegistrationPage()
        {
            var registrationViewModel = new RegistrationViewModel();
            BindingContext = registrationViewModel;

            InitializeComponent();
        }
    }
}