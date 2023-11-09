FROM ubuntu:18.04

COPY calc.jar /new/
RUN apt-get update && apt-get install -y \
x11-apps \
openjdk-8-jdk \
xauth \
&& rm -rf /var/lib/apt/lists/*


ENV DISPLAY=:0

CMD ["java","-jar","/new/calc.jar"]