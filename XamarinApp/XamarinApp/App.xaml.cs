using Xamarin.Forms;
using XamarinApp.Views;

namespace XamarinApp
{
    /// <summary>
    ///     Application life cycle
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        /// <summary>
        ///     On application start
        /// </summary>
        protected override void OnStart()
        {
        }

        /// <summary>
        ///     On application sleep
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        ///     On application resume
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}
