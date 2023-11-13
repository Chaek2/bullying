FROM mcr.microsoft.com/dotnet/framework/runtime:4.8-windowsservercore-ltsc2019
 
ENV DISPLAY=host.docker.internal:0
# Создание рабочей директории в контейнере
WORKDIR /app
 
# Копирование файлов приложения в контейнер
COPY DOCK.exe .
COPY App.config .
 
# Открытие порта, на котором приложение будет слушать (по умолчанию 8080)
EXPOSE 8080
 
# Запуск приложения при запуске контейнера
CMD ["/app/DOCK.exe"]

