using System;
using Android.App;
using Realms;

namespace contacta.App.AppUtils
{
    /// <summary>
    /// Android data manager.
    /// </summary>
    public class AndroidDataManager
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:contacta.App.AppUtils.AndroidDataManager"/> status
        /// add contact.
        /// </summary>
        /// <value><c>true</c> if status add contact; otherwise, <c>false</c>.</value>
        public static bool StatusAddContact { get; set; }
        public static bool ViewMessageAddContact { get; set; }
        public static Dialog CustomDialog { get; set; }
        public static string MensajeAddContactBDLocal { get; set; }
        static Realm realm;
        /// <summary>
        /// Gets the realm instance.
        /// </summary>
        /// <value>The realm instance.</value>
        public static Realm RealmInstance
        {
            get
            {
                if (realm == null)
                {
                    try
                    {
                        RealmConfiguration config = new RealmConfiguration
                        {
                            SchemaVersion = 1,
                            ShouldDeleteIfMigrationNeeded = true
                        };
                        realm = Realm.GetInstance(config);
                    }
                    catch
                    {
                        realm = Realm.GetInstance();
                    }
                }
                return realm;
            }
        }
    }
}
