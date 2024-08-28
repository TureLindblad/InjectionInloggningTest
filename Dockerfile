# Use the official .NET SDK image to build the .NET application
FROM mcr.microsoft.com/dotnet/sdk:8.0-windows-ltsc2022 AS build

# Set the working directory
WORKDIR /app

# Copy the solution file and project files
COPY InjectionInloggning.sln ./
COPY InjectionInloggningNew/*.csproj InjectionInloggningNew/
COPY InjectionInloggningTest/*.csproj InjectionInloggningTest/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Build the application
RUN dotnet build InjectionInloggningNew/InjectionInloggningNew.csproj --configuration Release

# Run the tests
RUN dotnet test InjectionInloggningTest/InjectionInloggningTest.csproj --configuration Release

# Publish the application
RUN dotnet publish InjectionInloggningNew/InjectionInloggningNew.csproj --configuration Release --output /app/publish

# Use a smaller runtime image to run the application
FROM mcr.microsoft.com/dotnet/runtime:8.0-windows-ltsc2022 AS runtime

# Set the working directory
WORKDIR /app

# Copy the published output from the build image
COPY --from=build /app/publish .

# Define the entry point for the application
ENTRYPOINT ["dotnet", "InjectionInloggningNew.dll"]
