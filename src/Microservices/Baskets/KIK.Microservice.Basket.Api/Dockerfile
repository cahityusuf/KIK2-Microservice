#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Microservices/Baskets/KIK.Microservice.Basket.Api/KIK.Microservice.Basket.Api.csproj", "src/Microservices/Baskets/KIK.Microservice.Basket.Api/"]
COPY ["src/Microservices/Baskets/KIK.Microservice.Basket.Abstraction/KIK.Microservice.Basket.Abstraction.csproj", "src/Microservices/Baskets/KIK.Microservice.Basket.Abstraction/"]
COPY ["src/Microservices/Baskets/KIK.Microservices.Basket.Application/KIK.Microservices.Basket.Application.csproj", "src/Microservices/Baskets/KIK.Microservices.Basket.Application/"]
RUN dotnet restore "./src/Microservices/Baskets/KIK.Microservice.Basket.Api/./KIK.Microservice.Basket.Api.csproj"
COPY . .
WORKDIR "/src/src/Microservices/Baskets/KIK.Microservice.Basket.Api"
RUN dotnet build "./KIK.Microservice.Basket.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KIK.Microservice.Basket.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KIK.Microservice.Basket.Api.dll"]