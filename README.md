# Aztro-CChardos-Back-Group2

## Description
Aztro-CChardos-Back-Group2 is a sophisticated travel recommendation system backend built with .NET 9. The system helps users discover personalized travel destinations by analyzing their preferences through an intelligent questionnaire system. It provides tailored travel plans, including accommodations and transportation options between cities.

## Features
- Smart destination matching based on user preferences
- Dynamic questionnaire system
- City and destination management
- Travel plan generation with accommodation and transport options
- Comprehensive reporting system
- Secure user authentication and authorization
- RESTful API architecture

### Built With
- **.NET 9.0**: Core framework for building the backend application
- **Entity Framework Core 9.0.3**: ORM for database operations
- **PostgreSQL (Npgsql 9.0.3)**: Main database system
- **Authentication & Security**:
  - JWT Bearer (9.0.3): Token-based authentication
  - BCrypt.Net (4.0.3): Password hashing and security
- **Data Processing & Integration**:
  - AutoMapper (12.0.1): Object-to-object mapping
  - ClosedXML (0.104.2): Excel file handling for reports
- **Development Tools**:
  - DotNetEnv (3.1.1): Environment variable management
  - OpenAPI/Swagger: API documentation and testing
- **Database Tools**:
  - EF Core Design Tools: Database migration and management
  - Npgsql.EntityFrameworkCore.PostgreSQL (9.0.4): PostgreSQL provider for EF Core

This backend service is designed to support a modern travel recommendation platform, offering scalable and maintainable solutions for travel planning and destination discovery.

## Project Structure
The project is organized into several main directories:

📦 Aztro-CChardos-Back-Group2
├── 📂 Application
│   ├── 📂 DTOs
│   ├── 📂 Mappings
│   └── 📂 Services
├── 📂 Domain
│   ├── 📂 Entities
│   ├── 📂 Enums
│   └── 📂 Interfaces
├── 📂 Infrastructure
│   ├── 📂 Auth
│   ├── 📂 Data
│   │   ├── 📂 Config
│   ├── 📂 Middlewares
│   ├── 📂 Repositories
│   └── 📂 Utils
├── 📂 Docs
│   ├── 📂 api
│   ├── 📂 architecture
│   ├── 📂 guides
│   └── 📂 technical
├── 📂 Presentation
│   └── 📂 Controllers
└── 📂 Migrations

