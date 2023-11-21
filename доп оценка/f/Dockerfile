FROM ubuntu:18.04
ENV WINEPREFIX=/root/wine
ENV WINEARCH=win32
COPY . /app

RUN dpkg --add-architecture i386 && \
    apt update && \
    apt upgrade -y && \
    apt install -y wine-development && \
    apt autoremove && \
    rm -rf /var/lib/apt/lists/*

ENV DISPLAY=host.docker.internal:0