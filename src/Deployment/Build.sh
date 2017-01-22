#!/bin/bash

# Restore project dependencies
dotnet restore Common
dotnet restore DAL.MongoDB

# Build projects
dotnet build Common
dotnet build DAL.MongoDB
