$authToken = $env:GITHUB_AUTH_TOKEN;

if ([string]::IsNullOrWhiteSpace($authToken)) {
  Write-Host "Warning :: the environment variable GITHUB_AUTH_TOKEN is missing. This should be {username}:{token} encoded in base64. Commit/author data will be omitted"
}

Write-Host "Initiating Docker build step"
& docker build -t sorted-docs:latest --build-arg AUTH_TOKEN=$authToken .
& docker run -it -p 8080:8080 sorted-docs:latest