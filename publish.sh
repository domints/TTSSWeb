#!/bin/bash

echo "Refreshing sources...\n"
git pull
echo "\nInstalling npm packages...\n"
npm --prefix TTSSWeb/TTSSWebClient/ install
echo "\nBuilding angular...\n"
pushd TTSSWeb/TTSSWebClient/
ng build --prod
popd
echo "\nBuilding .NET Core...\n"
/usr/bin/dotnet publish -c Release TTSSWeb
echo "\nPublishing artifacts...\n"
service ttssweb stop
rm -rf /var/aspnetcore/ttssweb
cp -r TTSSWeb/bin/Release/netcoreapp2.2/publish /var/aspnetcore/ttssweb
service ttssweb start
echo "Done!"
