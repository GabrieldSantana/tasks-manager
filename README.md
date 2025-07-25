# Tasks Manager API

![.NET](https://img.shields.io/static/v1?label=.NET\&message=API\&color=blue\&style=for-the-badge\&logo=dotnet)
![SQL Server](https://img.shields.io/static/v1?label=Database\&message=SQL%20Server\&color=blue\&style=for-the-badge\&logo=microsoftsqlserver)
![Entity Framework](https://img.shields.io/static/v1?label=ORM\&message=Entity%20Framework\&color=green\&style=for-the-badge)
![License](https://img.shields.io/static/v1?label=LICENSE\&message=MIT\&color=yellow\&style=for-the-badge)

## Table of Contents

* [Project Description](#project-description)
* [Features](#features)
* [Folder Structure](#folder-structure)
* [Technologies Used](#technologies-used)
* [How to Run the Application](#how-to-run-the-application)
* [Available Routes](#available-routes)
* [Database](#database)
* [License](#license)

---

## Project Description

Tasks Manager API is a simple CRUD RESTful API built with C# and .NET. It manages tasks, allowing operations like creating, retrieving, updating and deleting tasks. This project follows SOLID principles, good architecture practices (clean separation between Application, Domain, and Infrastructure), and versioned endpoints.

## Features

* ✅ List all tasks
* ✅ Get task by ID
* ✅ Create a new task
* ✅ Update an existing task
* ✅ Delete a task
* ✅ DTO mapping with Mapster
* ✅ Exception handling with custom error notifier
* ✅ Swagger enabled for API testing

## Folder Structure

```bash
TasksManager.API
├── Application
│   ├── Interfaces
│   │   ├── INotifier.cs
│   │   └── ITaskService.cs
│   └── Services
│       ├── Exceptions
│       └── TaskService.cs
├── Domain
│   ├── Dtos
│   │   └── TaskDTO.cs
│   ├── Enums
│   │   ├── PriorityEnum.cs
│   │   └── StatusEnum.cs
│   ├── Models
│   │   └── TaskModel.cs
│   └── Notification
│       └── Notification.cs
├── Infrastructure
│   ├── Interfaces
│   │   └── ITaskRepository.cs
│   └── Repositories
│       └── TaskRepository.cs
├── Controllers
│   └── TaskController.cs
├── DataBase
    └── SCRIPT CREATE TASKS_MANAGER.sql
```

## Technologies Used

* [.NET 8](https://dotnet.microsoft.com/en-us/download)
* [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
* [SQL Server](https://www.microsoft.com/en-us/sql-server)
* [Mapster](https://github.com/MapsterMapper/Mapster)
* [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)

## How to Run the Application

```bash
# Clone the repository
$ git clone https://github.com/your-username/tasksmanager-api.git

# Navigate to project directory
$ cd tasksmanager-api

# Restore dependencies
$ dotnet restore

# Run the application
$ dotnet run
```

Access the API at: `https://localhost:{PORT}/swagger`

## Available Routes

| Method | Path             | Description           |
| ------ | ---------------- | --------------------- |
| GET    | `/api/task`      | Retrieve all tasks    |
| GET    | `/api/task/{id}` | Retrieve a task by ID |
| POST   | `/api/task`      | Create a new task     |
| PUT    | `/api/task`      | Update a task         |
| DELETE | `/api/task/{id}` | Delete a task         |

## Database

* SQL Server
* EF Core migrations
* Models and Enums are located in the `Domain` layer
* Database script file: `DataBase/SCRIPT CREATE TASKS_MANAGER.sql`

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
