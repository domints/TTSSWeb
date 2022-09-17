#!/bin/bash
cd ~/deploy_temp && \
echo "Stopping ttss service..." && \
sudo /usr/sbin/service ttss stop && \
echo "TTSS service stopped. Removing old app" && \
rm -rf /var/dotnet/ttss/* && \
echo "Old version removed. Unzipping artifacts" && \
tar -xzf artifact.tar.gz -C /var/dotnet/ttss && \
echo "Artifacts unzipped. Starting TTSS service..." && \
sudo /usr/sbin/service ttss start && \
echo "Deployment script finished!"