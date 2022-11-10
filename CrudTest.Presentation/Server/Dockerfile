#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CrudTest.Presentation/Server/CrudTest.Presentation.Server.csproj", "CrudTest.Presentation/Server/"]
COPY ["CrudTest.Core/Services/CrudTest.Core.Services.csproj", "CrudTest.Core/Services/"]
COPY ["CrudTest.Core/Services.Abstractions/CrudTest.Core.Services.Abstractions.csproj", "CrudTest.Core/Services.Abstractions/"]
COPY ["CrudTest.Core/Contracts/CrudTest.Core.Contracts.csproj", "CrudTest.Core/Contracts/"]
COPY ["CrudTest.Core/Domain/CrudTest.Core.Domain.csproj", "CrudTest.Core/Domain/"]
COPY ["CrudTest.Infrastructure/Presistance/CrudTest.Infrastructure.Presistance.csproj", "CrudTest.Infrastructure/Presistance/"]
COPY ["CrudTest.Presentation/Front/CrudTest.Presentation.Front.csproj", "CrudTest.Presentation/Front/"]
RUN dotnet restore "CrudTest.Presentation/Server/CrudTest.Presentation.Server.csproj"
COPY . .
WORKDIR "/src/CrudTest.Presentation/Server"
RUN dotnet build "CrudTest.Presentation.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CrudTest.Presentation.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CrudTest.Presentation.Server.dll"]

#RUN chmod +x ./entrypoint.sh
#CMD /bin/bash ./entrypoint.sh