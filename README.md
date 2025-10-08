# SmartInventory API

A simple **Inventory Management Web API** built with **ASP.NET Core**, **Entity Framework Core**, and **SQLite**.  
Includes **seeded demo data** and **Swagger UI** for testing.

---

## 🧠 Tech Stack
- ASP.NET Core (Web API)
- Entity Framework Core
- SQLite (Local DB)
- Swagger UI
- C#

---

## 🚀 Features
- ✅ CRUD APIs for **Products** & **Categories**
- ✅ Auto Migrations + Database Seeding
- ✅ Swagger UI for API testing
- ✅ Clean Architecture Setup

---

## ⚙️ Setup & Run Locally

Follow these steps to run the project on your machine 👇

```bash
# 1️⃣ Clone the repository
git clone https://github.com/Mustafa732/SmartInventory.git

# 2️⃣ Navigate to API project
cd SmartInventory/SmartInventory.Api

# 3️⃣ Restore dependencies
dotnet restore

# 4️⃣ Add your own database configuration (if needed)
# By default, it uses SQLite (check appsettings.json)
# If you switch DB, update the connection string & provider

# 5️⃣ Apply EF Core migrations
dotnet ef migrations add InitialCreate
dotnet ef database update

# 6️⃣ Run the project
dotnet run
