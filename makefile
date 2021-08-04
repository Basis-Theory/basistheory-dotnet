MAKEFLAGS += --silent

verify:
	docker-compose pull && ./scripts/verify.sh

build:
	./scripts/build.sh

acceptance-test:
	./scripts/acceptancetest.sh

start-docker:
	./scripts/startdocker.sh

stop-docker:
	./scripts/stopdocker.sh

release:
	./scripts/release.sh
