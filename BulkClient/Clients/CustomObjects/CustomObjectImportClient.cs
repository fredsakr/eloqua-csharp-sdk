using System.Collections.Generic;
using Eloqua.Api.Bulk.Models;
using Eloqua.Api.Bulk.Models.Imports;
using Eloqua.Api.Bulk.Models.Syncs;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients.CustomObjects
{
    public class CustomObjectImportClient
    {
        readonly BaseClient _client;

        public CustomObjectImportClient(BaseClient client)
        {
            _client = client;
        }

        public Import CreateImport(Import import, int customObjectId)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = string.Format("/customObject/{0}/import", customObjectId),
                RequestFormat = DataFormat.Json,
                RootElement = "import"
            };
            request.AddBody(import);

            var response = _client.Execute<Import>(request);

            return response;
        }

        public Sync ImportData(string importUri, List<Dictionary<string, string>> data)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = importUri + "/data",
                RequestFormat = DataFormat.Json
            };
            request.AddBody(data);

            var sync = _client.Execute<Sync>(request);

            return sync;
        }

        public SearchResponse<SyncResult> CheckSyncResult(string syncUri)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = syncUri + "/results",
                RequestFormat = DataFormat.Json
            };

            var response = _client.Execute<SearchResponse<SyncResult>>(request);
            return response;
        }
    }
}
