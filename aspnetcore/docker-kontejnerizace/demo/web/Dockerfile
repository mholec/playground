#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 22692
EXPOSE 44349

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["web/web.csproj", "web/"]
RUN dotnet restore "web/web.csproj"
COPY . .
WORKDIR "/src/web"
RUN dotnet build "web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "web.dll"]