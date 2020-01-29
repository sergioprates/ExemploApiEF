docker pull mcr.microsoft.com/mssql/server

docker volume create bancodedados

#-Rodar o container
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=mudar@123" -p 1433:1433 -v bancodedados:/var/opt/mssql -d mcr.microsoft.com/mssql/server
