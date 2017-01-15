#!/bin/bash

# Settings
workingDirectory=var/www/RecruitmentSystem
githubUrl=https://github.com/JustinRickard/RecruitmentSystem.git

# Update Ubuntu  (use sudo if doing manually. scripts should be run as sudo)
apt-get update
apt-get upgrade

# Update source code
cd $workingDirectory
git pull

# Build the solution
dotnet restore
dotnet build

# Run the application with a process manager (Supervisor or Kestrel)
# TO DO