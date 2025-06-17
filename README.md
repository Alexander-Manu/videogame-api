 
A simple .NET 9 Web API for managing video game data using C# and Entity Framework Core

# 🎮 Video Game API with C#

Date: June 17, 2025  
**Inspired by:** Patrick God on YouTube

This project is a complete **.NET 9 Web API** built in **C#**, featuring full **CRUD operations** for managing video game records. It follows RESTful API principles and uses **Entity Framework Core** with **SQL Server** for data persistence.

---

## 🚀 Features

- ✅ Create, Read, Update, and Delete (CRUD) video game entries
- ✅ HTTP request methods: `GET`, `POST`, `PUT`, `DELETE`
- ✅ Uses **Entity Framework Core** for database interaction
- ✅ Generates interactive API documentation using `Scaler.AspNetCore`

---

## 🧰 Tech Stack

- [Visual Studio](https://visualstudio.microsoft.com/)
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- SQL Server Express
- SQL Server Management Studio (SSMS)

---

## 📦 Required NuGet Packages

- `Scaler.AspNetCore` – Beautiful interactive Swagger docs
- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.Tools`
- `Microsoft.EntityFrameworkCore.SqlServer`

---

## 🛠️ Setup Instructions

### 1. Clone the repository
```bash
git clone https://github.com/yourusername/videogame-api.git
cd videogame-api

### 2. Open the project in Visual Studio
## Make sure you have:

.NET 9 SDK installed

SQL Server Express running

SSMS (optional for DB inspection)

### 3. Configure the database
### In appsettings.json, update the connection string if needed:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLExpress;Database=VideoGameDb;Trusted_Connection=True;TrustServerCertificate=true;"
}

### 4. Apply migrations and update the database
### Using Package Manager Console:

```powershell

Update-Database

### Or using .NET CLI:

```bash

dotnet ef database update

### 5. Run the project
Hit F5 in Visual Studio or use the CLI:

```bash

dotnet run

### 6. Test the API
Navigate to:

https://localhost:{your-port}/scalar/v1
