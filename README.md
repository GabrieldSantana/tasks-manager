# Tasks Manager API

![.NET](https://img.shields.io/static/v1?label=.NET&message=9&color=blue&style=for-the-badge&logo=dotnet)
![SQL
Server](https://img.shields.io/static/v1?label=Database&message=SQL%20Server&color=blue&style=for-the-badge&logo=microsoftsqlserver)
![Dapper](https://img.shields.io/static/v1?label=ORM&message=Dapper&color=green&style=for-the-badge)
![License](https://img.shields.io/static/v1?label=LICENSE&message=MIT&color=yellow&style=for-the-badge)

------------------------------------------------------------------------

# Table of Contents

-   Project Description
-   Features
-   Architecture
-   Folder Structure
-   Technologies Used
-   How to Run
-   API Endpoints
-   Database
-   Future Improvements
-   License

------------------------------------------------------------------------

# Project Description

Tasks Manager API is a RESTful API developed with C# and .NET 9 for task
management.

The project follows a layered architecture, separating responsibilities
into **Application**, **Domain**, **Infrastructure**, and **API**
layers. It applies modern development practices such as Dependency
Injection, Request/Response DTOs, FluentValidation, Dapper, centralized
exception handling, and UUID Version 7 identifiers.

The main goal of this project is to serve as a study and portfolio
application demonstrating clean architecture principles and good
practices commonly adopted in .NET applications.

------------------------------------------------------------------------

# Features

-   CRUD operations for tasks
-   Layered architecture
-   Dapper for data access
-   SQL Server database
-   UUID Version 7 identifiers
-   Request and Response DTOs
-   Object mapping with Mapster
-   Validation with FluentValidation
-   Global Exception Middleware
-   Dependency Injection
-   Swagger documentation

------------------------------------------------------------------------

# Architecture

``` text
Client
    │
    ▼
Controller
    │
    ▼
Service
    │
    ├── FluentValidation
    │
    ▼
Repository
    │
    ▼
SQL Server
```

All exceptions are handled by a Global Exception Middleware, providing
standardized HTTP responses.

------------------------------------------------------------------------

# Folder Structure

``` text
Application
├── Dtos
│   ├── Requests
│   └── Responses
├── Interfaces
├── Services
└── Validators

Domain
├── Enums
└── Models

Infrastructure
├── Interfaces
└── Repositories

TasksManager.API
├── Config
├── Contracts
├── Controllers
├── Middleware
└── Program.cs

Database
└── SCRIPT CREATE TASKS_MANAGER.sql
```

------------------------------------------------------------------------

# Technologies Used

-   .NET 9
-   ASP.NET Core Web API
-   SQL Server
-   Dapper
-   Mapster
-   FluentValidation
-   Swagger (Swashbuckle)

------------------------------------------------------------------------

# How to Run

``` bash
git clone https://github.com/your-user/tasks-manager-api.git

cd tasks-manager-api

dotnet restore

dotnet run
```

Access Swagger:

``` text
https://localhost:{PORT}/swagger
```

------------------------------------------------------------------------

# API Endpoints

| Method | Path             | Description           |
| ------ | ---------------- | --------------------- |
| GET    | `/api/task`      | Retrieve all tasks    |
| GET    | `/api/task/{id}` | Retrieve a task by ID |
| POST   | `/api/task`      | Create a new task     |
| PUT    | `/api/task`      | Update a task         |
| DELETE | `/api/task/{id}` | Delete a task         |

------------------------------------------------------------------------

# Database

**Database engine**

-   SQL Server

**Data access**

-   Dapper

**Identifier strategy**

-   UUID Version 7

**Database creation script**

``` text
DataBase/SCRIPT CREATE TASKS_MANAGER.sql
```

------------------------------------------------------------------------

# Future Improvements

Planned improvements:

-   JWT Authentication
-   Pagination and filtering
-   Logging with Serilog
-   Docker support
-   Unit Tests
-   Integration Tests

------------------------------------------------------------------------

# License

This project is licensed under the MIT License.
