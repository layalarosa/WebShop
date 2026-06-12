WebShop
=======

Lightweight ASP.NET Core 3.1 sample e-commerce site (games store).

Summary
-------
- ASP.NET Core 3.1 MVC app with Identity and Entity Framework Core (SQL Server).
- Uses a simple domain: Game, Category, ShoppingCart, Order, Identity users.
- Project path: WebShop (target framework netcoreapp3.1)

Prerequisites
-------------
- .NET Core SDK 3.1 installed
- (Recommended) LocalDB or SQL Server instance to host the database
- Optional: Visual Studio 2019/2022/2026 or VS Code

Configuration
-------------
- The application reads the connection string from appsettings.json (key: ConnectionStrings:DefaultConnection).
- By default appsettings.json points to LocalDB (Server=(localdb)\\mssqllocaldb;Database=WebShopDb;...)
- appsettings.Development.json contains only logging settings and will not override the connection string.
- appsettings.json and appsettings.Development.json are ignored by Git (see .gitignore). Do not commit secrets.

Database
--------
- To create the database and apply migrations (from project root):
  dotnet ef database update

Run the app
----------
- From project root:
  dotnet run
- Or run from Visual Studio.

Notes & troubleshooting
-----------------------
- If you see SQL login errors, either switch the connection string to LocalDB, or add your Windows account to SQL Server logins and grant appropriate permissions.
- The UI was updated to use Bootstrap 5. Some old Bootstrap 3 markup may need small adjustments.

Contributing
------------
- Fixes and improvements are welcome. Keep appsettings out of commits.

License
-------
- See project files. No license file included by default.
