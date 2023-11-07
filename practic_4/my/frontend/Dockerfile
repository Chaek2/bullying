FROM python:3.11.3

RUN pip install Flask
RUN pip install httpx

COPY . /python/proj
WORKDIR /python/proj

EXPOSE 9090

CMD [ "python","req.py" ]