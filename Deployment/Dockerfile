ARG VERSION=3.1

FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build-env

WORKDIR /app

ENV PATH="${PATH}:/root/.dotnet/tools"

ADD . .

RUN chmod 777 build.sh && ./build.sh web-dev

RUN dotnet restore *.sln

RUN dotnet publish \
  -c Release \
  -o ./out \
  --no-restore

#-----------------
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime

ENV APP_HOME=/app
WORKDIR $APP_HOME

RUN adduser --disabled-password --gecos "" app -u 1000
ENV ASPNETCORE_URLS=http://*:5254
ENV COMPlus_EnableDiagnostics=0

ARG ENV
ENV ASPNETCORE_ENVIRONMENT ${ENV:-Production}

USER 1000
EXPOSE 5254 5254 
ENTRYPOINT ["dotnet", "WebApi.dll"]
