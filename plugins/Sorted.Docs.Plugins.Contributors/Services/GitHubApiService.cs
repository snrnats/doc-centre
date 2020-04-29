using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sorted.Docs.Plugins.Contributors.Models;
using Sorted.Docs.Plugins.Contributors.Utils;

namespace Sorted.Docs.Plugins.Contributors.Services
{
    public static class GitHubApiService
    {
        private const string BaseRepoUrl = "https://api.github.com/repos/SortedGroup/doc-centre";
        
        public static List<Contributor> GetContributors()
        {
            if (!ApiTokenExists())
            {
                ConsoleWriter.Warning("GitHub API Token not provided. Commit processing will be skipped");
                return new List<Contributor>(0);
            }
            
            var contributorsEndpoint = $"{BaseRepoUrl}/contributors";
            var results = CallApi(contributorsEndpoint).GetAwaiter().GetResult(); //sorry, DocFX doesn't support async methods here
            if (string.IsNullOrWhiteSpace(results))
            {
                ConsoleWriter.Warning("No results returned for 'GetContributors'");
                return new List<Contributor>(0);
            }

            try
            {
                var contributors = JsonConvert.DeserializeObject<List<Contributor>>(results);
                return contributors;
            }
            catch (Exception e)
            {
                ConsoleWriter.Warning($"Error getting contributors. Error: {e.Message}");
                return new List<Contributor>(0);
            }
        }

        public static List<Commits> GetCommits(string path)
        {
            if (!ApiTokenExists())
            {
                ConsoleWriter.Warning("GitHub API Token not provided. Commit processing will be skipped");
                return new List<Commits>(0);
            }

            var commitsEndpoint = $"{BaseRepoUrl}/commits";
            
            if (!string.IsNullOrWhiteSpace(path))
            {
                path = FormatPath(path);
                commitsEndpoint = $"{commitsEndpoint}?path={path}";
            }
            
            var results = CallApi(commitsEndpoint).GetAwaiter().GetResult(); //sorry, looks like DocFX steps don't support async methods

            if (string.IsNullOrWhiteSpace(results))
            {
                ConsoleWriter.Warning($"No results returned for 'GetContributors' for path {path}");

                return new List<Commits>(0);
            }

            try
            {
                var commits = JsonConvert.DeserializeObject<List<Commits>>(results);

                var filteredCommits = commits.Where(x => x.Author != null);
                return filteredCommits.ToList();
            }
            catch (Exception e)
            {
                ConsoleWriter.Error($"Error processing commit for path '{path}'. Error: {e.Message}");
                return new List<Commits>(0);
            }
        }

        private static async Task<string> CallApi(string endpoint)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Sorted-DocFX");

            client = ApplyAuthentication(client);
            
            using var response = await client.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
            {
                ConsoleWriter.Warning($"Received status code {response.StatusCode} for API call to {endpoint}");
                return string.Empty;
            }
            
            try
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                using var streamReader = new StreamReader(stream);
                return await streamReader.ReadToEndAsync();
            }
            catch (Exception e)
            {
                ConsoleWriter.Warning($"Error processing path {endpoint}. Error: {e.Message}");
                return string.Empty;
            }
        }

        private static string FormatPath(string path)
        {
            return string.IsNullOrWhiteSpace(path) ? path : $"docfx_project%2F{path}";
        }

        private static HttpClient ApplyAuthentication(HttpClient client)
        {
            var headerValue = GitHubApiKeyHelper.GetAuthToken();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", headerValue);
            return client;
        }

        private static bool ApiTokenExists()
        {
            var apiToken = GitHubApiKeyHelper.GetAuthToken();
            return !string.IsNullOrWhiteSpace(apiToken);
        }
    }
}