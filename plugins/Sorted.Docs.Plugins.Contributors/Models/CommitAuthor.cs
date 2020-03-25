using Newtonsoft.Json;

namespace Sorted.Docs.Plugins.Contributors.Models
{
    public class CommitAuthor
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
    }
}