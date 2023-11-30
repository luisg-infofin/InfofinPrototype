@echo off

echo ======================= Building Docker container =======================
CALL initDockerCompose.bat DEV NO

echo ======================= Launching Angular Client =======================
start cmd /k "cd clientApps/angular_app && ng serve -o"