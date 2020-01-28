FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/core/sdk:3.1.100-buster as build

WORKDIR /build

COPY ["Nick.Rpi.Driver.Max44009/Nick.Rpi.Driver.Max44009.csproj", "Nick.Rpi.Driver.Max44009/"]
COPY ["TestMax44009/TestMax44009.csproj", "TestMax44009/"]

WORKDIR /build/TestMax44009
RUN dotnet restore

WORKDIR /build
COPY ["Nick.Rpi.Driver.Max44009/", "Nick.Rpi.Driver.Max44009/"]
COPY ["TestMax44009/", "TestMax44009/"]
WORKDIR /build/TestMax44009

RUN dotnet build -c Release --no-restore

FROM build as publish
RUN dotnet publish -c Release --no-build -o /publish

FROM nrandell/max44009.rpi:0.3 as max44009
FROM mcr.microsoft.com/dotnet/core/runtime:3.1.0-buster-slim-arm32v7 as final
WORKDIR /app
COPY --from=max44009 /build/libmax44009.so .
COPY --from=publish /publish .

ENTRYPOINT ["dotnet", "TestMax44009.dll"]
