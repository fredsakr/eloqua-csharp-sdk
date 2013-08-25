using System.Collections.Generic;
using System.IO;
using System.Net;
using Eloqua.Api.Bulk.Authentication;
using Eloqua.Api.Bulk.Models;
using Eloqua.Api.Bulk.Models.Imports;
using Eloqua.Api.Bulk.Models.Syncs;
using RestSharp;

namespace Eloqua.Api.Bulk.Clients.Accounts
{
    public class AccountImportClient
    {
        readonly BaseClient _client;

        public AccountImportClient(BaseClient client)
        {
            _client = client;
        }

        public Import CreateImport(Import import)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = "/account/import",
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

        public void ImportDataFromCsv(string importUri, string fileToUpload, string username, string password)
        {
            using (FileStream rdr = new FileStream(fileToUpload, FileMode.Open))
            {
                var req = (HttpWebRequest)WebRequest.Create(_client.Client.BaseUrl + importUri + "/data");
                req.Method = "POST";
                req.ContentLength = rdr.Length;
                req.ContentType = "text/csv";
                req.AllowWriteStreamBuffering = true;
                req.Headers.Add("Authorization", BasicAuthentication.BuildAuthHeader(username , password));

                using (Stream reqStream = req.GetRequestStream())
                {
                    byte[] inData = new byte[rdr.Length];

                    reqStream.Write(inData, 0, (int)rdr.Length);

                    rdr.Close();
                    req.GetResponse();
                }
            }
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
