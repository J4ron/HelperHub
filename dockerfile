# Multistage Build by Skpetic Systems
# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY RFE/RFE.csproj ./RFE/
WORKDIR /app/RFE
RUN dotnet restore
COPY RFE/. ./
RUN dotnet publish -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
RUN mkdir /data
EXPOSE 5000
ENTRYPOINT ["dotnet", "RFE.dll"]

# docker build -t helper-hub .
# docker run -d -p 5000:5000 helper-hub