чтобы поднять всё в контейнерах нужно в папке где находится docker-compose.yml выполнить команду docker compose up -d --force-recreate --no-deps --build и после этого в appsettings.Development.json поменять Host=postgres; на Host=localhost;

После поднятия нужно накатить миграции (через Package manager console запустить файл migrate.ps1)
