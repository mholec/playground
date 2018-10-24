#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 49716
EXPOSE 44330

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY api/api.csproj api/
RUN dotnet restore api/api.csproj
COPY . .
WORKDIR /src/api
RUN dotnet build api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "api.dll"]
