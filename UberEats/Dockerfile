# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy project files and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the entire project and build the application
COPY . .
RUN dotnet publish -c Release -o out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Set the entry point for the container
ENTRYPOINT ["dotnet", "UberEats.dll"]
