using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Resources;
using XamarinApp.Services;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    /// <summary>
    ///     Registration view model
    /// </summary>
    public class RegistrationViewModel : BaseViewModel
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

        public string RePassword { get; set; }

        /// <summary>
        ///     Available commands
        /// </summary>
        public ICommand Register { get; }

        public ICommand RedirectToLoginPage { get; }

        /// <summary>
        ///     Default constructor
        /// </summary>
        public RegistrationViewModel()
        {
            FirebaseDbService = DependencyService.Get<IFirebaseDbService>();
            FirebaseAuthentication = DependencyService.Get<IFirebaseAuthentication>();

            Register = new Command(OnRegisterClicked);
            RedirectToLoginPage = new Command(OnRedirectToLoginPageClicked);

            IsBusy = false;
        }

        /// <summary>
        ///     On register click action
        /// </summary>
        ///
        /// <param name="obj">Object</param>
        private async void OnRegisterClicked(object obj)
        {
            IsBusy = true;

            if (Password == RePassword)
            {
                bool isRegistrationSuccessful = await FirebaseAuthentication.RegisterWithEmailAndPasswordAsync(Email, Password);

                if (isRegistrationSuccessful)
                {
                    var user = new User
                    {
                        Email = Email,
                        IsAdmin = false,
                        IsBlocked = false
                    };

                    await FirebaseDbService.AddUserInfo(user);
                    await FirebaseAuthentication.LoginWithEmailAndPasswordAsync(Email, Password);

                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    IsBusy = false;

                    await Application.Current.MainPage.DisplayAlert(AppContentText.RegistrationErrorTitle,
                        AppContentText.RegistrationError, AppContentText.OkButton);
                }
            }
            else
            {
                IsBusy = false;

                await Application.Current.MainPage.DisplayAlert(AppContentText.RegistrationErrorTitle,
                    AppContentText.PasswordsError, AppContentText.OkButton);
            }
        }

        /// <summary>
        ///     On redirect click action
        /// </summary>
        ///
        /// <param name="obj">Object</param>
        private void OnRedirectToLoginPageClicked(object obj)
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}