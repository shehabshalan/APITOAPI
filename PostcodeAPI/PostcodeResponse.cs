using Newtonsoft.Json;

namespace PostcodeAPI
{
    public class PostcodeResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("result")]
        public PostCode PostCode { get; set; }
    }
}