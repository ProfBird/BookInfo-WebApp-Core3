# MultipleDbContexts Branch Notes

On this branch, I'm trying to solve the problem that if you add migrations based on one database provider, then try to run on another machine using a different database provider, the migration will sometimes fail when you try to update the database. Migrations need to be added using the same database.

One solution is to use multiple  DbContexts and Migration folders. Then you can specify which database provider to use by specifying the associated DbContext. 

This code is based on [ASP.NET Core - EF Core Migrations for Multiple Databases (SQLite and SQL Server)](https://jasonwatmore.com/post/2020/01/03/aspnet-core-ef-core-migrations-for-multiple-databases-sqlite-and-sql-server), by Jason Watmore.

In order to add migrations or update the databae, use these CLI commands:

- `dotnet ef migrations add InitialCreate --context MySqlDbContext --output-dir Migrations/MySqlMigrations`
- `dotnet ef database update --context MySqlDbContext`