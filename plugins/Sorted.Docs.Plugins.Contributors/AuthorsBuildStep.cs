using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using Microsoft.DocAsCode.Plugins;
using Microsoft.DocAsCode.Build.ConceptualDocuments;
using Sorted.Docs.Plugins.Contributors.Services;
using Sorted.Docs.Plugins.Contributors.Utils;

namespace Sorted.Docs.Plugins.Contributors
{
    [Export(nameof(ConceptualDocumentProcessor), typeof(IDocumentBuildStep))]
    // ReSharper disable once UnusedType.Global
    public class AuthorsBuildStep : IDocumentBuildStep
    {
        public void Build(FileModel model, IHostService host)
        {
            // do nothing
        }

        public int BuildOrder => 3;

        public string Name => nameof(AuthorsBuildStep);

        public void Postbuild(ImmutableList<FileModel> models, IHostService host)
        {
            foreach (var model in models)
            {
                if (model.Type != DocumentType.Article)
                {
                    continue;
                }
                
                var transformedFilePathFromRoot = model.LocalPathFromRoot.Replace("/", "%2F");
                var gitCommits = GitHubApiService.GetCommits(transformedFilePathFromRoot);

                if (gitCommits == null || !gitCommits.Any())
                {
                    ConsoleWriter.Warning("No git commits to process");
                }
                else
                {
                    ConsoleWriter.Info($"Got {gitCommits.Count} commits to process.");

                    var commits = gitCommits
                        .GroupBy(x => x.Author.Login)
                        .OrderByDescending(x => x.Count())
                        .Select(x => x.FirstOrDefault())
                        .Take(2);
                    
                    var content = (Dictionary<string, object>)model.Content;
                    
                    content["gitPageLink"] = $"https://github.com/sortedgroup/doc-centre/tree/master/docfx_project/{model.LocalPathFromRoot}";

                    var index = 1;
                    foreach (var commit in commits)
                    {
                        content[$"gitPageContributor{index}Login"] = commit.Author.Login;
                        content[$"gitPageContributor{index}AvatarUrl"] = commit.Author.AvatarUrl;
                        content[$"gitPageContributor{index}HtmlUrl"] = commit.Author.HtmlUrl;
                        index++;
                    }
                    
                    content["gitPageDate"] = DateTime.Parse(gitCommits[0].Commit.Author.Date).ToShortDateString();
                }
            }
        }

        public IEnumerable<FileModel> Prebuild(ImmutableList<FileModel> models, IHostService host)
        {
            return models;
        }
    }
}
