#!/bin/bash
set -e

current_directory="$PWD"

cd $(dirname $0)/..

# Do Something

result=$?

cd "$current_directory"

exit $result