### Directory Structure Overview
- **Application/**: Contains application logic, DTOs, and services
  - `DTOs/`: Data Transfer Objects for API requests/responses
  - `Mappings/`: AutoMapper profile configurations
  - `Services/`: Business logic implementation

- **Domain/**: Core business logic and entities
  - `Entities/`: Domain model classes
  - `Enums/`: Enumeration types
  - `Interfaces/`: Repository and service interfaces

- **Infrastructure/**: External concerns and implementations
  - `Auth/`: Authentication and authorization
  - `Data/`: Database context and configurations
    - `Config`: Database connection string configuration
  - `Middlewares/`: Custom middleware components
  - `Repositories/`: Data access implementations
  - `Utils/`: Helper utilities and extensions

- **Docs/**: Project documentation
  - `api/`: API documentation and endpoints
  - `architecture/`: System design and patterns
  - `guides/`: Development and deployment guides
  - `technical/`: Technical specifications

- **Presentation/**: API endpoints and controllers
  - `Controllers/`: REST API controllers

## Environment Configuration
Create a `.env` file in the root directory with the following variables:

### Database Configuration
```env
DB_HOST=your_database_host
DB_USERNAME=your_database_username
DB_PASSWORD=your_database_password
DB_NAME=your_database_name
DB_PORT=5432
```

### JWT Configuration
```env
    JWT_KEY=your_jwt_secret_key
    JWT_ISSUER=your_jwt_issuer
    JWT_AUDIENCE=your_jwt_audience
    JWT_EXPIRATION_HOURS=24
```

### Environment Variables Description

- Database Configuration
    ```env  
    DB_HOST : PostgreSQL database host
    DB_USERNAME : Database user name
    DB_PASSWORD : Database password
    DB_NAME : Database name
    DB_PORT : Database port (default: 5432) 
    ```
- JWT Authentication
  ````env
    JWT_KEY : Secret key for JWT token generation
    JWT_ISSUER : JWT token issuer
    JWT_AUDIENCE : JWT token audience
    JWT_EXPIRATION_HOURS : Token expiration time in hours
  ````

- Email Configuration (Optional)
  ```env
    MAIL_SMTP_SERVER : SMTP server for sending emails
    MAIL_SMTP_PORT : SMTP port
    MAIL_USERNAME : Email username
    APP_PASSWORD : Application-specific password for the email account
  ```

- Google OAuth2 Configuration (Optional)
  ```env
    GOOGLE_CLIENT_ID : Google OAuth2 client ID
    GOOGLE_CLIENT_SECRET : Google OAuth2 client secret
    GOOGLE_SCOPE : OAuth2 scope for Google authentication
    GOOGLE_AUTHORIZATION_URI : Google OAuth2 authorization URI
    GOOGLE_TOKEN_URI : Google OAuth2 token URI
    GOOGLE_USER_INFO_URI : Google OAuth2 user information URI
    GOOGLE_USER_NAME_ATTRIBUTE : Attribute used to identify the user in Google OAuth2 response
  ```

## Prerequisites

### Required Software
- **.NET SDK 9.0** or later
  - Download from: [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
  - Verify installation: 
    ```bash
    dotnet --version
    ```

- **PostgreSQL 15** or later
  - Download from: [PostgreSQL Downloads](https://www.postgresql.org/download/)
  - Required for database operations
  - Verify installation:
    ```bash
    psql --version
    ```

- **Visual Studio 2022** or **Visual Studio Code**
  - Visual Studio 2022 (Recommended)
    - Download from: [Visual Studio](https://visualstudio.microsoft.com/)
    - Required Workloads:
      - ASP.NET and web development
      - .NET desktop development
  - Visual Studio Code
    - Download from: [VS Code](https://code.visualstudio.com/)
    - Required Extensions:
      - C# Dev Kit
      - .NET Extension Pack
      - PostgreSQL

### Development Tools
- **Git**
  - Download from: [Git](https://git-scm.com/downloads)
  - Required for version control
  - Verify installation:
    ```bash
    git --version
    ```

### Optional Tools
- **Postman** or similar API testing tool
  - Download from: [Postman](https://www.postman.com/downloads/)
  - Useful for testing API endpoints

- **pgAdmin 4**
  - Download from: [pgAdmin](https://www.pgadmin.org/download/)
  - GUI for PostgreSQL database management

### System Requirements
  - Windows 10/11 (64-bit) or later
  - Minimum 4GB RAM (8GB recommended)
  - 10GB available disk space

## Installation

### 1. Clone the Repository
```bash
    git clone https://github.com/your-username/Aztro-CChardos-Back-Group2.git
    cd Aztro-CChardos-Back-Group2
```

### 2. Configure Environment Variables
  - Create a `.env` file in the root directory
  - Copy the environment variables template from the Environment Configuration section
  - Fill in your specific configuration values

### 3. Database Setup
1. Create a PostgreSQL database:
   ```bash
        psql -U postgres
        CREATE DATABASE your_database_name;
    ```

2. Apply Migrations:
   ```bash
        dotnet ef database update
    ```

### 4. Install Dependencies
```bash
    dotnet restore
```

### 5. Build the Project
```bash
    dotnet run
```

### 6.Run the Application
```bash
    dotnet run
```

The API will be available at `http://localhost:5076` by default.

7. Verify Installation
  - Access Swagger documentation at `http://localhost:5076/swagger`
  - Test the health check endpoint at `http://localhost:5076/health`

### Troubleshooting
- If you encounter database connection issues:
  
  - Verify PostgreSQL is running
  - Check your connection string in .env
  - Ensure database user has proper permissions
- If you get build errors:
  
  - Ensure .NET SDK 9.0 is properly installed
  - Clear NuGet cache: dotnet nuget locals all --clear
  - Restore packages again: dotnet restore

## Contributing

We welcome contributions to the Aztro-CChardos-Back-Group2 project! Here's how you can help:

### Development Process
1. Fork the repository

2. Create a new branch for your feature:
   ```bash
        git checkout -b feature/your-feature-name
   ```

3. Make your changes

4. Commit your changes:
    ```bash
        git commit -m "Add: brief description of your changes"
    ```

5. Push your changes to your fork:
    ```bash
        git push origin feature/your-feature-name
    ``` 

6. Create a pull request to the main repository.

7. Wait for review and merge.

### Coding Standards
- Follow C# coding conventions
- Use meaningful variable and function names
- Keep methods focused and concise
- Add XML documentation for public APIs
- Include unit tests for new features
  
### Pull Request Guidelines
- Provide a clear description of the changes
- Link any related issues
- Include screenshots for UI changes
- Ensure all tests pass
- Update documentation if needed

### Reporting Issues
- Use the GitHub issue tracker
- Include detailed steps to reproduce
- Specify your environment details
- Attach relevant logs or screenshots

### Code Review Process
1. All code changes require review
2. Address reviewer feedback
3. Maintain a respectful and collaborative attitude
4. Be patient during the review process