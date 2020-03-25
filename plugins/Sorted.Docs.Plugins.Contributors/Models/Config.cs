using Newtonsoft.Json;

namespace Sorted.Docs.Plugins.Contributors.Models
{
    public class Config
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
    }
}