docker container rm -f max44009
docker buildx build --platform linux/arm/v7 -t nrandell/max44009.rpi:latest --load -f Dockerfile ..
docker container create --name max44009 nrandell/max44009.rpi:latest
docker cp max44009:/build/libmax44009.so ./
docker container rm -f max44009
