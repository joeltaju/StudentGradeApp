FROM mcr.microsoft.com/dotnet/aspnet:10.0-nanoserver-ltsc2022 AS base
WORKDIR /app
EXPOSE 5155

ENV ASPNETCORE_URLS=http://+:5155

FROM mcr.microsoft.com/dotnet/sdk:10.0-nanoserver-ltsc2022 AS build
ARG configuration=Release
WORKDIR /src
COPY ["StudentGradeApp.csproj", "./"]
RUN dotnet restore "StudentGradeApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "StudentGradeApp.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "StudentGradeApp.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentGradeApp.dll"]
