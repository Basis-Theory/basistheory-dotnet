#!/bin/bash
set -e

current_directory="$PWD"

cd $(dirname $0)/..

if [ "$(expr substr $(uname -s) 1 5)" == "Linux" ]; then
    cp local-certs/azure-key-vault-emulator.crt /usr/local/share/ca-certificates/azure-key-vault-emulator.crt
    update-ca-certificates
fi

docker-compose up -d --build

result=$?

cd "$current_directory"

exit $result
