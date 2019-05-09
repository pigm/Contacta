using System;
using Android.App;
using Android.Content;
using Android.Widget;
using contacta.App.AppActivity;
using contacta.App.AppDialog;
using contacta.App.AppUtils;
using contacta.data.common.Models.Cosmos;
using contacta.services.cosmos.common.Delegate;

namespace contacta.App.AppPresenter.PresenterActivity
{
    /// <summary>
    /// Agrega contacto presenter.
    /// </summary>
    public class AgregaContactoPresenter
    {
        /// <summary>
        /// Agregandos the contacto.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static async void AgregandoContacto(Activity activity, EditText txtNombre, EditText txtEmail, EditText txtTelefono, EditText txtEmpresa, EditText txtCargo, LinearLayout llMensajeError, TextView lblErrorUps)
        {
            lblErrorUps.Text = "";
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                txtNombre.SetBackgroundResource(Resource.Drawable.shapeEditTextError);
                txtNombre.SetHintTextColor(Android.Support.V4.Content.ContextCompat.GetColorStateList(activity, Resource.Color.colorRojo));
                txtEmail.SetBackgroundResource(Resource.Drawable.shapeEditTextError);
                txtEmail.SetHintTextColor(Android.Support.V4.Content.ContextCompat.GetColorStateList(activity, Resource.Color.colorRojo));
                llMensajeError.Visibility = Android.Views.ViewStates.Visible;
            }
            else
            {
                LoadingDialog.ViewDialogoLoadingAsync(activity);
                txtNombre.SetBackgroundResource(Resource.Drawable.shapeEditText);
                txtNombre.SetHintTextColor(Android.Support.V4.Content.ContextCompat.GetColorStateList(activity, Resource.Color.colorGris));
                txtEmail.SetBackgroundResource(Resource.Drawable.shapeEditText);
                txtEmail.SetHintTextColor(Android.Support.V4.Content.ContextCompat.GetColorStateList(activity, Resource.Color.colorGris));
                llMensajeError.Visibility = Android.Views.ViewStates.Gone;
                Contacto contacto = new Contacto()
                {
                    nombre = txtNombre.Text,
                    apellido = txtNombre.Text,
                    email = txtEmail.Text,
                    telefono = txtTelefono.Text,
                    empresa = txtEmpresa.Text,
                    cargo = txtCargo.Text,
                    fecha = DateTime.Now.ToString()
                };

                CosmosDelegate instanceCosmos = CosmosDelegate.Instance;
                var addContanctAsync = await instanceCosmos.AddContact(contacto);

                if (addContanctAsync.Success) 
                {
                    AndroidDataManager.StatusAddContact = true;
                    AndroidDataManager.ViewMessageAddContact = true;
                    if (AndroidDataManager.CustomDialog != null)
                        LoadingDialog.CloseDialogoLoading();                        
                }
                else
                {
                    AndroidDataManager.StatusAddContact = false;
                    AndroidDataManager.ViewMessageAddContact = true;
                    if (AndroidDataManager.CustomDialog != null)
                        LoadingDialog.CloseDialogoLoading();

                    if (addContanctAsync.StatusCode == 1000)
                    {
                        ContactoRealm contactoRealm = new ContactoRealm()
                        {
                            nombre = txtNombre.Text,
                            apellido = txtNombre.Text,
                            email = txtEmail.Text,
                            telefono = txtTelefono.Text,
                            empresa = txtEmpresa.Text,
                            cargo = txtCargo.Text,
                            fecha = DateTime.Now.ToString()
                        };
                        AndroidDataManager.RealmInstance.Write(() =>
                        {
                            AndroidDataManager.RealmInstance.Add(contactoRealm);
                        });
                        AndroidDataManager.MensajeAddContactBDLocal = "Ups! Hay problemas de conexión, contacto agregado localmente";
                    }
                    else
                    {
                        CleanEditText(txtNombre, txtEmail, txtTelefono, txtEmpresa, txtCargo);
                        lblErrorUps.Text = "Ups! Ocurrio un problema, por favor intenta nuevamente";
                    }
                }
                activity.StartActivity(new Intent(activity, typeof(HomeActivity)));
            }
        }

        /// <summary>
        /// Cleans the edit text.
        /// </summary>
        /// <param name="txtNombre">Text nombre.</param>
        /// <param name="txtEmail">Text email.</param>
        /// <param name="txtTelefono">Text telefono.</param>
        /// <param name="txtEmpresa">Text empresa.</param>
        /// <param name="txtCargo">Text cargo.</param>
        public static void CleanEditText(EditText txtNombre, EditText txtEmail, EditText txtTelefono, EditText txtEmpresa, EditText txtCargo)
        {
            txtNombre.Text = "";
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtEmpresa.Text = "";
            txtCargo.Text = "";
        }
    }
}
