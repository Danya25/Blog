FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 81

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src

COPY ["MyBlog/MyBlog.csproj", "MyBlog/"]
COPY ["MyBlog.Common/MyBlog.Common.csproj", "MyBlog.Common/"]
COPY ["MyBlog.DAL/MyBlog.DAL.csproj", "MyBlog.DAL/"]
COPY ["MyBlog.Domain/MyBlog.Domain.csproj", "MyBlog.Domain/"]
COPY ["MyBlog.Services/MyBlog.Services.csproj", "MyBlog.Services/"]

RUN dotnet restore "MyBlog/MyBlog.csproj"
RUN dotnet restore "MyBlog.Common/MyBlog.Common.csproj"
RUN dotnet restore "MyBlog.DAL/MyBlog.DAL.csproj"
RUN dotnet restore "MyBlog.Domain/MyBlog.Domain.csproj"
RUN dotnet restore "MyBlog.Services/MyBlog.Services.csproj"

COPY . .

WORKDIR "/src/MyBlog"
RUN dotnet build MyBlog.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MyBlog.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MyBlog.dll"]

