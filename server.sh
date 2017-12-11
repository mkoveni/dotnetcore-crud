#!/bin/bash

sudo docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Std@Corp#%17' -p 1433:1433 --name testdb -d microsoft/mssql-server-linux:2017-latest