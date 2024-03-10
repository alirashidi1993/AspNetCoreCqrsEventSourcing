#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EventSourcingCourse/EventSourcingCourse.csproj", "EventSourcingCourse/"]
COPY ["Auction.Infrastructure.Config/Auction.Infrastructure.Config.csproj", "Auction.Infrastructure.Config/"]
COPY ["Auction.Application/Auction.Application.csproj", "Auction.Application/"]
COPY ["Auction.Domain/Auction.Domain.csproj", "Auction.Domain/"]
COPY ["Framework.Domain/Framework.Domain.csproj", "Framework.Domain/"]
COPY ["Auctions.Application.Contracts/Auction.Application.Contracts.csproj", "Auctions.Application.Contracts/"]
COPY ["Auction.Infrastructure.Persistence.ES/Auction.Infrastructure.Persistence.ES.csproj", "Auction.Infrastructure.Persistence.ES/"]
COPY ["Framework.Core/Framework.Core.csproj", "Framework.Core/"]
COPY ["Framework.EventStore/Framework.EventStore.csproj", "Framework.EventStore/"]
COPY ["Framework.Persistence.ES/Framework.Persistence.ES.csproj", "Framework.Persistence.ES/"]
RUN dotnet restore "EventSourcingCourse/EventSourcingCourse.csproj"
COPY . .
WORKDIR "/src/EventSourcingCourse"
RUN dotnet build "EventSourcingCourse.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventSourcingCourse.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventSourcingCourse.dll"]