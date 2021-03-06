FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
# Copy csproj and restore as distinct layers
COPY ["src/MyEats.Api/MyEats.Api.csproj", "src/MyEats.Api/"]
COPY ["src/MyEats.Business/MyEats.Business.csproj", "src/MyEats.Business/"]
COPY ["src/MyEats.Commons/MyEats.Commons.csproj", "src/MyEats.Commons/"]
COPY ["src/MyEats.Domain/MyEats.Domain.csproj", "src/MyEats.Domain/"]

RUN dotnet restore "src/MyEats.Api/MyEats.Api.csproj"
COPY . .
WORKDIR "/src/src/MyEats.Api"
RUN dotnet build "MyEats.Api.csproj" -c Release -o /app/build

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM build AS publish
RUN dotnet publish "MyEats.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyEats.Api.dll"]
