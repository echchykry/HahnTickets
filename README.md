# HahnTicket App

## Overview

This repository contains a Ticket manager Application built using the Domain-Driven Design (DDD) architecture in ASP.NET for the backend, and Angular for the frontend. 
The application allows user to manage Tickets (Add, Read, delete, Update).

## Features

- **dotnet version:** Using .NET 8.
- **Domain-Driven Design (DDD):** The application is structured using DDD principles to organize code around the business domain, promoting better maintainability and scalability.
- **ASP.NET Core Web API:** The backend is developed using ASP.NET Core, providing a robust and scalable RESTful API.
- **Entity Framework Core (EF Core) Sql server Database:** The application utilizes EF Core for data persistence, using an sql server database.
- **Repository Pattern:** The repository pattern is implemented to abstract data access logic, providing a clean separation between the application's business logic and data access code.
- **CQRS (Command Query Responsibility Segregation):** The CQRS pattern is employed to separate the read and write operations, improving scalability and simplifying code.
- **MapsterMapping:** MapsterMapping is utilized for mapping between Data Transfer Objects (DTOs) and domain models, simplifying data transformation.
- **Global Error Handling:** Error handling is implemented globally to ensure consistent and meaningful error messages are returned to clients.
- **Fluent Validation:** Fluent Validation is integrated for robust input validation, providing a clean and customizable way to validate requests.

## Frontend

The frontend of the application is built using Angular, with Angular Material components for a sleek and responsive user interface.
- **Angular version:** using Angular 17
- **Primeng:** using Primeng to make the application visually appealing.





