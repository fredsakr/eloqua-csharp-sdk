using NUnit.Framework;
using Eloqua.Api.Bulk.Models.Exports;

namespace Eloqua.Api.Bulk.Tests.Contacts
{
    [TestFixture]
    public class ContactExportTests
    {
        private BulkClient _client;

        [TestFixtureSetUp]
        public void Init()
        {
            var accountInfo = BulkClient.GetAccountInfo(Constants.Site, Constants.User, Constants.Passwd);

            _client = new BulkClient(Constants.Site, Constants.User, Constants.Passwd, Helpers.CurrentApiVersion(accountInfo));
        }

        [Test]
        public void CreateExportTest()
        {
            var export = _client.ContactExport.CreateExport(new Export() );
            Assert.IsNotNull(export);
        }
    }
}
