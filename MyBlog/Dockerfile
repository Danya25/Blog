  FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build

WORKDIR /src
COPY Server/VovaLantsovBlog.Server.csproj Server/
COPY Data/VovaLantsovBlog.Data.csproj Data/
COPY Shared/VovaLantsovBlog.Shared.csproj Shared/
COPY Client/VovaLantsovBlog.Client.csproj Client/

RUN dotnet restore Server/VovaLantsovBlog.Server.csproj
RUN dotnet restore Client/VovaLantsovBlog.Client.csproj

COPY . .
WORKDIR /src/Server
RUN dotnet build VovaLantsovBlog.Server.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish VovaLantsovBlog.Server.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "VovaLantsovBlog.Server.dll"]