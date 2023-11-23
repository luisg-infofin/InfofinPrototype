@echo off

IF "%~2" == "" GOTO NO_CREDS_GIVEN
IF "%~3" == "" GOTO NO_CREDS_GIVEN

ECHO ======================= Login in container-registry.oracle.com =======================
docker login --username=%2 --password=%3 container-registry.oracle.com

IF %1 == DEV GOTO DEV_DOCKER_COMPOSE
IF %1 == PROD GOTO PROD_DOCKER_COMPOSE
GOTO ARGUMENT_INVALID

:DEV_DOCKER_COMPOSE
echo ======================= Building Crud API =======================

docker compose -f docker-compose.dev.yml build crud-api

echo ======================= Building Identity API =======================

docker compose -f docker-compose.dev.yml build identity-svc

echo ======================= Building container =======================

docker compose -f docker-compose.dev.yml up -d 

echo ======================= Build finished =======================

GOTO END_FILE

:ARGUMENT_INVALID
echo Invalid enviroment given argument

:NO_CREDS_GIVEN
echo Must provide credentials in order to login in container-registry.oracle.com

:END_FILE