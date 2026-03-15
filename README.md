# ASP.NET Core Employee Management API

A clean and scalable **ASP.NET Core Web API** project for managing employee records.

This project demonstrates professional backend development practices including:

- Layered Architecture
- Repository Pattern
- Service Layer
- DTO Pattern
- Logging
- SQL Server Stored Procedures
- Clean Code Principles

---

## Project Architecture

```
Controller
   ↓
Service
   ↓
Repository
   ↓
SQL Server Database
```

---

## Features

- Create Employee
- Update Employee
- Delete Employee
- Get Employee By ID
- Get All Employees

---

## Technologies Used

- ASP.NET Core 8
- C#
- SQL Server
- ADO.NET
- Stored Procedures
- Dependency Injection
- Structured Logging

---

## Project Structure

```
EmployeeManagementAPI
│
├── Controllers
├── Services
├── Repositories
├── Models
│   ├── Entities
│   └── DTOs
├── Data
└── Program.cs
```

---

## Database

The project uses **SQL Server** with stored procedures.

Example procedures:

- `usp_Employee_Insert`
- `usp_Employee_Update`
- `usp_Employee_Delete`
- `usp_Employee_GetById`
- `usp_Employee_GetAll`

---

## How to Run the Project

1. Clone the repository

```
git clone https://github.com/YOUR_USERNAME/aspnet-core-employee-management-api.git
```

2. Open the solution in **Visual Studio**

3. Update the database connection string in:

```
appsettings.json
```

4. Run the project

---

## Author

Abhay Yadav  
Backend Developer (.NET / ASP.NET Core)
