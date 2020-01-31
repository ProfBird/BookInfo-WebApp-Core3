ASP.NET Core MVC Web App

This web app demonstrates key concepts in the development of an ASP.NET Core MVC web app. The current version targets .NET Core 3.1 and was written using Visual Studio 2019. It includes connection strings for SQLite on Mac OS, SQL Server Local DB on Windows, and MariaDB on Linux.

Each of the following branches demonstrates a particular concept or technique:
1. **Initial**: This was copied from [LCC-CIT/CS295N-Bookinfo-Core-21](https://github.com/LCC-CIT/CS295N-Bookinfo-Core-21/tree/EF-SeedData), the project was updated to use .net core 3.1, and code supporting author views was added.
2. **Validation**: Added model validation to:
   -  The Book model and the associated view and controller action method.
   - The Author model and associated view and controller action methods.
3. **Identity**: Added Administrative features for user account management with Identity
4. **Authentication**: Added login and logout views and supporting controller methods and code in Startup.
5. **Authorization**: Added code to Startup and AppDbContext to support role base authorization. Created a seed Admins role and user.

**MultipleDbContexts**: Using multiple DbContexts and Migration folders. Use these CLI commands:
- `dotnet ef migrations add InitialCreate --context MySqlDbContext --output-dir Migrations/MySqlMigrations`
- `dotnet ef database update --context MySqlDbContext`