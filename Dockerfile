# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY dotnet/*.sln .
COPY dotnet/SimpleWordMain/SimpleWordMain.csproj SimpleWordMain/SimpleWordMain.csproj 
COPY dotnet/SimpleWordColorTheme/SimpleWordColorTheme.csproj SimpleWordColorTheme/SimpleWordColorTheme.csproj 
COPY dotnet/SimpleWordPdfGenerator/SimpleWordPdfGenerator.csproj SimpleWordPdfGenerator/SimpleWordPdfGenerator.csproj 
COPY dotnet/SimpleWordDbContext/SimpleWordDbContext.csproj SimpleWordDbContext/SimpleWordDbContext.csproj 
COPY dotnet/SimpleWordModelExtention/SimpleWordModelExtention.csproj SimpleWordModelExtention/SimpleWordModelExtention.csproj 
COPY dotnet/SimpleWordFont/SimpleWordFont.csproj SimpleWordFont/SimpleWordFont.csproj 
COPY dotnet/SimpleWordModels/SimpleWordModels.csproj SimpleWordModels/SimpleWordModels.csproj 


RUN dotnet restore SimpleWordColorTheme/SimpleWordColorTheme.csproj 
RUN dotnet restore SimpleWordFont/SimpleWordFont.csproj 
RUN dotnet restore SimpleWordModels/SimpleWordModels.csproj 
RUN dotnet restore SimpleWordDbContext/SimpleWordDbContext.csproj 
RUN dotnet restore SimpleWordModelExtention/SimpleWordModelExtention.csproj 
RUN dotnet restore SimpleWordPdfGenerator/SimpleWordPdfGenerator.csproj 
RUN dotnet restore SimpleWordMain/SimpleWordMain.csproj 



# copy everything else and build app
COPY dotnet/. ./




WORKDIR /source/

RUN dotnet publish SimpleWordColorTheme/SimpleWordColorTheme.csproj  -c Release -o /app
RUN dotnet publish SimpleWordFont/SimpleWordFont.csproj  -c Release -o /app
RUN dotnet publish SimpleWordModels/SimpleWordModels.csproj  -c Release -o /app
RUN dotnet publish SimpleWordDbContext/SimpleWordDbContext.csproj  -c Release -o /app
RUN dotnet publish SimpleWordModelExtention/SimpleWordModelExtention.csproj   -c Release -o /app
RUN dotnet publish SimpleWordPdfGenerator/SimpleWordPdfGenerator.csproj  -c Release -o /app
RUN dotnet publish SimpleWordMain/SimpleWordMain.csproj -c Release -o /app
ADD MetaData/. /app/MetaData/



# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "SimpleWordMain.dll"]