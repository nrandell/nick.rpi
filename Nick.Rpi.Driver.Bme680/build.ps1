docker container rm -f bme680
docker buildx build --platform linux/arm/v7 -t nrandell/bme680.rpi:latest --load -f Dockerfile ..
docker container create --name bme680 nrandell/bme680.rpi:latest
docker cp bme680:/build/libbme680.so ./
docker container rm -f bme680
