# etapa de build
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /app

# copia apenas o csproj e restaura
COPY Restrichef.Api.csproj ./
RUN dotnet restore Restrichef.Api.csproj

# copia o restante do código
COPY . .
RUN dotnet publish Restrichef.Api.csproj -c Release -o out

# etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Restrichef.Api.dll"]
