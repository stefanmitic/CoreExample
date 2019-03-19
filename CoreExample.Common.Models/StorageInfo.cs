namespace CoreExample.Common.Models
{
    public class StorageInfo : GenericResult
    {
        public long bytes_used { get; set; }
        public long bytes_free { get; set; }
    }
}
