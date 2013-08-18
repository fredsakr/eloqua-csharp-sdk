using Eloqua.Api.Bulk.Models.Login;

namespace Eloqua.Api.Bulk.Tests
{
    internal class Helpers
    {
        public static string CurrentApiVersion(AccountInfo accountInfo)
        {
            return accountInfo.Urls.Apis.Rest.Bulk.Replace("{version}", Constants.ApiVersion);
        }
    }
}
