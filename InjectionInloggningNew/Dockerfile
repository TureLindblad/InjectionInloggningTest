# Use the official .NET SDK image to build and run .NET applications
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the solution file and restore dependencies
COPY *.sln ./
COPY BruteForceExample/*.csproj BruteForceExample/
COPY BruteForceExampleTest/*.csproj BruteForceExampleTest/

RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Build the application
RUN dotnet build BruteForceExample.sln --configuration Release

# Run the tests
RUN dotnet test BruteForceExampleTest/BruteForceExampleTest.csproj --configuration Release

# Publish the application
RUN dotnet publish BruteForceExample.sln --configuration Release --output /app/publish
