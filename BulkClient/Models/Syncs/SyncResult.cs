using System;

namespace Eloqua.Api.Bulk.Models.Syncs
{
    public class SyncResult
    {
        public int? count { get; set; }
        public DateTime? createdAt { get; set; }
        public string message { get; set; }
        public string syncUri { get; set; }
    }
}
