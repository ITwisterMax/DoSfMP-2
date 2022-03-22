using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;

namespace XamarinApp.Droid
{
    /// <summary>
    ///     Launch screen class
    /// </summary>
    [Activity(Label = "XamarinApplication", Icon = "@mipmap/icon", MainLauncher = true, Theme = "@style/CustomTheme.Launch", NoHistory = true)]
    public class LaunchActivity : Activity
    {
        /// <summary>
        ///     On application create
        /// </summary>
        ///
        /// <param name="savedInstanceState">Saved instance state</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        /// <summary>
        ///     Start launch screen
        /// </summary>
        protected override async void OnResume()
        {
            base.OnResume();

            await SimulateStartUp();
        }

        /// <summary>
        ///     Create Task
        /// </summary>
        ///
        /// <returns>Task</returns>
        private async Task SimulateStartUp()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}