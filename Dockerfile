# 1. Base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0.8 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:9.0.8 AS build
WORKDIR /src
COPY ["Portfolio.Web/Portfolio.Web.csproj", "Portfolio.Web/"]
RUN dotnet restore "Portfolio.Web/Portfolio.Web.csproj"
COPY . .
WORKDIR "/src/Portfolio.Web"
RUN dotnet build "Portfolio.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Portfolio.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Portfolio.Web.dll"]
