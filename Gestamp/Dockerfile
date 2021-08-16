#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Gestamp/Gestamp.API.csproj", "Gestamp/"]
RUN dotnet restore "Gestamp/Gestamp.API.csproj"
COPY . .
WORKDIR "/src/Gestamp"
RUN dotnet build "Gestamp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gestamp.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gestamp.dll"]