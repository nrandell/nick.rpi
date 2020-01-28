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

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/core/sdk:3.1.101-buster as build-dotnet

WORKDIR /build

COPY ["Directory.Build.props", "./"]
COPY ["Nick.Rpi.Driver.Max44009/Nick.Rpi.Driver.Max44009.csproj", "Nick.Rpi.Driver.Max44009/"]

WORKDIR /build/Nick.Rpi.Driver.Max44009
RUN dotnet restore

WORKDIR /build
COPY ["Nick.Rpi.Driver.Max44009/", "Nick.Rpi.Driver.Max44009/"]

WORKDIR /build/Nick.Rpi.Driver.Max44009
COPY --from=build-native /build/libmax44009.so ./
RUN dotnet build -c Release --no-restore

FROM build-dotnet as publish
RUN dotnet pack -c Release --no-build -o /publish

WORKDIR /publish
ARG NUGET_API_KEY
RUN ls -l && dotnet nuget push *.nupkg --source "https://api.nuget.org/v3/index.json" --api-key ${NUGET_API_KEY}

