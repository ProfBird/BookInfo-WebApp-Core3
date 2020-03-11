# Download the ASP.NET Core runtime.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

# Copy files from the dev machine to the container.
COPY GoodBookNook/bin/Release/netcoreapp3.1/ app/

# Change directories, we need to run the app from the app directory.
WORKDIR app/

# Start the web app when the container runs.
ENTRYPOINT ["dotnet", "GoodBookNook.dll", "--environment=Production"]
