FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AuthFx.ApiServer/AuthFx.ApiServer.csproj", "AuthFx.ApiServer/"]
RUN dotnet restore "AuthFx.ApiServer/AuthFx.ApiServer.csproj"
COPY . .
WORKDIR "/src/AuthFx.ApiServer"
RUN dotnet build "AuthFx.ApiServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthFx.ApiServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthFx.ApiServer.dll"]
