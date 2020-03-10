using System;

namespace Sorted.Docs.Plugins.Contributors.Utils
{
    public static class GitHubApiKeyHelper
    {
        public static string GetAuthToken()
        {
            var (hasValue, value) = GetEnvironmentVariable("GITHUB_AUTH_TOKEN");
            if (!hasValue)
            {
                throw new Exception("GitHub credentials are not present. Is GITHUB_AUTH_TOKEN variable set?");
            }

            return value;
        }

        private static (bool HasValue, string Value) GetEnvironmentVariable(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);

            return string.IsNullOrWhiteSpace(value) ? (false, string.Empty) : (true, value);
        }
    }
}