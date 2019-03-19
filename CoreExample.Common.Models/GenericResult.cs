namespace CoreExample.Common.Models
{
    public class GenericResult
    {
        public GenericResult()
        {
            error_text = "";
        }

        public bool result { get; set; }
        public string error_text { get; set; }
    }
}
