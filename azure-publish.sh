#!/bin/bash
cd ~/deploy_temp && \
sudo /usr/sbin/service ttss stop && \
rm -rf /var/dotnet/ttss/* && \
tar -xzf artifact.tar.gz -C /var/dotnet/ttss && \
sudo /usr/sbin/service ttss start