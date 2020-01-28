FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/core/sdk:3.1.100-buster as build

WORKDIR /build

COPY ["Directory.Build.props", "./"]
COPY ["Nick.Rpi.Driver.Temperature/Nick.Rpi.Driver.Temperature.csproj", "Nick.Rpi.Driver.Temperature/"]
COPY ["TestOneWire/TestOneWire.csproj", "TestOneWire/"]

WORKDIR /build/TestOneWire
RUN dotnet restore

WORKDIR /build
COPY ["Nick.Rpi.Driver.Temperature/", "Nick.Rpi.Driver.Temperature/"]
COPY ["TestOneWire/", "TestOneWire/"]
WORKDIR /build/TestOneWire

RUN dotnet build -c Release --no-restore

FROM build as publish
RUN dotnet publish -c Release --no-build -o /publish

FROM mcr.microsoft.com/dotnet/core/runtime:3.1.0-buster-slim-arm32v7 as final
WORKDIR /app
COPY --from=publish /publish .

ENTRYPOINT ["dotnet", "TestOneWire.dll"]
