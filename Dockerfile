FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 6009
EXPOSE 6019

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY src/ /src/

WORKDIR /src/
RUN dotnet restore --configfile "NuGet.Config"
COPY . .
WORKDIR "/src/xxxxx"
RUN dotnet build "xxxxx.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "xxxxx.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime \
&& echo 'Asia/shenzhen' >/etc/timezone

ENTRYPOINT ["/usr/bin/dotnet", "xxxxx.dll"]