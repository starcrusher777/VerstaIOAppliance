#Запуск проекта
0. Если SDK.net 8 не установлен - установить его
1. Установить локально сервер MSSQL
2. Применить миграции с помощью EntityFramework (Выполнить в командной строке dotnet ef database update --project VerstaIOAppliance в директории проекта VerstaIOAppliance)
2.1. Если EntityFramework не усановлен глобально, выполнить в командной строке dotnet tool install --global dotnet-ef
3. В директории проекта VerstaIOAppliance.UI установить зависимости (Выполнить в командной строке npm install)
4. Запустить проект VerstaIOAppliance, с профилем http
5. Запустить проект VerstaIOAppliance.UI (Выполнить в командной строке npm run start в директории проекта VerstaIOAppliance.UI)
