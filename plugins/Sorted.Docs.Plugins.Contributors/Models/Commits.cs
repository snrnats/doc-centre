using Newtonsoft.Json;

namespace Sorted.Docs.Plugins.Contributors.Models
{
    public class Commits
    {
        [JsonProperty(PropertyName = "commit")]
        public Commit Commit { get; set; }

        [JsonProperty(PropertyName = "author")]
        public Author Author { get; set; }
    }
}