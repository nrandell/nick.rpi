FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/core/sdk:3.1.101-buster as build

WORKDIR /build

COPY ["Nick.Rpi.Driver.Bme280/Nick.Rpi.Driver.Bme280.csproj", "Nick.Rpi.Driver.Bme280/"]
COPY ["TestBme280/TestBme280.csproj", "TestBme280/"]

WORKDIR /build/TestBme280
RUN dotnet restore

WORKDIR /build
COPY ["Nick.Rpi.Driver.Bme280/", "Nick.Rpi.Driver.Bme280/"]
COPY ["TestBme280/", "TestBme280/"]
WORKDIR /build/TestBme280

RUN dotnet build -c Release --no-restore

FROM build as publish
RUN dotnet publish -c Release --no-build -o /publish

FROM nrandell/bme280.rpi:0.1 as bme280
FROM mcr.microsoft.com/dotnet/core/runtime:3.1.1-buster-slim-arm32v7 as final
WORKDIR /app
COPY --from=bme280 /build/libbme280.so .
COPY --from=publish /publish .

ENTRYPOINT ["dotnet", "TestBme280.dll"]
