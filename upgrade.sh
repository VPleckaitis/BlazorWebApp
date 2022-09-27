#!/bin/bash
#first we set git repository path
gitPath=https://github.com/VPleckaitis/BlazorWebApp.git
#then specify application folder name in /var/www
appFolder=vytas-app
#and we need to know service name as well - so we can stop/start it
appServiceName=vytasapp.service

mkdir -p /var/www/${appFolder} #create folder if it doesn't exist
chown ${USER}:${USER} /var/www/${appFolder} # change owner of folder to current user
mkdir -p /var/www/${appFolder}-tmp #create temp folder
chown ${USER}:${USER} /var/www/${appFolder}-tmp
echo ... Cloning repository to ${appFolder}-tmp
git clone ${gitPath} /var/www/${appFolder}-tmp
cd /var/www/${appFolder}-tmp
dotnet build
dotnet publish
mv wwwroot -v /var/www/${appFolder}

cd ./bin/Debug/net6.0/publish
rm appsettings* #delete all appsettings files
echo Stopping current service
systemctl stop ${appServiceName}
echo Moving new files
mv *.* /var/www/${appFolder}
echo Starting service
systemctl start ${appServiceName}
echo Removing temporary files
rm /var/www/${appFolder}-tmp -rf
