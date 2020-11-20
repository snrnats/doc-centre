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

FROM nginx:1.18-alpine as host

EXPOSE 8080

WORKDIR /site

COPY ./nginx/nginx.conf /etc/nginx/nginx.conf
COPY ./nginx/default.conf /etc/nginx/conf.d/default.conf

COPY --from=build /build/source/docfx_project/404.html /site
COPY --from=build /build/source/docfx_project/_site /site

RUN chown -R nginx:nginx /site && chmod -R 755 /site && \
  chown -R nginx:nginx /var/cache/nginx && \
  chown -R nginx:nginx /etc/nginx/conf.d

RUN touch /var/run/nginx.pid && chown -R nginx:nginx /var/run/nginx.pid

STOPSIGNAL SIGTERM
USER nginx
CMD ["nginx", "-g", "daemon off;"]