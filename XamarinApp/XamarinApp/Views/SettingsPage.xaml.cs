using System;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Services;
using XamarinApp.Settings;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    /// <summary>
    ///     Settings page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        /// <summary>
        ///     Settings view model
        /// </summary>
        private readonly SettingsViewModel SettingsViewModel;

        /// <summary>
        ///     Firebase database instance
        /// </summary>
        private readonly IFirebaseDbService FirebaseDbService;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public SettingsPage()
        {
            SettingsViewModel = new SettingsViewModel();
            FirebaseDbService = DependencyService.Get<IFirebaseDbService>();

            InitializeComponent();

            AdminPanel.IsVisible = SettingsViewModel.CurrentUser.IsAdmin;

            // Add available languages
            foreach (string language in SettingsViewModel.Languages.Keys)
            {
                LanguagePicker.Items.Add(language);
            }

            // Add available emails
            foreach (string emailToBan in SettingsViewModel.UserEmails)
            {
                UserPicker.Items.Add(emailToBan);
            }
        }

        /// <summary>
        ///     On language change actions
        /// </summary>
        ///
        /// <param name="sender">Senders</param>
        /// <param name="e">Arguments</param>
        public void OnLanguageChanged(object sender, EventArgs e)
        {
            if (sender != null && ! ((sender as Picker).SelectedItem).Equals(SettingsViewModel.CurrentLanguage))
            {
                DefaultSettings.Language = SettingsViewModel.Languages[LanguagePicker.Items[LanguagePicker.SelectedIndex]];
                Preferences.Set("Language", DefaultSettings.Language);
                MessagingCenter.Send(this, "LanguageChanged");
            }
        }

        /// <summary>
        ///     On ban button click action
        /// </summary>
        ///
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        private void Button_OnClicked(object sender, EventArgs e)
        {
            string userEmailToBan = (string) UserPicker.SelectedItem;

            if (string.IsNullOrWhiteSpace(userEmailToBan))
            {
                return;
            }

            FirebaseDbService.BanUser(userEmailToBan);
        }
    }
}