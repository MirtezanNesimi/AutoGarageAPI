# Auto Garage Service Management System

This project is a Service Oriented Architecture final project developed using ASP.NET Core Web API.

## Project Description

Auto Garage Service Management System is a web API for managing a small auto mechanic garage. The system allows customers to register, add vehicles, book service appointments, and allows the garage owner/admin to view appointments and service reports.

## Technologies Used

- ASP.NET Core Web API (.NET 10)
- Entity Framework Core
- SQLite Database
- OpenAPI
- Git and GitHub
- JetBrains Rider

## Main Features

- User registration and login
- Vehicle management CRUD
- Appointment booking
- Appointment completion
- Garage dashboard report
- Repository Pattern for vehicle data access
- Entity Framework Core migrations

## API Endpoints

### Authentication

POST /api/Auth/register  
POST /api/Auth/login

### Vehicles

GET /api/Vehicles  
POST /api/Vehicles  
PUT /api/Vehicles/{id}  
DELETE /api/Vehicles/{id}

### Appointments

GET /api/Appointments  
POST /api/Appointments  
PUT /api/Appointments/{id}/complete  
DELETE /api/Appointments/{id}

### Reports

GET /api/Report/dashboard

## How to Run

1. Open the project in JetBrains Rider.
2. Restore NuGet packages.
3. Run database migration:

```bash
dotnet ef database update