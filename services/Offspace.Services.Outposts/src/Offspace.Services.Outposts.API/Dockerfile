FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Offspace.Services.Outposts.API/Offspace.Services.Outposts.API.csproj", "src/Offspace.Services.Outposts.API/"]
RUN dotnet restore "src/Offspace.Services.Outposts.API/Offspace.Services.Outposts.API.csproj"
COPY . .
WORKDIR "/src/src/Offspace.Services.Outposts.API"
RUN dotnet build "Offspace.Services.Outposts.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Offspace.Services.Outposts.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Offspace.Services.Outposts.API.dll"]
