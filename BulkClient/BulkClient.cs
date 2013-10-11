using RestSharp;
using Eloqua.Api.Bulk.Clients.Accounts;
using Eloqua.Api.Bulk.Clients.Contacts;
using Eloqua.Api.Bulk.Clients.CustomObjects;
using Eloqua.Api.Bulk.Models.Login;

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

        #region contacts

        public ContactFieldClient ContactFields
        {
            get { return _contactFieldClient ?? (_contactFieldClient = new ContactFieldClient(BaseClient)); }
        }
        private ContactFieldClient _contactFieldClient;

        public ContactFilterClient ContactFilters
        {
            get { return _contactFilterClient ?? (_contactFilterClient = new ContactFilterClient(BaseClient)); }
        }
        private ContactFilterClient _contactFilterClient;

        public ContactExportClient ContactExport
        {
            get { return _contactExportClient ?? (_contactExportClient = new ContactExportClient(BaseClient)); }
        }
        private ContactExportClient _contactExportClient;

        public ContactImportClient ContactImport
        {
            get { return _contactImportClient ?? (_contactImportClient = new ContactImportClient(BaseClient)); }
        }
        private ContactImportClient _contactImportClient;

        #endregion

        #region custom objects

        public CustomObjectFieldClient CustomObjectFields
        {
            get { return _customObjectFieldClient ?? (_customObjectFieldClient = new CustomObjectFieldClient(BaseClient)); }
        }
        private CustomObjectFieldClient _customObjectFieldClient;

        public CustomObjectExportClient CustomObjectExport
        {
            get { return _customObjectExportClient ?? (_customObjectExportClient = new CustomObjectExportClient(BaseClient)); }
        }
        private CustomObjectExportClient _customObjectExportClient;

        public CustomObjectImportClient CustomObjectImport
        {
            get { return _customObjectImportClient ?? (_customObjectImportClient = new CustomObjectImportClient(BaseClient)); }
        }
        private CustomObjectImportClient _customObjectImportClient;

        #endregion

        #region accounts

        public AccountFieldClient AccountFields
        {
            get { return _accountFieldClient ?? (_accountFieldClient = new AccountFieldClient(BaseClient)); }
        }
        private AccountFieldClient _accountFieldClient;

        public AccountFilterClient AccountFilters
        {
            get { return _accountFilterClient ?? (_accountFilterClient = new AccountFilterClient(BaseClient)); }
        }
        private AccountFilterClient _accountFilterClient;

        public AccountExportClient AccountExport
        {
            get { return _accountExportClient ?? (_accountExportClient = new AccountExportClient(BaseClient)); }
        }
        private AccountExportClient _accountExportClient;

        public AccountImportClient AccountImport
        {
            get { return _accountImportClient ?? (_accountImportClient = new AccountImportClient(BaseClient)); }
        }
        private AccountImportClient _accountImportClient;

        #endregion
    }
}