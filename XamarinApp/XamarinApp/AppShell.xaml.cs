using System;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Resources;
using XamarinApp.Services;
using XamarinApp.Views;

namespace XamarinApp
{
    /// <summary>
    ///     Main view class
    /// </summary>
    public partial class AppShell : Shell
    {
        /// <summary>
        ///     Firebase authentication instance
        /// </summary>
        private readonly IFirebaseAuthentication FirebaseAuthentication;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public AppShell()
        {
            OnSizeAllocated(Application.Current.MainPage.Width, Application.Current.MainPage.Height);

            // Register routes
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(HomePageHorizontal), typeof(HomePageHorizontal));
            Routing.RegisterRoute(nameof(FilterPage), typeof(FilterPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(AddComputerPage), typeof(AddComputerPage));
            Routing.RegisterRoute(nameof(ComputerDetailsPage), typeof(ComputerDetailsPage));

            // On language change action
            MessagingCenter.Subscribe<SettingsPage>(this, "LanguageChanged",
                (sender) =>
                {
                    Application.Current.MainPage = new AppShell();
                });

            FirebaseAuthentication = DependencyService.Get<IFirebaseAuthentication>();
        }

        /// <summary>
        ///     On size change
        /// </summary>
        ///
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            ViewControlService.IsHorizontal = width > height ? true : false;

            InitializeComponent();
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

        /// <summary>
        ///     On log out click action
        /// </summary>
        ///
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        private async void OnLogOutClicked(object sender, EventArgs args)
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