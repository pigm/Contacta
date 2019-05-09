using Android.App;
using Android.OS;
using contacta.App.AppPresenter.PresenterDialog;

namespace contacta.App.AppDialog
{
    /// <summary>
    /// Activar wifi dialog.
    /// </summary>
    [Activity(ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivarWifiDialog : Activity
    {
        static Dialog customDialog = null;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dialog_activa_wifi);
        }

        /// <summary>
        /// Views the dialogo activar gps.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void ViewDialogoActivarWifi(Activity activity) { ActivarWifiPresenter.ViewMensajeDialogo(activity, customDialog); }
    }
}
