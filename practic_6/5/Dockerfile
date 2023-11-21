FROM python:alpine
VOLUME [ "/data", "/app/images" ]
COPY /image /app/images
COPY /image /data
COPY main.py /app
RUN pip install Flask
EXPOSE 80
CMD [ "python","/app/main.py" ]