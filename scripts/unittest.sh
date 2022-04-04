#!/bin/bash
set -e

current_directory="$PWD"

cd $(dirname $0)/../src

echo "Running unit tests..."

dotnet test BasisTheory.net.Tests/BasisTheory.net.Tests.csproj --no-restore --no-build -c Release -v=normal

result=$?

cd "$current_directory"

exit $result
