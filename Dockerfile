# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY SimpleWordMain/SimpleWordMain.csproj SimpleWordMain/SimpleWordMain.csproj 
COPY SimpleWordModels/SimpleWordModels.csproj SimpleWordModels/SimpleWordModels.csproj 
RUN dotnet restore SimpleWordMain/SimpleWordMain.csproj
RUN dotnet restore SimpleWordModels/SimpleWordModels.csproj


# copy everything else and build app
COPY SimpleWordMain/. ./SimpleWordMain/
COPY SimpleWordModels/. ./SimpleWordModels/

WORKDIR /source/
RUN dotnet publish SimpleWordMain/SimpleWordMain.csproj -c Release -o /app
RUN dotnet publish SimpleWordModels/SimpleWordModels.csproj -c Release -o /app



# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
COPY SimpleWordModels/Data/ISO639.csv ISO639.csv

ENTRYPOINT ["dotnet", "SimpleWordMain.dll"]