using Android.App;
using Android.Content;
using Android.OS;
using contacta.App.AppPresenter.PresenterActivity;
using contacta.App.AppService;

namespace contacta
{
    /// <summary>
    /// Main activity.
    /// </summary>
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            BroadcastProduct();
            SetContentView(Resource.Layout.splash);
            MainPresenter.InicioApp(this);
        }

        /// <summary>
        /// Broadcasts the product.
        /// </summary>
        void BroadcastProduct()
        {
            Intent i = new Intent(this, typeof(ItemReceiver));
            PendingIntent pi = PendingIntent.GetBroadcast(this, 0, i, 0);
            AlarmManager alarmManager = (AlarmManager)GetSystemService(AlarmService);
            alarmManager.SetInexactRepeating(AlarmType.ElapsedRealtime, SystemClock.CurrentThreadTimeMillis(),
             20000, pi);
        }
    }
}

