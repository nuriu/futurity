FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY back-end.sln ./
COPY Futurity.Api/*.csproj ./Futurity.Api/
COPY Futurity.Application/*.csproj ./Futurity.Application/
COPY Futurity.Core/*.csproj ./Futurity.Core/
COPY Futurity.Persistence/*.csproj ./Futurity.Persistence/
COPY Futurity.Tests/*.csproj ./Futurity.Tests/

RUN dotnet restore
COPY . .

WORKDIR /src/Futurity.Api
RUN dotnet build -c Release -o /app

WORKDIR /src/Futurity.Application
RUN dotnet build -c Release -o /app

WORKDIR /src/Futurity.Core
RUN dotnet build -c Release -o /app

WORKDIR /src/Futurity.Persistence
RUN dotnet build -c Release -o /app

WORKDIR /src/Futurity.Tests
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Futurity.Api.dll"]
