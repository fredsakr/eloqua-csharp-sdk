using NUnit.Framework;
using Eloqua.Api.Bulk.Models;


namespace Eloqua.Api.Bulk.Tests.CustomObjects
{
    [TestFixture]
    public class CustomObjectFieldTests
    {
        private BulkClient _client;

        [TestFixtureSetUp]
        public void Init()
        {
            var accountInfo = BulkClient.GetAccountInfo(Constants.Site, Constants.User, Constants.Passwd);

            _client = new BulkClient(Constants.Site, Constants.User, Constants.Passwd, Helpers.BulkEndpoint(accountInfo));
        }

        [Test]
        public void GetContactFieldsTest()
        {
            SearchResponse<Field> fields = _client.CustomObjectFields.Search(1, "*", 1, 1);
            Assert.AreEqual(1, fields.total);
        }
    }
}
