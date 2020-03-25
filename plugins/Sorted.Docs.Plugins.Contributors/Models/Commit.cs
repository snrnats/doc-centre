using Newtonsoft.Json;

namespace Sorted.Docs.Plugins.Contributors.Models
{
    public class Commit
    {
        [JsonProperty(PropertyName = "author")]
        public CommitAuthor Author { get; set; }
    }
}