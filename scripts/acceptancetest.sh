#!/bin/bash
set -e

current_directory="$PWD"

cd $(dirname $0)/../src

echo "Running acceptance tests..."

export GIT_HASH=$(git rev-parse HEAD)

dotnet test BasisTheory.net.AcceptanceTests/BasisTheory.net.AcceptanceTests.csproj --no-restore --no-build -c Release -v=normal

result=$?

cd "$current_directory"

exit $result
