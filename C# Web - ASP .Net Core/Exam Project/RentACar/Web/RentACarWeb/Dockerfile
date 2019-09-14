FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Web/RentACarWeb/RentACarWeb.csproj", "Web/RentACarWeb/"]
COPY ["Web/RentACar.Web.ViewModels/RentACar.Web.ViewModels.csproj", "Web/RentACar.Web.ViewModels/"]
COPY ["Web/RentACar.Web.BindingModels/RentACar.Web.BindingModels.csproj", "Web/RentACar.Web.BindingModels/"]
COPY ["Services/RentACar.Services.Models/RentACar.Services.Models.csproj", "Services/RentACar.Services.Models/"]
COPY ["Data/RentACar.Data.Models/RentACar.Data.Models.csproj", "Data/RentACar.Data.Models/"]
COPY ["Services/RentACar.Service.Mapping/RentACar.Service.Mapping.csproj", "Services/RentACar.Service.Mapping/"]
COPY ["Data/RentACar.Data/RentACar.Data.csproj", "Data/RentACar.Data/"]
COPY ["Services/RentACar.Services/RentACar.Services.csproj", "Services/RentACar.Services/"]
RUN dotnet restore "Web/RentACarWeb/RentACarWeb.csproj"
COPY . .
WORKDIR "/src/Web/RentACarWeb"
RUN dotnet build "RentACarWeb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RentACarWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RentACarWeb.dll"]