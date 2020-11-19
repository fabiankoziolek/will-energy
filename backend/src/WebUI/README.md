# Migrations

Create database manually first.

Create a new migration

`dotnet ef migrations add "SampleMigration" --project src/Infrastructure --startup-project src/WebUI --output-dir Persistence/Migrations`

Update database

`dotnet ef database update --project src/Infrastructure --startup-project src/WebUI`
