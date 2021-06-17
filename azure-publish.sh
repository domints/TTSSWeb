cd ~/deploy_temp && \
sudo /usr/sbin/service $1 stop && \
rm -rf /var/aspnetcore/$1/* && \
tar -xzf artifact.tar.gz -C /var/aspnetcore/$1 && \
sudo /usr/sbin/service $1 start