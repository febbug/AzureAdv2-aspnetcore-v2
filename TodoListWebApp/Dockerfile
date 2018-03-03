FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY TodoListWebApp/TodoListWebApp.csproj TodoListWebApp/
RUN dotnet restore
COPY . .
WORKDIR /src/TodoListWebApp
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TodoListWebApp.dll"]
