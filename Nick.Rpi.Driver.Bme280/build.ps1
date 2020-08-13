docker container rm -f bme280
docker buildx build --platform linux/arm/v7 -t nrandell/bme280.rpi:latest --load -f Dockerfile ..
docker container create --name bme280 nrandell/bme280.rpi:latest
docker cp bme280:/build/libbme280.so ./
docker container rm -f bme280
