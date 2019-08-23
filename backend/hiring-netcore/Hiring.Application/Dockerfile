FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Hiring.Application/Hiring.Application.csproj", "Hiring.Application/"]
RUN dotnet restore "Hiring.Application/Hiring.Application.csproj"
COPY . .
WORKDIR "/src/Hiring.Application"
RUN dotnet build "Hiring.Application.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Hiring.Application.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Hiring.Application.dll"]