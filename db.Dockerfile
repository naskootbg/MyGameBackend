FROM mcr.microsoft.com/mssql/server:latest AS sqlserver
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=myPassword1!

# Add optional environment variable for database name
ENV MSSQL_DBNAME=mygame_db