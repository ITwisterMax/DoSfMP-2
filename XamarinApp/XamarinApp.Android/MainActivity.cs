using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using XamarinApp.Droid.Services;

namespace XamarinApp.Droid
{
    /// <summary>
    ///     Android application start point class
    /// </summary>
    [Activity(Label = "XamarinApplication", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /// <summary>
        ///     On application create
        /// </summary>
        ///
        /// <param name="savedInstanceState">Saved instance state</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Register firebase services
            Xamarin.Forms.DependencyService.Register<FirebaseDbService>();
            Xamarin.Forms.DependencyService.Register<FirebaseStorageService>();
            Xamarin.Forms.DependencyService.Register<FirebaseAuthentication>();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }

        /// <summary>
        ///     On request permissions result
        /// </summary>
        ///
        /// <param name="requestCode">Request code</param>
        /// <param name="permissions">Permissions</param>
        /// <param name="grantResults">Grant results</param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}