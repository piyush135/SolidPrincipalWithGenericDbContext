# Solid Principle with Generic DbContext: Switching Between SQL and NoSQL

This project demonstrates the **SOLID principles** using a **generic DbContext** to support switching between **SQL** and **NoSQL** databases. The solution implements a clean architecture with repository-service-controller patterns, enabling seamless integration with multiple database types.

---

## Table of Contents

1. [Project Structure](#project-structure)
2. [Features](#features)
3. [Dependencies](#dependencies)
4. [Setup and Configuration](#setup-and-configuration)
5. [Usage](#usage)
6. [Extending the Project](#extending-the-project)

---

## Project Structure

### Core Components

1. **Generic DbContext Interface (`IDBContext`)**
   - Abstracts operations like `GetByIdAsync`, `QueryAsync`, `SaveAsync`, and `DeleteAsync`.
   - Supports both SQL and NoSQL databases.

2. **SQL DbContext Implementation (`SqlDbContext`)**
   - Implements `IDBContext` for SQL using Entity Framework and Dapper.

3. **NoSQL DbContext Implementation (`NoSqlDbContext`)**
   - Implements `IDBContext` for NoSQL (e.g., MongoDB).

4. **Repository Pattern**
   - **Generic Repository (`IRepository`)**: Defines data operations.
   - **SQL Repository (`SqlRepository`)**: Implements SQL-specific operations.
   - **NoSQL Repository (`NoSqlRepository`)**: Implements NoSQL-specific operations.

5. **Service Layer**
   - Contains business logic, abstracts database details, and connects the controller to repositories.

6. **Controller**
   - Handles API requests and interacts with the service layer.

---

## Features

- **SOLID Principles**:
  - Single Responsibility: Each class has a focused purpose.
  - Open/Closed: Supports new database types without modifying existing code.
  - Liskov Substitution: SQL and NoSQL repositories are interchangeable.
- Dynamic **switching between SQL and NoSQL** databases.
- **Decorator Pattern** for database-specific extensions.
- Clean separation of concerns across layers.

---

## Dependencies

- **Entity Framework Core**: For SQL database operations.
- **Dapper**: For advanced SQL queries.
- **MongoDB.Driver**: For NoSQL database operations.
- **Microsoft.Extensions.DependencyInjection**: For Dependency Injection.

---

## Setup and Configuration

### 1. Install Dependencies

Run the following commands to install the required NuGet packages:
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Dapper
dotnet add package MongoDB.Driver
