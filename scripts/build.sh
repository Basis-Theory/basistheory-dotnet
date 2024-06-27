#!/bin/bash
set -e

current_directory="$PWD"

cd $(dirname $0)/../

dotnet restore

dotnet build BasisTheory.net.sln --no-restore -c Release

result=$?

cd "$current_directory"

exit $result
