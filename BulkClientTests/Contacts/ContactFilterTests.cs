using System.Collections.Generic;
using Eloqua.Api.Bulk.Models.Contacts;
using NUnit.Framework;

namespace Eloqua.Api.Bulk.Tests.Contacts
{
    [TestFixture]
    public class ContactFilterTests
    {
        private BulkClient _client;

        [TestFixtureSetUp]
        public void Init()
        {
            var accountInfo = BulkClient.GetAccountInfo(Constants.Site, Constants.User, Constants.Passwd);

            _client = new BulkClient(Constants.Site, Constants.User, Constants.Passwd, Helpers.CurrentApiVersion(accountInfo));
        }

        [Test]
        public void GetContactFieldsTest()
        {
            List<ContactFilter> filters = _client.ContactFilters.Search("*", 1, 1);
            Assert.AreEqual(1, filters.Count);
        }
    }
}
