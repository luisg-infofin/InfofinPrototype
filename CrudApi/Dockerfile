# Get image of .Net
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

# Set working dir
WORKDIR /app

# Port to use
EXPOSE 80

# Copy solution and projects declaration files
COPY InfofinPrototype.sln InfofinPrototype.sln
COPY CrudApi/CrudApi.csproj CrudApi/CrudApi.csproj
COPY IdentityServer/IdentityServer.csproj IdentityServer/IdentityServer.csproj
COPY Entities/Entities.csproj Entities/Entities.csproj
COPY GatewayService/GatewayService.csproj GatewayService/GatewayService.csproj
COPY SearchService/SearchService.csproj SearchService/SearchService.csproj

# Restore packages deps
RUN dotnet restore InfofinPrototype.sln

# Copy projects files
COPY CrudApi CrudApi
COPY Entities Entities
WORKDIR /app/CrudApi
RUN dotnet publish -c Release -o /app/src/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/src/out . 

ENTRYPOINT ["dotnet", "CrudApi.dll"]