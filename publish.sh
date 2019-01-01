#!/bin/bash

git pull
npm --prefix TTSSWeb/TTSSWebClient/ install
pushd TTSSWeb/TTSSWebClient/
ng build --prod
popd
/usr/bin/dotnet publish -c Release TTSSWeb
service ttssweb stop
rm -rf /var/aspnetcore/ttssweb
cp -r TTSSWeb/bin/Release/netcoreapp2.2/publish /var/aspnetcore/ttssweb
service ttssweb start
