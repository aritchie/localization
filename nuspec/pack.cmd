@echo off
del *.nupkg
nuget pack Acr.Localization.nuspec
rem nuget pack Acr.Localization.Api.Client.nuspec
pause