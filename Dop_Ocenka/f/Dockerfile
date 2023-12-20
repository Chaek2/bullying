FROM ubuntu:latest
RUN apt update && \
    apt upgrade -y && \
    apt install -y \
    sudo \
    wget \
    gpg \
    snapd \
    software-properties-common
ENV DISPLAY=host.docker.internal:0