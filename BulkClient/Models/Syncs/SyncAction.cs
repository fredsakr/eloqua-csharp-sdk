namespace Eloqua.Api.Bulk.Models.Syncs
{
    public class SyncAction
    {
        public SyncActionType? action { get; set; }
        public string destinationUri { get; set; }
    }
}
