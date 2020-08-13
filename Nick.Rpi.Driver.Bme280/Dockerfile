FROM debian:buster as build-native

RUN apt-get update \
    && apt-get install -y \
    build-essential \
    git \
    unzip \
    libi2c-dev \
    wget


WORKDIR /build
RUN wget https://github.com/BoschSensortec/BME280_driver/archive/bme280_v3.5.0.zip && \
    unzip bme280*.zip && \
    rm bme280_*.zip && \
    mv BME280_* bme280

WORKDIR /build/bme280    

COPY ["Nick.Rpi.Driver.Bme280/Makefile", "Nick.Rpi.Driver.Bme280/wrapper.c", "./"]
RUN make \
    && mv libbme280.so /build/

