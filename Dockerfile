
FROM microsoft/aspnetcore:2 AS build-env
LABEL Name=mining Version=0.0.1
ARG source=.
WORKDIR /app
EXPOSE 5000
COPY $source .
ENTRYPOINT dotnet Mining.dll
