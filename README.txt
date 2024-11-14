чтобы поднять всё в контейнерах нужно в папке где находится docker-compose.yml выполнить команду docker compose up -d --force-recreate --no-deps --build и после этого можно открыть http://127.0.0.1:8080/index.html

чтобы поднять сервис локально нужно в папке где находится docker-compose.yml выполнить команду(чтобы запустить postgres) docker compose up -d --force-recreate --no-deps --build postgres
и в appsettings.Development.json поменять Host=postgres; на Host=localhost;

После поднятия бд нужно накатить миграции (через Package manager console запустить файл migrate.ps1)