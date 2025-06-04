# 📚 RefDef Book Management System

This project is a **full-stack book management system** built using ASP.NET Core. It consists of:

- 🔧 **RESTful API** for managing Books, Authors, Categories, and Publishers
- 🌐 **MVC Web Front-End** for users to interact with the system
- 💾 **SQL Server Database** hosted on AWS RDS (Free Tier)



## 📁 Project Structure

RefDef

- RefDef.API -> ASP.NET Core Web API (controllers, models, dbcontext)
- RefDef.Web -> ASP.NET Core MVC frontend (views, controllers)
- RefDef.sln -> Visual Studio solution file
- README.md -> This file
- BookDb.sql -> Database export 



## 🔌 Features

- 📖 Create, read, update, delete (CRUD)
- 🧠 Connect books with authors, publishers, and categories
- 🔍 Search books by title
- 🎨 MVC front-end for admin panel
- ☁️ Hosted using AWS 




## 🚀 How to Run Locally

### 1. Clone the repository

git clone https://github.com/Ilyosbek13/RefDefProjectRepository.git
cd RefDefProjectRepository

### 2. Set up the database
Restore the database using BookDb backup file

### 3. Configure the connection string in:

RefDef.API/appsettings.json

### 4. Run both projects in Visual Studio

RefDef.API runs on https://localhost:7000/api
RefDef.Web runs on https://localhost:7133/books

🌐 API Endpoints (Sample)
GET /api/books

POST /api/books

GET /api/authors

POST /api/authors

You can test the API via Swagger UI:
https://localhost:7000/swagger


