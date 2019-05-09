using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Util;
using contacta.App.AppActivity;

namespace contacta.App.AppPresenter.PresenterActivity
{
    /// <summary>
    /// Main presenter.
    /// </summary>
    public class MainPresenter
    {
        /// <summary>
        /// Inicios the app.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void InicioApp(Activity activity)
        {
            try
            {
                Task startupwork = new Task(() =>
                {
                    Task.Delay(4000).Wait();
                });
                startupwork.ContinueWith(t =>
                {
                    activity.StartActivity(new Intent(activity, typeof(HomeActivity)));
                }, TaskScheduler.FromCurrentSynchronizationContext());

                startupwork.Start();
            }
            catch (Exception ex)
            {
                Log.Info("start app ", ex.Message);
            }
        }
    }
}
