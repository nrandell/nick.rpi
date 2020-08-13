FROM debian:buster as build-native

RUN apt-get update \
    && apt-get install -y \
    build-essential \
    git \
    unzip \
    libi2c-dev \
    wget


WORKDIR /build/max44009
COPY ["Nick.Rpi.Driver.Max44009/Makefile", "Nick.Rpi.Driver.Max44009/wrapper.c", "./"]
RUN make \
    && mv libmax44009.so /build
