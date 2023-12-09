FROM ubuntu:latest
COPY DOCK.exe DOCK.exe
RUN apt update && \
    apt upgrade -y && \
    apt install -y \
    sudo \
    wget \
    gpg \
    software-properties-common
ENV DISPLAY=host.docker.internal:0