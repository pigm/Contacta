using contacta.data.common.Models.Cosmos.Interfaces;
using Newtonsoft.Json;

namespace contacta.data.common.Models.Cosmos
{
    /// <summary>
    /// Contacto.
    /// </summary>
    public class Contacto: CosmosInterface
    {
        [JsonProperty(PropertyName = "nombre")]
        public string nombre { get; set; }

        [JsonProperty(PropertyName = "apellido")]
        public string apellido { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }

        [JsonProperty(PropertyName = "telefono")]
        public string telefono { get; set; }

        [JsonProperty(PropertyName = "empresa")]
        public string empresa { get; set; }

        [JsonProperty(PropertyName = "cargo")]
        public string cargo { get; set; }

        [JsonProperty(PropertyName = "fecha")]
        public string fecha { get; set; }

        [JsonProperty(PropertyName = "id")]
        public override string id { get; set; }

        [JsonProperty(PropertyName = "_rid")]
        public override string _rid { get; set; }

        [JsonProperty(PropertyName = "_self")]
        public override string _self { get; set; }

        [JsonProperty(PropertyName = "_etag")]
        public override string _etag { get; set; }

        [JsonProperty(PropertyName = "_attachments")]
        public override string _attachments { get; set; }

        [JsonProperty(PropertyName = "_ts")]
        public override int _ts { get; set; }
    }
}
