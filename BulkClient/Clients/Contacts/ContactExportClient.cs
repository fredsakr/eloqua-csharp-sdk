using RestSharp;
using Eloqua.Api.Bulk.Models.Exports;
using Eloqua.Api.Bulk.Models.Syncs;

namespace Eloqua.Api.Bulk.Clients.Contacts
{
    public class ContactExportClient
    {
        readonly BaseClient _client;

        public ContactExportClient(BaseClient client)
        {
            _client = client;
        }

        public Export CreateExport(Export export)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = "/contact/export",
                RequestFormat = DataFormat.Json,
                RootElement = "export"
            };
            request.AddBody(export);

            return _client.Execute<Export>(request);
        }

        public Sync CreateSync(Sync sync)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = "/sync",
                RequestFormat = DataFormat.Json
            };
            request.AddBody(sync);

            return _client.Execute<Sync>(request);
        }

        public IRestResponse GetExportData(string exportUri)
        {
            var request = new RestRequest
            {
                Resource = exportUri + "/data",
                RequestFormat = DataFormat.Json
            };

            return _client.Execute(request);
        }
    }
}