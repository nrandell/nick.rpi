FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/core/sdk:3.1.101-buster as build-dotnet

WORKDIR /build

COPY ["Directory.Build.props", "./"]
COPY ["Nick.Rpi.Driver.Temperature/Nick.Rpi.Driver.Temperature.csproj", "Nick.Rpi.Driver.Temperature/"]

WORKDIR /build/Nick.Rpi.Driver.Temperature
RUN dotnet restore

WORKDIR /build
COPY ["Nick.Rpi.Driver.Temperature/", "Nick.Rpi.Driver.Temperature/"]

WORKDIR /build/Nick.Rpi.Driver.Temperature
RUN dotnet build -c Release --no-restore

FROM build-dotnet as publish
RUN dotnet pack -c Release --no-build -o /publish

WORKDIR /publish
ARG NUGET_API_KEY
RUN ls -l && dotnet nuget push *.nupkg --source "https://api.nuget.org/v3/index.json" --api-key ${NUGET_API_KEY}

