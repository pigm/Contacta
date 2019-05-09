using System;
using Android.App;
using Android.Widget;
using Android.Support.Design.Widget;
using contacta.App.AppUtils;
using contacta.App.AppDialog;
using Android.Content;
using contacta.App.AppActivity;
using Plugin.Connectivity;

namespace contacta.App.AppPresenter.PresenterActivity
{
    /// <summary>
    /// Home presenter.
    /// </summary>
    public class HomePresenter
    {
        /// <summary>
        /// Refreshs the view.
        /// </summary>
        /// <param name="lblOk">Lbl ok.</param>
        public static void RefreshView(TextView lblOk) 
        {
            if (AndroidDataManager.ViewMessageAddContact)
            {
                lblOk.Visibility = Android.Views.ViewStates.Visible;
                if (AndroidDataManager.StatusAddContact)
                {
                    lblOk.Text = "Contacto agregado, gracias";
                }
                else
                {
                    lblOk.Text = AndroidDataManager.MensajeAddContactBDLocal;                            
                }
            }
            else
            {
                lblOk.Visibility = Android.Views.ViewStates.Invisible;
            }
        }

        /// <summary>
        /// Snackbars the volver.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="llViewWeb">Ll view web.</param>
        public static void SnackbarVolver(Activity activity, LinearLayout llViewWeb)
        {
            Snackbar.Make(llViewWeb, "Estas seguro(a) que deseas salir de la app", Snackbar.LengthLong)
                .SetAction("OK", (view) => {
                    activity.FinishAffinity();
                })
                .Show();
        }

        public static void GoAddContact(Activity activity)
        {
            AndroidDataManager.ViewMessageAddContact = false;
            ///if (CrossConnectivity.Current.IsConnected)
            activity.StartActivity(new Intent(activity, typeof(AgregaContactoActivity)));            
            ///else
            ///    ActivarWifiDialog.ViewDialogoActivarWifi(activity);
        }
    }
}
