#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Microservices/Orders/KIK.Microservice.Order.Api/KIK.Microservice.Order.Api.csproj", "src/Microservices/Orders/KIK.Microservice.Order.Api/"]
COPY ["src/Microservices/Orders/KIK.Microservice.Order.Application/KIK.Microservice.Order.Application.csproj", "src/Microservices/Orders/KIK.Microservice.Order.Application/"]
COPY ["src/Microservices/Orders/KIK.Microservice.Order.Abstraction/KIK.Microservice.Order.Abstraction.csproj", "src/Microservices/Orders/KIK.Microservice.Order.Abstraction/"]
RUN dotnet restore "./src/Microservices/Orders/KIK.Microservice.Order.Api/./KIK.Microservice.Order.Api.csproj"
COPY . .
WORKDIR "/src/src/Microservices/Orders/KIK.Microservice.Order.Api"
RUN dotnet build "./KIK.Microservice.Order.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KIK.Microservice.Order.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KIK.Microservice.Order.Api.dll"]