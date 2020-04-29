using System;

namespace Sorted.Docs.Plugins.Contributors.Utils
{
    public static class GitHubApiKeyHelper
    {
        public static string GetAuthToken()
        {
            const string VariableName = "GITHUB_AUTH_TOKEN";
            var (hasValue, value) = GetEnvironmentVariable(VariableName);
            if (hasValue)
            {
                return value;
            }
            ConsoleWriter.Warning($"Environment variable {VariableName} was not found. Cannot process commits.");
            return string.Empty;

        }

        private static (bool HasValue, string Value) GetEnvironmentVariable(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);

            return string.IsNullOrWhiteSpace(value) ? (false, string.Empty) : (true, value);
        }
    }
}