MAKEFLAGS += --silent

verify:
	./scripts/verify.sh

build:
	./scripts/build.sh

unit-test:
	./scripts/unittest.sh

acceptance-test:
	./scripts/acceptancetest.sh

start-docker:
	./scripts/startdocker.sh

stop-docker:
	./scripts/stopdocker.sh

release:
	./scripts/release.sh

update-api-spec:
	./scripts/update-api-spec.sh

generate-sdk:
	./scripts/generate-sdk.sh