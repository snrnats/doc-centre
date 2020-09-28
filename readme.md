# Sorted Docs

This repo contains the source for Sorted's public documentation.

## Build Status

[![Build Status](https://dev.azure.com/sortedproapp/SortedPRO/_apis/build/status/Docs/Sorted%20Public%20Docs?branchName=master)](https://dev.azure.com/sortedproapp/SortedPRO/_build/latest?definitionId=589&branchName=master)

## How to build

To build this project, you need to install docfx:

- Chocolatey: `choco install docfx -y`
- Homebrew: `brew install docfx`
- Manual: Download `docfx.zip` from <https://github.com/dotnet/docfx/releases>, extract the contents to a local folder, and add the folder to your `PATH`.

Then, navigate to the root of this repository and run `docfx docfx_project/docfx.json`.

You can also serve the site locally by appending `--serve` to the end of the build command, e.g. `docfx docfx_project/docfx.json --serve`. The site will then be available to browse at <http://localhost:8080>.

You may also run the `build.sh` or `serve.sh` scripts in the root of this repository.
