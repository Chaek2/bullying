FROM ubuntu:latest
RUN apt update && \
    apt upgrade -y && \
    apt install -y \
    sudo \
    wget \
    gpg \
    snapd \
    nano \
    xrdp \
    software-properties-common
EXPOSE 3389
ENV DISPLAY=host.docker.internal:0