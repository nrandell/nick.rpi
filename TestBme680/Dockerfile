FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/core/sdk:3.1.101-buster as build

WORKDIR /build

COPY ["Nick.Rpi.Driver.Bme680/Nick.Rpi.Driver.Bme680.csproj", "Nick.Rpi.Driver.Bme680/"]
COPY ["TestBme680/TestBme680.csproj", "TestBme680/"]

WORKDIR /build/TestBme680
RUN dotnet restore

WORKDIR /build
COPY ["Nick.Rpi.Driver.Bme680/", "Nick.Rpi.Driver.Bme680/"]
COPY ["TestBme680/", "TestBme680/"]
WORKDIR /build/TestBme680

RUN dotnet build -c Release --no-restore

FROM build as publish
RUN dotnet publish -c Release --no-build -o /publish

FROM nrandell/bme680.rpi:0.4 as bme680
FROM mcr.microsoft.com/dotnet/core/runtime:3.1.1-buster-slim-arm32v7 as final
WORKDIR /app
COPY --from=bme680 /build/libbme680.so .
COPY --from=publish /publish .

ENTRYPOINT ["dotnet", "TestBme680.dll"]
