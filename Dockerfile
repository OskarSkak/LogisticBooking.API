# docker build -t kritner/kritnerwebsite .
# docker run -d -p 5000:5000 kritner/kritnerwebsite
# docker push kritner/kritnerwebsite
# Runner image - Runtime + node for ng serve
#FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
#RUN apt-get update \
 #   && apt-get -y upgrade \
 #   && apt-get -y dist-upgrade \
 #   && apt-get install -y gnupg \
  #  && apt-get install -y sudo \
 #   && curl -sL deb.nodesource.com/setup_10.x | sudo -E bash - \
 #   && apt-get install -y nodejs
# Builder image - SDK + node for angular building
#FROM microsoft/dotnet:2.2-sdk AS build
#RUN apt-get update \
 #   && apt-get -y upgrade \
  #  && apt-get -y dist-upgrade \
   # && apt-get install -y gnupg \
#    && apt-get install -y sudo \
#    && curl -sL deb.nodesource.com/setup_10.x | sudo -E bash - \
 #   && apt-get install -y nodejs
#WORKDIR /src
# Copy only the csproj file(s), as the restore operation can be cached, 
# only "doing the restore again" if dependencies change.
#COPY ["./LogisticBooking.API/LogisticBooking.API.csproj", "LogisticBooking.API/LogisticBooking.API.csproj"]
#COPY ["./LogisticBooking.Documents/LogisticBooking.Documents.csproj", "LogisticBooking.Documents/LogisticBooking.Documents.csproj"]
#COPY ["./LogisticBooking.Domain/LogisticBooking.Domain.csproj", "LogisticBooking.Domain/LogisticBooking.Domain.csproj"]
#COPY ["./LogisticBooking.Events/LogisticBooking.Events.csproj", "LogisticBooking.Events/LogisticBooking.Events.csproj"]
#COPY ["./LogisticBooking.Infrastructure/LogisticBooking.Infrastructure.csproj", "LogisticBooking.Infrastructure/LogisticBooking.Infrastructure.csproj"]
#COPY ["./LogisticBooking.Persistence/LogisticBooking.Persistence.csproj", "LogisticBooking.Persistence/LogisticBooking.Persistence.csproj"]
#COPY ["./LogisticBooking.Queries/LogisticBooking.Queries.csproj", "LogisticBooking.Queries/LogisticBooking.Queries.csproj"]
# Run the restore on the main csproj file
#RUN dotnet restore "LogisticBooking.API/LogisticBooking.API.csproj"
#RUN dotnet restore "LogisticBooking.Events/LogisticBooking.Events.csproj"
#RUN dotnet restore "LogisticBooking.Documents/LogisticBooking.Documents.csproj"
#RUN dotnet restore "LogisticBooking.Domain/LogisticBooking.Domain.csproj"
#RUN dotnet restore "LogisticBooking.Infrastructure/LogisticBooking.Infrastructure.csproj"
#RUN dotnet restore "LogisticBooking.Persistence/LogisticBooking.Persistence.csproj"
#RUN dotnet restore "LogisticBooking.Queries/LogisticBooking.Queries.csproj"


# Contains the angular related dependencies, similar to csproj above result is cachable.

# Copy the actual files that will need building
#COPY ["./LogisticBooking.API/", "src/LogisticBooking.API"]
#COPY LogisticBooking.API/ ./src/LogisticBooking.API
#WORKDIR /src/LogisticBooking.API
# Build the .net source, don't restore (as that is its own cachable layer)
#RUN dotnet build -c Release -o /app --no-restore
 
#FROM build AS publish
# Perform a publish on the build code without rebuilding/restoring. Put it in /app
#RUN dotnet publish -c Release -o /app --no-restore --no-build
# The runnable image/code
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "LogisticBooking.API.dll"]

FROM microsoft/dotnet:2.2-sdk AS build

WORKDIR /app

COPY *.sln .
COPY LogisticBooking.API/*.csproj ./LogisticBooking.API/

COPY LogisticBooking.API/. ./LogisticBooking.API/
COPY LogisticBooking.Documents/. ./LogisticBooking.Documents/
COPY LogisticBooking.Domain/. ./LogisticBooking.Domain/
COPY LogisticBooking.Events/. ./LogisticBooking.Events/
COPY LogisticBooking.Infrastructure/ ./LogisticBooking.Infrastructure/
COPY LogisticBooking.Persistence ./LogisticBooking.Persistence/
COPY LogisticBooking.Queries ./LogisticBooking.Queries/
WORKDIR /app/LogisticBooking.API

RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-sdk AS Runtime

WORKDIR /app

COPY --from=build /app/LogisticBooking.API/out ./
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 8080
ENTRYPOINT ["dotnet", "LogisticBooking.API.dll", "--server.urls", "http://*:5000"]


