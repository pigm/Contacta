using System;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Util;
using contacta.App.AppUtils;
using contacta.data.common.Models.Cosmos;
using contacta.services.cosmos.common.Delegate;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;

namespace contacta.App.AppService
{
    /// <summary>
    /// Item receiver.
    /// </summary>
    [BroadcastReceiver]
    public class ItemReceiver : BroadcastReceiver
    {
        ActivityManager am;
        ComponentName cn;
        Context ctx;
        /// <summary>
        /// Ons the receive.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="intent">Intent.</param>
        public override async void OnReceive(Context context, Intent intent)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                ctx = context;
                am = (ActivityManager)context.GetSystemService(Context.ActivityService);
                cn = am.GetRunningTasks(1).ElementAt(0).TopActivity;
                await ProcesarContactos();
            }
        }

        /// <summary>
        /// Procesars the denuncias.
        /// </summary>
        /// <returns>The denuncias.</returns>
        async Task ProcesarContactos()
        {
            try
            {
                var contactosProcesar = AndroidDataManager.RealmInstance.All<ContactoRealm>().ToList();
                if (CrossConnectivity.Current.IsConnected)
                {
                    if (contactosProcesar.Any())
                    {
                        foreach (ContactoRealm contacto in contactosProcesar)
                        {
                            string json = JsonConvert.SerializeObject(contacto);
                            Contacto contactoCosmos = JsonConvert.DeserializeObject<Contacto>(json);
                            CosmosDelegate instanceCosmos = CosmosDelegate.Instance;
                            var addContanctAsync = await instanceCosmos.AddContact(contactoCosmos);

                            if (addContanctAsync.Success)
                            {
                                using (var trans = AndroidDataManager.RealmInstance.BeginWrite())
                                {
                                    AndroidDataManager.RealmInstance.Remove(contacto);
                                    trans.Commit();
                                }
                            }                         
                        }
                    }
                    Refreshindicator();
                }
            }
            catch (Exception ex)
            {
                Log.Info("ProcesarContactos", ex.Message);
            }
        }


        /// <summary>
        /// Refreshindicator this instance.
        /// </summary>
        void Refreshindicator(){
            if (cn.ToString().Contains("AgregaContactoActivity"))
            {
                ActivityContexts.agregaContactoActivity.RefreshContador();
            }
        }
    }
}