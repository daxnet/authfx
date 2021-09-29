FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AuthFx.AuthServer/AuthFx.AuthServer.csproj", "AuthFx.AuthServer/"]
RUN dotnet restore "AuthFx.AuthServer/AuthFx.AuthServer.csproj"
COPY . .
WORKDIR "/src/AuthFx.AuthServer"
RUN dotnet build "AuthFx.AuthServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthFx.AuthServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthFx.AuthServer.dll"]
