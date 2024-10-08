# Используйте официальный образ Node.js с LTS версией
FROM node:latest AS build

# Установите глобально Angular CLI
RUN npm install -g @angular/cli

# Скопируйте проект Angular в контейнер
WORKDIR /app
COPY . .

# Установите зависимости проекта
RUN npm install

# Сборка Angular 
RUN ng build --configuration=production

# Запустите сервер nginx для статических файлов
FROM nginx:latest

# Скопируйте сгенерированные файлы Angular из образа build
COPY --from=build /app/dist/accounting-system-university.frontend /usr/share/nginx/html

# Настройка nginx
COPY nginx.conf /etc/nginx/nginx.conf

# Запустите nginx
CMD ["nginx", "-g", "daemon off;"]