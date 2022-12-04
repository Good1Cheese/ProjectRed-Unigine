@echo off
chcp 65001
setlocal EnableDelayedExpansion
set app=bin\ProjectRed_x64.dll
$(ADDITIONAL_PATH)
start "" dotnet "%app%" 
