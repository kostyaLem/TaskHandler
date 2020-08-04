#### TaskHandler.Api - ASP.NET Web API (без авторизации)
- Добавляет новые задачи в очередь сообщений
- Считывает все задачи из базы данных

------------

#### TaskHandler.Data - dll
- Модель данных системы. Содержит CRUD-репозиторий для управления задачами.
- Работает с экземпляром SQL Server Express.

------------

#### TaskHandler.QueueService - dll
- Приватная очередь сообщений.

------------

#### TaskHandler.Updater - Console
- Проверяет очередь каждые 10 секунд и добавляет новые задачи в базу данных.

### Nuget:
EF6, Autofac, AutoMapper, NLog
