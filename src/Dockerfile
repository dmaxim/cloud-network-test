FROM mcr.microsoft.com/dotnet/aspnet:5.0.9-focal-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM  mcr.microsoft.com/dotnet/sdk:5.0 AS build 
WORKDIR /src
COPY Mx.EntityFramework/Mx.EntityFramework.csproj Mx.EntityFramework/
COPY Mx.EntityFramework.Contracts/Mx.EntityFramework.Contracts.csproj Mx.EntityFramework.Contracts/
COPY Network.UI/Network.UI.csproj Network.UI/


RUN dotnet restore Network.UI/Network.UI.csproj
COPY . .
WORKDIR /src/Network.UI

RUN dotnet build Network.UI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Network.UI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Network.UI.dll"]

