using Android.App;
using Android.OS;
using contacta.App.AppPresenter.PresenterDialog;

namespace contacta.App.AppDialog
{
    /// <summary>
    /// Loading dialog.
    /// </summary>
    [Activity(ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class LoadingDialog : Activity
    {
        static Dialog customDialog = null;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dialog_loading);
        }

        /// <summary>
        /// Views the dialogo loading.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void ViewDialogoLoadingAsync(Activity activity) { LoadingPresenter.ViewDialogo(activity, customDialog); }

        /// <summary>
        /// Closes the dialogo loading.
        /// </summary>
        public static void CloseDialogoLoading() { LoadingPresenter.CloseDialogo(); }
    }
}
