# --------------------------
# 1️⃣ Build Stage
# --------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and publish
COPY . ./
RUN dotnet publish -c Release -o out

# --------------------------
# 2️⃣ Runtime Stage
# --------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose port 8080 (Render / generic hosts)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Start your application
ENTRYPOINT ["dotnet", "SumitPortfolio.dll"]
