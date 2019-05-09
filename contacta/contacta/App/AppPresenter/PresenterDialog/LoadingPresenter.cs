using System;
using Android.App;
using contacta.App.AppUtils;

namespace contacta.App.AppPresenter.PresenterDialog
{
    /// <summary>
    /// Loading presenter.
    /// </summary>
    public class LoadingPresenter
    {
        /// <summary>
        /// Views the dialogo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="customDialog">Custom dialog.</param>
        public static void ViewDialogo(Activity activity, Dialog customDialog)
        {
            customDialog = new Dialog(activity, Resource.Style.MyThemeTranslucent);
            customDialog.SetCancelable(false);
            customDialog.SetContentView(Resource.Layout.dialog_loading);
            customDialog.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            customDialog.Show();
            AndroidDataManager.CustomDialog = customDialog;
            //return customDialog;
        }

        /// <summary>
        /// Closes the dialogo.
        /// </summary>
        public static void CloseDialogo()
        {
            AndroidDataManager.CustomDialog.Dismiss();
        }
    }
}
