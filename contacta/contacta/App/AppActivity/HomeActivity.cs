using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using contacta.App.AppPresenter.PresenterActivity;
using contacta.App.AppUtils;

namespace contacta.App.AppActivity
{
    /// <summary>
    /// Home activity.
    /// </summary>
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme.Splash", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class HomeActivity : Activity
    {
        ImageButton btnAgregar;
        ImageView imgOk;
        LinearLayout llHome;
        TextView lblOk;
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_home);
            btnAgregar = FindViewById<ImageButton>(Resource.Id.btnAgregar);
            imgOk = FindViewById<ImageView>(Resource.Id.imgOk);
            llHome = FindViewById<LinearLayout>(Resource.Id.llHome);
            lblOk = FindViewById<TextView>(Resource.Id.lblOk);
            btnAgregar.Click += delegate { HomePresenter.GoAddContact(this); };
        }

        /// <summary>
        /// Ons the resume.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            HomePresenter.RefreshView(lblOk);
        }

        /// <summary>
        /// Ons the back pressed.
        /// </summary>
        public override void OnBackPressed(){ HomePresenter.SnackbarVolver(this, llHome); }
    }
}
