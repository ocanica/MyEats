@ECHO OFF
REM Removes other images which are exposing port 80, basically removes the previous deployment.
FOR /f "tokens=*" %%i IN ('docker ps -a -f "expose=80" -q'); DO docker stop %%i && docker rm %%i
REM Start the image binding port 5001 on your local machine to port 80 within the container
REM This is done because when you do dotnet publish it assumes production and therefore exposes port 80
docker run -p 5001:80 ocanica/myeats.api