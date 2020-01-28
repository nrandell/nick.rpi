FROM debian:buster as build-native

RUN apt-get update \
	&& apt-get install -y \
	build-essential \
	git \
    unzip \
    libi2c-dev \
	wget


WORKDIR /build
RUN wget https://github.com/BoschSensortec/BME280_driver/archive/bme280_v3.3.7.zip && \
    unzip bme280*.zip && \
    rm bme280_*.zip && \
    mv BME280_* bme280

WORKDIR /build/bme280    
RUN mv selftest/* . && rmdir selftest

COPY ["Nick.Rpi.Driver.Bme280/Makefile", "Nick.Rpi.Driver.Bme280/wrapper.c", "./"]
RUN make \
	&& mv libbme280.so /build

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/core/sdk:3.1.101-buster as build-dotnet

WORKDIR /build

COPY ["Directory.Build.props", "./"]
COPY ["Nick.Rpi.Driver.Bme280/Nick.Rpi.Driver.Bme280.csproj", "Nick.Rpi.Driver.Bme280/"]

WORKDIR /build/Nick.Rpi.Driver.Bme280
RUN dotnet restore

WORKDIR /build
COPY ["Nick.Rpi.Driver.Bme280/", "Nick.Rpi.Driver.Bme280/"]

WORKDIR /build/Nick.Rpi.Driver.Bme280
COPY --from=build-native /build/libbme280.so ./
RUN dotnet build -c Release --no-restore

FROM build-dotnet as publish
RUN dotnet pack -c Release --no-build -o /publish

WORKDIR /publish
ARG NUGET_API_KEY
RUN ls -l && dotnet nuget push *.nupkg --source "https://api.nuget.org/v3/index.json" --api-key ${NUGET_API_KEY}

