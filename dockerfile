#https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

#copy project and restore as distinct layers
COPY . ./
WORKDIR /app/NumDecompAPI
RUN dotnet restore

#build app
RUN dotnet publish -c Release -o published

#final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/NumDecompAPI/published .
ENTRYPOINT ["dotnet", "NumDecompAPI.dll"]