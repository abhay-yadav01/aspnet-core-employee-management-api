# 🚀 ASP.NET Core Employee Management API

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![C#](https://img.shields.io/badge/Language-C%23-239120?logo=csharp)
![API](https://img.shields.io/badge/Type-Web%20API-green)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-orange)
![Database](https://img.shields.io/badge/Database-SQL%20Server-CC2927?logo=microsoftsqlserver)
![Status](https://img.shields.io/badge/Status-Production--Ready-brightgreen)
![License](https://img.shields.io/badge/License-MIT-yellow)

---

## 📌 Project Overview

A **clean, scalable, and production-ready ASP.NET Core Web API** designed for managing employee records efficiently.

This project is built using **enterprise-level backend development practices** and follows a **Clean Architecture approach** with proper separation of concerns, making it easy to maintain, extend, and scale.

---

## 🧠 Key Highlights

- **Layered Architecture** — Clear separation of concerns across Controller, Service, and Repository layers
- **Repository + Service Pattern** — Decoupled data access and business logic
- **DTO-Based Data Transfer** — Clean input/output models separate from database entities
- **Centralized Logging** — Structured logging via `ILogger` throughout all layers
- **SQL Server Stored Procedures** — Secure and optimized database operations
- **Dependency Injection** — Built-in .NET DI container for loose coupling
- **Clean Code Principles** — Readable, maintainable, and well-organized codebase
- **SOLID Principles** — Industry-standard design guidelines applied throughout

---

## 🏗️ System Architecture

```
Client Request
      ↓
Controller Layer      ← Handles HTTP requests/responses
      ↓
Service Layer         ← Business logic and validation
      ↓
Repository Layer      ← Data access abstraction
      ↓
SQL Server            ← Stored procedures for CRUD operations
```

---

## ⚙️ Features

| Feature | Description |
|---|---|
| ➕ Create Employee | Add a new employee record to the database |
| ✏️ Update Employee | Modify existing employee information |
| ❌ Delete Employee | Remove an employee record by ID |
| 🔍 Get Employee By ID | Retrieve a single employee's details |
| 📋 Get All Employees | Fetch the complete list of all employees |

---

## 🧰 Technologies Used

| Technology | Purpose |
|---|---|
| ASP.NET Core 8 | Web API framework |
| C# (.NET 8) | Primary programming language |
| ADO.NET | Low-level database access |
| SQL Server | Relational database engine |
| Stored Procedures | Encapsulated DB operations |
| Dependency Injection | Built-in .NET IoC container |
| ILogger (Structured Logging) | Application-level logging |

---

## 📁 Project Structure

```
EmployeeManagementAPI/
│
├── Controllers/           → API endpoint handlers (HTTP layer)
│   └── EmployeeController.cs
│
├── Services/              → Business logic and validation
│   ├── Interfaces/
│   │   └── IEmployeeService.cs
│   └── EmployeeService.cs
│
├── Repositories/          → Data access layer (DB communication)
│   ├── Interfaces/
│   │   └── IEmployeeRepository.cs
│   └── EmployeeRepository.cs
│
├── Models/
│   ├── Entities/          → Database entity models
│   │   └── Employee.cs
│   └── DTOs/              → Request and response transfer objects
│       ├── CreateEmployeeDto.cs
│       ├── UpdateEmployeeDto.cs
│       └── EmployeeResponseDto.cs
│
├── Data/                  → Database connection and configuration
│   └── DbConnectionFactory.cs
│
├── appsettings.json       → App configuration (connection strings, logging)
└── Program.cs             → Application entry point and DI registration
```

---

## 🗄️ Database Design

All database operations are handled via **SQL Server Stored Procedures**, ensuring:

- **Security** — No raw SQL strings exposed in application code
- **Performance** — Pre-compiled execution plans on the SQL Server side
- **Maintainability** — Database logic stays in the database layer

### Stored Procedures

| Procedure | Description |
|---|---|
| `usp_Employee_Insert` | Inserts a new employee record |
| `usp_Employee_Update` | Updates an existing employee by ID |
| `usp_Employee_Delete` | Deletes an employee record by ID |
| `usp_Employee_GetById` | Retrieves a single employee by ID |
| `usp_Employee_GetAll` | Returns all employee records |

---

## 🔌 API Endpoints

| Method | Endpoint | Description | Request Body |
|---|---|---|---|
| `POST` | `/api/employee` | Create a new employee | `CreateEmployeeDto` |
| `PUT` | `/api/employee/{id}` | Update employee by ID | `UpdateEmployeeDto` |
| `DELETE` | `/api/employee/{id}` | Delete employee by ID | None |
| `GET` | `/api/employee/{id}` | Get employee by ID | None |
| `GET` | `/api/employee` | Get all employees | None |

### Sample Response — Get Employee by ID

```json
{
  "id": 1,
  "firstName": "Abhay",
  "lastName": "Yadav",
  "email": "abhay@example.com",
  "department": "Engineering",
  "designation": "Backend Developer",
  "joiningDate": "2023-06-15"
}
```

---

## ✅ Prerequisites

Before running the project, make sure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server 2019 / 2022](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express / LocalDB)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (recommended) or VS Code with C# extension
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) (optional, for DB management)

---

## 🚀 How to Run

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/abhay-yadav01/aspnet-core-employee-management-api.git
cd aspnet-core-employee-management-api
```

### 2️⃣ Open the Project

Open the `.sln` solution file in **Visual Studio 2022** or navigate to the folder in **VS Code**.

### 3️⃣ Set Up the Database

- Create your SQL Server database (e.g., `EmployeeDB`)
- Run the provided SQL scripts to create the `Employee` table and all stored procedures
- Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> 💡 **Tip:** Replace `YOUR_SERVER` with `.` for a local default SQL Server instance, or `(localdb)\\MSSQLLocalDB` for LocalDB.

### 4️⃣ Restore Dependencies

```bash
dotnet restore
```

### 5️⃣ Build the Project

```bash
dotnet build
```

### 6️⃣ Run the Application

```bash
dotnet run
```

Or press **F5** in Visual Studio to run with the debugger.

The API will be available at:

```
https://localhost:5001
http://localhost:5000
```

You can test the endpoints using **Swagger UI** at:

```
https://localhost:5001/swagger
```

---

## 📌 Best Practices Followed

- ✅ **Clean Architecture** — Strict layering with no cross-layer dependencies
- ✅ **SOLID Principles** — Single responsibility, open/closed, dependency inversion applied
- ✅ **Separation of Concerns** — Each layer has a well-defined, single responsibility
- ✅ **Reusable Components** — Interfaces and generics promote code reuse
- ✅ **Secure Data Access** — All DB operations via stored procedures (no raw SQL injection risk)
- ✅ **Structured Logging** — `ILogger<T>` used consistently for traceability
- ✅ **DTO Pattern** — Internal entities never exposed directly to API consumers
- ✅ **Scalable Code Structure** — Easy to extend with new modules or features

---

## 🗺️ Roadmap (Planned Enhancements)

- [ ] JWT-based Authentication & Authorization
- [ ] Pagination and filtering on `GetAll` endpoint
- [ ] FluentValidation for request model validation
- [ ] Unit tests with xUnit and Moq
- [ ] Docker support and containerization
- [ ] Swagger documentation enhancements

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!

1. Fork the repository
2. Create your feature branch: `git checkout -b feature/your-feature-name`
3. Commit your changes: `git commit -m "Add: your feature description"`
4. Push to the branch: `git push origin feature/your-feature-name`
5. Open a Pull Request

---

## 📄 License

This project is licensed under the **MIT License** — see the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 Author

**Abhay Yadav**  
Backend Developer — .NET / ASP.NET Core  

[![GitHub](https://img.shields.io/badge/GitHub-abhay--yadav01-181717?logo=github)](https://github.com/abhay-yadav01)

---

> ⭐ If you found this project helpful, please consider giving it a star on GitHub!
