using System.Collections.Immutable;
using System.Composition;
using Microsoft.DocAsCode.Plugins;

namespace Sorted.Docs.Plugins.Contributors
{
    [Export(nameof(AuthorsProcessor), typeof(IPostProcessor))]
    public class AuthorsProcessor : IPostProcessor
    {
        public ImmutableDictionary<string, object> PrepareMetadata(ImmutableDictionary<string, object> metadata) => metadata;

        public Manifest Process(Manifest manifest, string outputFolder) => manifest;
       
    }
}