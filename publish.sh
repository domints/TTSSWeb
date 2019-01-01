#!/bin/bash

echo -e "Refreshing sources..."
git pull
echo -e "\nInstalling npm packages..."
npm --prefix TTSSWeb/TTSSWebClient/ install
echo -e "\nBuilding angular..."
pushd TTSSWeb/TTSSWebClient/
ng build --prod
popd
echo -e "\nBuilding .NET Core..."
/usr/bin/dotnet publish -c Release TTSSWeb
echo -e "\nPublishing artifacts..."
service ttssweb stop
rm -rf /var/aspnetcore/ttssweb
cp -r TTSSWeb/bin/Release/netcoreapp2.2/publish /var/aspnetcore/ttssweb
service ttssweb start
echo "Done!"
