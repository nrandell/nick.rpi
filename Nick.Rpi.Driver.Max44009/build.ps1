docker buildx build --platform linux/arm/v7 -t nrandell/max44009.rpi:0.4 --build-arg NUGET_API_KEY=$env:NUGET_API_KEY --load -f Dockerfile ..