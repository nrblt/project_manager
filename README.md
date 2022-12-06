# project_manager

Guide "How to run this project?"

Step 1. Make sure you have .Net 6 installed in your computer

```
dotnet --version
```

Step 2. Download this project.

```
git clone https://github.com/nrblt/project_manager/
```

Step 3. Open appsettings.json file and write your PostgreSQL credentials at "PMDbConnectionString"

Step 4. Run this command to migrate tables from project

```
dotnet ef database update
```

Step 5. Run this app
```
dotnet run
```

Step 6. Invite me to interview :)

Congratulations !!!

To open Swagger, first run this app, then add "/swagger/index.html" to your server url
