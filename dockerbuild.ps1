$authToken = $env:GITHUB_AUTH_TOKEN;

if ([string]::IsNullOrWhiteSpace($authToken)) {
    throw "The environment variable GITHUB_AUTH_TOKEN is missing. This should be {username}:{token} encoded in base64."
}

Write-Host "Initiating Docker build step"
& docker build -t sorted-docs:latest --build-arg AUTH_TOKEN=$authToken .
& docker run -it -p 8080:80 sorted-docs:latest