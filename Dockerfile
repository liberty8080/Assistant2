FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["Assistant2.server/Assistant2.server.csproj", "Assistant2.server/"]
RUN dotnet restore "Assistant2.server/Assistant2.server.csproj"
COPY . .
WORKDIR "/src/Assistant2.server"
RUN dotnet build "Assistant2.server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Assistant2.server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Assistant2.server.dll"]
