using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    /// <summary>
    ///     Login page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public LoginPage()
        {
            var loginViewModel = new LoginViewModel();
            BindingContext = loginViewModel;

            InitializeComponent();
        }
    }
}