FROM mono:6.8.0.96 as build

ARG AUTH_TOKEN

ENV GITHUB_AUTH_TOKEN=${AUTH_TOKEN}

WORKDIR /build

RUN curl -L https://github.com/dotnet/docfx/releases/download/v2.49/docfx.zip --output docfx.zip
RUN apt update
RUN apt install zip unzip git -y
RUN unzip -o docfx.zip -d ./docfx

COPY . ./source

RUN mono ./docfx/docfx.exe ./source/docfx_project/docfx.json

FROM nginx:1.17.8-alpine as host

WORKDIR /site

COPY --from=build /build/source/docfx_project/_site /usr/share/nginx/html