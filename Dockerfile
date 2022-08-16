FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY ../ ./
RUN dotnet publish -c Release -o out

FROM base as test
WORKDIR /testrun
COPY --from=base /app/out /testrun
ENTRYPOINT ["dotnet", "test", "SeleniumFramework.dll"]