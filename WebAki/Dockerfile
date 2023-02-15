FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebAki/WebAki.csproj", "WebAki/"]
RUN dotnet restore "WebAki/WebAki.csproj"
COPY . .
WORKDIR "/src/WebAki"
RUN dotnet build "WebAki.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAki.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAki.dll"]
