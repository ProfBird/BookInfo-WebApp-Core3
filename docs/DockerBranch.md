# BookInfo-WebApp-Core3

## Changes on the Docker Branch

### Dockerfile

This file is used by Docker to build a Docker image. It's the only thing I needed to add to the project on this branch.

### Startup.cs

I made changes to this file to support using different database providers based on the environment, production or development. These changes weren't needed for docker deployment, but just facilitated using the Azure database while testing my container on my development machine.

### Running the app in a Docker container

1. Open a terminal windows in the solution folder, then execute this  CLI command to build an image:

   `docker build -t goodbooknook .`

2. Execute this command to create a container and run it:

   `docker run --rm -p 8080:80 goodbooknook`

3. View the web page in a browser at http://localhost:8080

