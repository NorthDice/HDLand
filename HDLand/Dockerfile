
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081



FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HDLand/HDLand.csproj", "HDLand/"]
COPY ["HDLand.Application/HDLand.Application.csproj", "HDLand.Application/"]
COPY ["HDLand.Logic/HDLand.Logic.csproj", "HDLand.Logic/"]
COPY ["HDLand.Persistance/HDLand.Persistance.csproj", "HDLand.Persistance/"]
RUN dotnet restore "./HDLand/HDLand.csproj"
COPY . .
WORKDIR "/src/HDLand"
RUN dotnet build "./HDLand.csproj" -c $BUILD_CONFIGURATION -o /app/build


FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HDLand.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HDLand.dll"]