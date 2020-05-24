## Command to create the migration

```
> dotnet ef migrations add InitialCreate -s ./ -p ./ -c Beryl.Data.BerylSqliteContext -o Migrations
```

## Command to apply the migration to the database

```
> dotnet ef database update -s ./ -p ./ -c Beryl.Data.BerylSqliteContext
```
