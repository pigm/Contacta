using Realms;

namespace contacta.data.common.Models.Cosmos
{
    /// <summary>
    /// Contacto realm.
    /// </summary>
    public class ContactoRealm : RealmObject
    {
        public string nombre { get; set; }

        public string apellido { get; set; }

        public string email { get; set; }

        public string telefono { get; set; }

        public string empresa { get; set; }

        public string cargo { get; set; }

        public string fecha { get; set; }
    }
}
