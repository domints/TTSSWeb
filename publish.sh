#!/bin/sh

git pull
npm --prefix TTSSWeb/TTSSWebClient/ install
/usr/bin/dotnet publish -c Release TTSSWeb
service ttssweb stop
rm -rf /var/aspnetcore/ttssweb
cp -r TTSSWeb/bin/Release/netcoreapp2.2/publish /var/aspnetcore/ttssweb
service ttssweb start
