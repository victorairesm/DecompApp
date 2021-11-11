#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NumDecompAPI/NumDecompAPI.csproj", "NumDecompAPI/"]
COPY ["NumDecomp.Domain.Core/NumDecomp.Domain.Core.csproj", "NumDecomp.Domain.Core/"]
COPY ["NumDecomp.App.DTO/NumDecomp.App.DTO.csproj", "NumDecomp.App.DTO/"]
COPY ["NumDecomp.Domain/NumDecomp.Domain.csproj", "NumDecomp.Domain/"]
COPY ["NumDecomp.Infra.CC.IOC/NumDecomp.Infra.CC.IOC.csproj", "NumDecomp.Infra.CC.IOC/"]
COPY ["NumDecomp.Domain.Services/NumDecomp.Domain.Services.csproj", "NumDecomp.Domain.Services/"]
RUN dotnet restore "NumDecompAPI/NumDecompAPI.csproj"
COPY . .
WORKDIR "/src/NumDecompAPI"
RUN dotnet build "NumDecompAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NumDecompAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NumDecompAPI.dll"]