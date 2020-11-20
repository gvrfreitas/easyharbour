FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
RUN apt update
RUN apt install -y apt-utils \
        libgdiplus \
        libc6-dev
RUN ln -s /usr/lib/libgdiplus.so /usr/lib/gdiplus.dll
RUN ln -s /usr/lib/libgdiplus.so /lib/x86_64-linux-gnu/libgdiplus.so
RUN apt install -y --no-install-recommends zlib1g \
        fontconfig \
        libfreetype6 \
        libx11-6 \
        libxext6 \
        libxrender1 \
        wget \
        gdebi \
        libssl1.0-dev

RUN wget https://github.com/wkhtmltopdf/wkhtmltopdf/releases/download/0.12.5/wkhtmltox_0.12.5-1.stretch_amd64.deb
RUN gdebi --n wkhtmltox_0.12.5-1.stretch_amd64.deb
RUN ln -s /usr/local/lib/libwkhtmltox.so /usr/lib/libwkhtmltox.so
WORKDIR /app
EXPOSE 80

ENV EASY_HARBOUR_STRINGCONEXAO__PADRAO="Data Source=tcp:easy-harbour.database.windows.net, 1433;Initial Catalog=easy-harbour;User ID=easy-harbour-user;Password=Dtamasa2007;MultipleActiveResultSets=True; Trusted_Connection=False"
ENV EASY_HARBOUR_CLIMA__CIDADE="36358"
ENV EASY_HARBOUR_CLIMA__APIKEY="wNWiX03ul6Xp9NrlU9jbK8EQTru9hLaw"
ENV EASY_HARBOUR_CLIMA__URL="http://dataservice.accuweather.com/"


FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["easyharbour/easyharbour.Api.csproj", "easyharbour.Api/"]
RUN true
COPY ["easyharbour.Common/easyharbour.Common.csproj", "easyharbour.Common/"]
RUN true
COPY ["easyharbour.DTO/easyharbour.DTO.csproj", "easyharbour.DTO/"]
RUN true
COPY ["easyharbour.Repositorio/easyharbour.Dados.csproj", "easyharbour.Repositorio/"]
RUN true
COPY ["easyharbour.Models/easyharbour.Model.csproj", "easyharbour.Models/"]
RUN true
COPY ["easyharbour.Servico/easyharbour.Servico.csproj", "easyharbour.Servico/"]
RUN true


RUN dotnet restore "easyharbour.Api/easyharbour.Api.csproj"
COPY . .
WORKDIR "/src/easyharbour"
RUN dotnet build "easyharbour.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "easyharbour.Api.csproj" -c Release -o /app/publish


# Change timezone to local time
ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "easyharbour.Api.dll"]



