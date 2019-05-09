using System;
using System.Threading.Tasks;
using contacta.data.common.Models;
using contacta.data.common.Models.Cosmos;
using contacta.services.cosmos.common.Properties;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace contacta.services.cosmos.common.Delegate
{
    /// <summary>
    /// Cosmos delegate.
    /// </summary>
    public class CosmosDelegate
    {
        static DocumentClient clientDocument;
        static CosmosDelegate instance = null;
        static readonly FeedOptions DefaultOptionsOneResult = new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true };


        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static CosmosDelegate Instance
        {
            get
            {
                if (instance == null)
                    instance = new CosmosDelegate();

                return instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WalmartScanCL_Servicios.Delegate.CosmosDbDelegate"/> class.
        /// </summary>
        public CosmosDelegate()
        {
            StartCosmos();
        }

        /// <summary>
        /// Prepares the collections.
        /// </summary>
        void StartCosmos()
        {
            clientDocument = new DocumentClient(new Uri(ConfigProperties.COSMOSDB_URI), ConfigProperties.COSMOSDB_PRINCIPAL_KEY);
        }

        /// <summary>
        /// Adds the contact.
        /// </summary>
        /// <returns>The contact.</returns>
        /// <param name="contacto">Contacto.</param>
        public async Task<CommonResponse> AddContact(Contacto contacto)
        {

            CommonResponse result = new CommonResponse();
            if (GetNetworkStatus())
            {
                try
                {
                    Document response = await clientDocument.CreateDocumentAsync(
                                                UriFactory.CreateDocumentCollectionUri(ConfigProperties.COSMOSDB
                                                                                       , ConfigProperties.COSMOSDB_CONTACTO), contacto);
                    if (response.Id != null)
                    {
                        result.Success = true;
                        result.Response = JsonConvert.DeserializeObject<Contacto>(response.ToString());
                        result.StatusCode = 0;
                    }
                    else
                    {
                        result.Success = false;
                        result.Response = ConfigProperties.ERROR;
                        result.StatusCode = 999;
                    }

                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Response = e.Message;
                    result.StatusCode = -1;
                }

            }
            else
            {
                result.Success = false;
                result.Response = ConfigProperties.NOTCONNECTION;
                result.StatusCode = 1000;
            }

            return result;

        }

        /// <summary>
        /// Gets the network status.
        /// </summary>
        /// <returns><c>true</c>, if network status was gotten, <c>false</c> otherwise.</returns>
        private bool GetNetworkStatus()
        {
            return CrossConnectivity.Current.IsConnected;
        }

    }
}
