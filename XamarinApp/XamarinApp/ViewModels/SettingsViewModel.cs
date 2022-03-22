using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Resources;
using XamarinApp.Services;
using XamarinApp.Settings;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    /// <summary>
    ///     Settings view model
    /// </summary>
    public class SettingsViewModel : BaseViewModel
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
        ///     All languages dictionary
        /// </summary>
        private readonly Dictionary<string, string> AllLanguages = new Dictionary<string, string>()
        {
            ["English"] = "en-US",
            ["Русский"] = "ru-RU"
        };

        /// <summary>
        ///     Languages dictionary
        /// </summary>
        public Dictionary<string, string> Languages { get; }

        /// <summary>
        ///     Available commands
        /// </summary>
        public ICommand LogOutCommand { get; }

        /// <summary>
        ///     Currebt settings
        /// </summary>
        public string CurrentLanguage => AllLanguages.First(x => x.Value == DefaultSettings.Language).Key;

        public string CurrentFontFamily => DefaultSettings.FontFamily;

        public string CurrentFontSize => DefaultSettings.FontSize.ToString(CultureInfo.InvariantCulture);

        /// <summary>
        ///     Users emails
        /// </summary>
        public List<string> UserEmails { get; set; } = new List<string>();
        
        /// <summary>
        ///     Current user
        /// </summary>
        public User CurrentUser { get; set; }

        /// <summary>
        ///     Deafault constructor
        /// </summary>
        public SettingsViewModel()
        {
            Languages = AllLanguages;

            FirebaseAuthentication = DependencyService.Get<IFirebaseAuthentication>();
            FirebaseDbService = DependencyService.Get<IFirebaseDbService>();

            LogOutCommand = new Command(OnLogOutClicked);

            CurrentUser = FirebaseDbService.GetCurrentUser();

            if (CurrentUser.IsAdmin)
            {
                var users = FirebaseDbService.GetAllUsers();

                foreach (var user in users.Where(user => user.Email != CurrentUser.Email))
                {
                    UserEmails.Add(user.Email);
                }
            }
        }

        /// <summary>
        ///     On log out click action
        /// </summary>
        ///
        /// <param name="obj">Object</param>
        private async void OnLogOutClicked(object obj)
        {
            bool isLogOutSuccessful = FirebaseAuthentication.SignOut();

            if (isLogOutSuccessful)
            {
                Application.Current.MainPage = new LoginPage();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(AppContentText.AuthErrorTitle,
                    AppContentText.AuthError, AppContentText.OkButton);
            }
        }
    }
}