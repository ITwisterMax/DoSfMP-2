using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Resources;
using XamarinApp.Services;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    /// <summary>
    ///     Login view model
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        ///     Firebase authentication instance
        /// </summary>
        private readonly IFirebaseAuthentication FirebaseAuthentication;

        /// <summary>
        ///     Firebase database instance
        /// </summary>
        private readonly IFirebaseDbService FirebaseDbService;

        /// <summary>
        ///     User characteristics
        /// </summary>
        public string Email { get; set; }

        public string Password { get; set; }

        /// <summary>
        ///     Available commands
        /// </summary>
        public ICommand LoginCommand { get; }

        public ICommand RedirectToRegistrationPage { get; }

        /// <summary>
        ///     Default constructor
        /// </summary>
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RedirectToRegistrationPage = new Command(OnRedirectToRegistrationPageClicked);

            FirebaseAuthentication = DependencyService.Get<IFirebaseAuthentication>();
            FirebaseDbService = DependencyService.Get<IFirebaseDbService>();

            IsBusy = false;
        }

        /// <summary>
        ///     On log in click action
        /// </summary>
        ///
        /// <param name="obj">Object</param>
        private async void OnLoginClicked(object obj)
        {
            IsBusy = true;

            bool isAuthSuccessful = await FirebaseAuthentication.LoginWithEmailAndPasswordAsync(Email, Password);

            if (isAuthSuccessful)
            {
                var currentUser = FirebaseDbService.GetCurrentUser();

                if (currentUser.IsBlocked)
                {
                    FirebaseAuthentication.SignOut();

                    IsBusy = false;

                    await Application.Current.MainPage.DisplayAlert("Blocked",
                        "You are blocked!", AppContentText.OkButton);
                    Application.Current.MainPage = new LoginPage();
                }
                else
                {
                    Application.Current.MainPage = new AppShell();
                }
            }
            else
            {
                IsBusy = false;

                await Application.Current.MainPage.DisplayAlert(AppContentText.LogOutErrorTitle, 
                    AppContentText.LogOutError, AppContentText.OkButton);
            }
        }

        /// <summary>
        ///     On redirect click action
        /// </summary>
        ///
        /// <param name="obj">Object</param>
        private void OnRedirectToRegistrationPageClicked(object obj)
        {
            Application.Current.MainPage = new RegistrationPage();
        }
    }
}