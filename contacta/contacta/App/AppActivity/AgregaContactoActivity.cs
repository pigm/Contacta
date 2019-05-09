using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using contacta.App.AppPresenter.PresenterActivity;
using contacta.App.AppUtils;
using contacta.data.common.Models.Cosmos;

namespace contacta.App.AppActivity
{
    /// <summary>
    /// Agrega contacto activity.
    /// </summary>
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme.Splash", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class AgregaContactoActivity : Activity
    {
        List<ContactoRealm> dataContacto = AndroidDataManager.RealmInstance.All<ContactoRealm>().ToList();
        EditText txtNombre, txtEmail, txtTelefono, txtEmpresa, txtCargo;
        ImageButton btnGrabarContacto, btnCancelarContacto;
        LinearLayout llMensajeError, llBtnAtras;
        RelativeLayout rlContactosPendientes;
        TextView lblErrorUps, lblCountPendientes;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_agregacontacto);
            txtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtTelefono = FindViewById<EditText>(Resource.Id.txtTelefono);
            txtEmpresa = FindViewById<EditText>(Resource.Id.txtEmpresa);
            txtCargo = FindViewById<EditText>(Resource.Id.txtCargo);
            btnGrabarContacto = FindViewById<ImageButton>(Resource.Id.btnGrabarContacto);
            btnCancelarContacto = FindViewById<ImageButton>(Resource.Id.btnCancelarContacto);
            llMensajeError = FindViewById<LinearLayout>(Resource.Id.llMensajeError);
            llBtnAtras = FindViewById<LinearLayout>(Resource.Id.llBtnAtras);
            rlContactosPendientes = FindViewById<RelativeLayout>(Resource.Id.rlContactosPendientes);
            lblErrorUps = FindViewById<TextView>(Resource.Id.lblErrorUps);
            lblCountPendientes = FindViewById<TextView>(Resource.Id.lblCountPendientes);

            btnGrabarContacto.Click += delegate { AgregaContactoPresenter.AgregandoContacto(this,txtNombre,txtEmail,txtTelefono,txtEmpresa,txtCargo,llMensajeError, lblErrorUps); };
            btnCancelarContacto.Click += delegate { Finish(); };
            llBtnAtras.Click+=delegate { Finish(); };
        }

        /// <summary>
        /// Ons the resume.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            RefreshContador();
        }

        /// <summary>
        /// Refreshs the contador.
        /// </summary>
        public void RefreshContador()
        {
            if (dataContacto.Any())
            {
                rlContactosPendientes.Visibility = ViewStates.Visible;
                lblCountPendientes.Text = dataContacto.Count.ToString();
            }
            else
            {
                rlContactosPendientes.Visibility = ViewStates.Gone;
                lblCountPendientes.Text = "";
            }
        }
    }
}