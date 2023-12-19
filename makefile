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
