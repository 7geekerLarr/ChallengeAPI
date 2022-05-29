FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR webapi

EXPOSE 80
EXPOSE 5010

COPY ./*.csproj ./
RUN dotnet restore

COPY . . 
RUN dotnet publish -c Release -o output

FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /webapi
COPY --from=build /webapi/output .
ENTRYPOINT ["dotnet","Challenge.dll"]
