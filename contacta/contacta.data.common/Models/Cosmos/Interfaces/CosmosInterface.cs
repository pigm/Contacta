using Newtonsoft.Json;

namespace contacta.data.common.Models.Cosmos.Interfaces
{
    /// <summary>
    /// Cosmos interface.
    /// </summary>
    public abstract class CosmosInterface
    {
        [JsonProperty(PropertyName = "id")]
        abstract public string id { get; set; }

        [JsonProperty(PropertyName = "_rid")]
        abstract public string _rid { get; set; }

        [JsonProperty(PropertyName = "_self")]
        abstract public string _self { get; set; }

        [JsonProperty(PropertyName = "_etag")]
        abstract public string _etag { get; set; }

        [JsonProperty(PropertyName = "_attachments")]
        abstract public string _attachments { get; set; }

        [JsonProperty(PropertyName = "_ts")]
        abstract public int _ts { get; set; }
    }
}
