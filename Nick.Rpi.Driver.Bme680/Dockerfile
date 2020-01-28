FROM debian:buster as build-native

RUN apt-get update \
	&& apt-get install -y \
	build-essential \
	git \
    unzip \
    libi2c-dev \
	wget


WORKDIR /build
RUN wget https://github.com/BoschSensortec/BME680_driver/archive/bme680_v3.5.9.zip && \
    unzip bme680*.zip && \
    rm bme680_*.zip && \
    mv BME680_* bme680

WORKDIR /build/bme680    
RUN mv Self\ test/* . && rmdir Self\ test

COPY ["Nick.Rpi.Driver.Bme680/Makefile", "Nick.Rpi.Driver.Bme680/wrapper.c", "./"]
RUN make \
	&& mv libbme680.so /build



FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/core/sdk:3.1.101-buster as build-dotnet

WORKDIR /build

COPY ["Directory.Build.props", "./"]
COPY ["Nick.Rpi.Driver.Bme680/Nick.Rpi.Driver.Bme680.csproj", "Nick.Rpi.Driver.Bme680/"]

WORKDIR /build/Nick.Rpi.Driver.Bme680
RUN dotnet restore

WORKDIR /build
COPY ["Nick.Rpi.Driver.Bme680/", "Nick.Rpi.Driver.Bme680/"]

WORKDIR /build/Nick.Rpi.Driver.Bme680
COPY --from=build-native /build/libbme680.so ./
RUN dotnet build -c Release --no-restore

FROM build-dotnet as publish
RUN dotnet pack -c Release --no-build -o /publish

WORKDIR /publish
ARG NUGET_API_KEY
RUN ls -l && dotnet nuget push *.nupkg --source "https://api.nuget.org/v3/index.json" --api-key ${NUGET_API_KEY}




