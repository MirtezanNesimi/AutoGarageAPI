# AutoGarageAPI

## Project Description

AutoGarageAPI is a RESTful ASP.NET Core Web API developed for managing a car garage system.

The system allows users to:

* Register and login
* Manage vehicles
* Create and manage appointments
* View dashboard reports

## Technologies Used

* ASP.NET Core (.NET 10)
* Entity Framework Core
* SQLite
* Swagger / OpenAPI
* GitHub

## API Endpoints

### Authentication

* POST /api/Auth/register
* POST /api/Auth/login

### Vehicles

* GET /api/Vehicles
* POST /api/Vehicles

### Appointments

* GET /api/Appointments
* POST /api/Appointments
* PUT /api/Appointments/{id}/complete
* DELETE /api/Appointments/{id}

### Reports

* GET /api/Report/dashboard

## Author

Mirtezan Nesimi
