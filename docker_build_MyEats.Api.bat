@ECHO OFF
docker build -t ocanica/myeats.api -f .\src\MyEats.Api\Dockerfile .
docker push ocanica/myeats.api