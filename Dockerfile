FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build


WORKDIR /source


COPY . .

RUN dotnet restore "./SimpleWordAPI/SimpleWordAPI.csproj" --disable-parallel


RUN dotnet publish "./SimpleWordAPI/SimpleWordAPI.csproj" -c Release -o out

RUN dotnet restore "./SimpleWordModels/SimpleWordModels.csproj" --disable-parallel


RUN dotnet publish "./SimpleWordModels/SimpleWordModels.csproj" -c Release -o out




FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build /app/out .


ENTRYPOINT [ "dotnet", "SimpleWordAPI.dll" ]

