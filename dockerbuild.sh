docker build -t sorted-docs:latest --build-arg AUTH_TOKEN=${GITHUB_AUTH_TOKEN} .
docker run -it -p 8080:80 sorted-docs:latest