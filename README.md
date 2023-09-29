# GymAPI

- Description
  - API's Impact
  - Database
  - Authentication & Authorization
  - Documentation
- Used technologies

## Description
### API's Impact
The API was written using REST architecture.
It was created to manage appropriate exercises and trainings for the gym activity.
User has posibility to create, update, delete and find exercises. Also they can group exercies and create the training 
highlighting if the training is push, pull, legs or cardio type. Therefore, user can operate on training with the same commands as on the exercise. 

### Database
The data can be kept in the local database or in the cloud azure database. Database is managed by **Entity Framework** with automatic migrations.

### Authentication & Authorization
Authentication is made by creating 3 roles: user, manager and admin. Each role is checked by JWT token and based by its value
someone can or cannot be authorized to commit changes in the database.

### Documentation
Documentation is created using swagger.

## Used technologies
1. .NET 6.0
2. ASP.Net Core
3. AutoMapper
4. FluentValidation
5. Entity Framework
6. Swagger
7. NLog
