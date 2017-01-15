#!/bin/bash

# Settings
workingDirectory=var/www/RecruitmentSystem
githubUrl=https://github.com/JustinRickard/RecruitmentSystem.git

# Update Ubuntu  (use sudo if doing manually. scripts should be run as sudo)
apt-get update
apt-get upgrade

# Install Required Packages
sudo apt-get install mongodb git nodejs npm nginx

# Node link
sudo ln -s /usr/bin/nodejs /usr/bin/node

# Copy source code to local machine
git clone $githubUrl
cd $workingDirectory

# Build the solution
dotnet restore
dotnet build

# Run the application with a process manager (Supervisor or Kestrel)
# TO DO