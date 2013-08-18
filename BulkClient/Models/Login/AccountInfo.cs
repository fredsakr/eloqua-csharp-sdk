namespace Eloqua.Api.Bulk.Models.Login
{
    public class AccountInfo
    {
        public Site Site { get; set; }
        public ApiAccount User { get; set; }
        public Urls Urls { get; set; }
    }
}
