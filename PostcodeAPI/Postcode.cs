using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
namespace PostcodeAPI
{
    [Serializable]
    public class PostCode
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("code")]

        public string Code { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

    }
   
}