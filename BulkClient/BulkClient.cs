using Eloqua.Api.Bulk.Clients.Contacts;
using Eloqua.Api.Bulk.Clients.CustomObjects;
using Eloqua.Api.Bulk.Models.Login;
using RestSharp;

namespace Eloqua.Api.Bulk
{
    public class BulkClient
    {
        public BulkClient(string site, string user, string password, string baseUrl)
        {
            BaseClient = new BaseClient(site, user, password, baseUrl);
        }

        public static AccountInfo GetAccountInfo(string site, string user, string password)
        {
            var client = new BaseClient(site, user, password, "https://login.eloqua.com");
            return client.Execute<AccountInfo>(new RestRequest("id", Method.GET));
        }

        protected BaseClient BaseClient;

        public ContactFieldClient ContactFields
        {
            get { return new ContactFieldClient(BaseClient);}
        }

        public ContactFilterClient ContactFilters
        {
            get { return new ContactFilterClient(BaseClient); }
        }

        public ContactExportClient ContactExport
        {
            get { return new ContactExportClient(BaseClient);}
        }

        public ContactImportClient ContactImport
        {
            get { return new ContactImportClient(BaseClient); }
        }

        public CustomObjectFieldClient CustomObjectFields
        {
            get { return new CustomObjectFieldClient(BaseClient); }
        }

        public CustomObjectImportClient CustomObjectImport
        {
            get { return new CustomObjectImportClient(BaseClient); }
        }
    }
}
