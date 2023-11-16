FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV TZ=Asia/Bangkok
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
ARG NUGET_REGISTRY_URL
RUN echo $Configuration && echo $NUGET_REGISTRY_URL
COPY ./.git* ./
COPY ./**/*.csproj .
COPY *.sln ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
RUN (dotnet restore "CqrsDotnet/CqrsDotnet.csproj" --no-cache -s $NUGET_REGISTRY_URL) || (dotnet restore "CqrsDotnet/CqrsDotnet.csproj" --no-cache)
COPY . .

FROM build AS publish
ARG Configuration=Debug
RUN cd CqrsDotnet && dotnet publish -c $Configuration -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=PUBLISH /app/publish .
ENTRYPOINT ["dotnet", "CqrsDotnet.dll"]
