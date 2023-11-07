FROM python:3.11.3

RUN pip install Flask
RUN pip install mysql-connector-python

COPY . /python/proj
WORKDIR /python/proj


EXPOSE 5050

CMD [ "sleep", "10s" ]
CMD [ "python","api.py" ]