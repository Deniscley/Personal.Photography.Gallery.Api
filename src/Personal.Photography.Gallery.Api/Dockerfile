#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Personal.Photography.Gallery.Api/Personal.Photography.Gallery.Api.csproj", "Personal.Photography.Gallery.Api/"]
RUN dotnet restore "Personal.Photography.Gallery.Api/Personal.Photography.Gallery.Api.csproj"
COPY . .
WORKDIR "/src/Personal.Photography.Gallery.Api"
RUN dotnet build "Personal.Photography.Gallery.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Personal.Photography.Gallery.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Personal.Photography.Gallery.Api.dll"]