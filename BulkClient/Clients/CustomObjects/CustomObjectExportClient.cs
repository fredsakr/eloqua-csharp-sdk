using RestSharp;
using Eloqua.Api.Bulk.Models.Exports;
using Eloqua.Api.Bulk.Models.Syncs;

namespace Eloqua.Api.Bulk.Clients.CustomObjects
{
    public class CustomObjectExportClient
    {
        readonly BaseClient _client;

        public CustomObjectExportClient(BaseClient client)
        {
            _client = client;
        }

        public Export CreateExport(Export export, int customObjectId)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = string.Format("/customObject/{0}/export", customObjectId),
                RequestFormat = DataFormat.Json,
                RootElement = "export"
            };
            request.AddBody(export);

            return _client.Execute<Export>(request);
        }

        public Sync CreateSync(Sync sync)
        {
            return _client.Syncs.CreateSync(sync);
        }

        public IRestResponse ExportData(string exportUri)
        {
            return _client.JsonData.ExportData(exportUri);
        }
    }
}