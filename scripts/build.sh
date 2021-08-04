#!/bin/bash
set -e

current_directory="$PWD"

cd $(dirname $0)/../src

dotnet restore

dotnet build BasisTheory.net.sln --no-restore -c Release

# Run unit tests
find . -name '*.Tests.csproj' -exec dotnet test {} --no-build --no-restore -v=normal -c Release \;

result=$?

cd "$current_directory"

exit $result
