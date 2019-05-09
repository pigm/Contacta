using Android.App;
using Android.Content;
using Android.Widget;

namespace contacta.App.AppPresenter.PresenterDialog
{
    /// <summary>
    /// Activar wifi presenter.
    /// </summary>
    public class ActivarWifiPresenter
    {
        /// <summary>
        /// Views the mensaje dialogo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="customDialog">Custom dialog.</param>
        public static void ViewMensajeDialogo(Activity activity, Dialog customDialog)
        {

            customDialog = new Dialog(activity, Resource.Style.MyThemeTranslucent);
            customDialog.SetCancelable(false);
            customDialog.SetContentView(Resource.Layout.dialog_activa_wifi);
            Button btnActivarWifi = customDialog.FindViewById<Button>(Resource.Id.btnActivarWifi);
            btnActivarWifi.Click += delegate { ActivarWifiPresenter.ActivarWifi(activity, customDialog); };           
            customDialog.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            customDialog.Show();
        }



        /// <summary>
        /// Activars the gps.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="customDialog">Custom dialog.</param>
        private static void ActivarWifi(Activity activity, Dialog customDialog)
        {
            customDialog.Dismiss();
            activity.StartActivity(new Intent(Android.Provider.Settings.ActionWifiSettings));
        }
    }
}
