FROM ubuntu:latest
COPY . DOCK.exe
RUN dpkg --add-architecture i386
RUN apt-get update
RUN apt-get install --no-install-recommends --assume-yes wine32
ENV DISPLAY=host.docker.internal:0
