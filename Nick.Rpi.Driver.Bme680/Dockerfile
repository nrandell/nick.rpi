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
