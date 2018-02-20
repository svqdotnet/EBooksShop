FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish/s} .
ENTRYPOINT ["dotnet", "SampleDemo1.dll"]
