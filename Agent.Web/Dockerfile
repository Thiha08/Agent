#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Agent.Web/Agent.Web.csproj", "Agent.Web/"]
COPY ["Agent.Infrastructure/Agent.Infrastructure.csproj", "Agent.Infrastructure/"]
COPY ["Agent.SharedKernel/Agent.SharedKernel.csproj", "Agent.SharedKernel/"]
COPY ["Agent.Core/Agent.Core.csproj", "Agent.Core/"]
COPY ["OnePay.PaymentApi/OnePay.PaymentApi.csproj", "OnePay.PaymentApi/"]
COPY ["OnePay.TransactionApi/OnePay.TransactionApi.csproj", "OnePay.TransactionApi/"]
RUN dotnet restore "Agent.Web/Agent.Web.csproj"
COPY . .
WORKDIR "/src/Agent.Web"
RUN dotnet build "Agent.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Agent.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Agent.Web.dll"]
