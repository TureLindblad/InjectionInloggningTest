# Use the official .NET SDK image to build and run .NET applications
FROM mcr.microsoft.com/dotnet/sdk:8.0-windows-ltsc2022 AS build

# Set the working directory
WORKDIR /app

# Copy the solution file and restore dependencies
COPY *.sln ./
COPY InjectionInloggningNew/*.csproj InjectionInloggningNew/
COPY InjectionInloggningTest/*.csproj InjectionInloggningTest/

RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Build the application
RUN dotnet build InjectionInloggning.sln --configuration Release

# Run the tests
RUN dotnet test InjectionInloggningTest/InjectionInloggningTest.csproj --configuration Release

# Publish the application
RUN dotnet publish InjectionInloggning.sln --configuration Release --output /app/publish