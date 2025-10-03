# Fruit Store MVC

A modern ASP.NET Core 9.0 MVC web application for managing a fruit store with comprehensive API documentation.

## Features

- Product catalog management
- Shopping cart functionality
- User authentication and authorization
- News and reviews system
- RESTful API with Swagger documentation

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (or SQL Server Express)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/716W/Fruit_Store-MVC.git
   cd Fruit_Store-MVC
   ```

2. Update the connection string in `appsettings.json` to point to your SQL Server instance:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=FruitStoreDB;Trusted_Connection=true;"
   }
   ```

3. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run --project Fruit_Store_MVC
   ```

## Using Swagger for API Testing

This application includes **Swagger UI** (powered by Swashbuckle.AspNetCore) for easy API endpoint testing and documentation.

### Accessing Swagger UI

1. Start the application using `dotnet run` or from Visual Studio
2. Navigate to: `https://localhost:{port}/swagger`
   - The default port is typically `5001` for HTTPS or `5000` for HTTP
   - Example: `https://localhost:5001/swagger`

### Features of Swagger UI

- **Interactive API Documentation**: View all available API endpoints with their parameters and response models
- **Try It Out**: Test any endpoint directly from the browser without additional tools
- **Request/Response Examples**: See example payloads for requests and responses
- **Authentication Testing**: Test authenticated endpoints (if authentication is implemented)

### How to Test an Endpoint

1. Open Swagger UI in your browser (`/swagger`)
2. Expand the controller section you want to test
3. Click on the HTTP method (GET, POST, PUT, DELETE) you want to try
4. Click the "Try it out" button
5. Fill in any required parameters
6. Click "Execute" to send the request
7. View the response in the "Responses" section below

### Swagger Configuration

The Swagger configuration can be found in `Program.cs`:

```csharp
// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fruit Store API V1");
    c.RoutePrefix = "swagger";
});
```

## Project Structure

```
Fruit_Store-MVC/
├── Fruit_Store_MVC/          # Main web application
│   ├── Controllers/          # MVC Controllers
│   ├── Views/               # Razor views
│   ├── wwwroot/             # Static files
│   └── Program.cs           # Application entry point
├── Fruit_Store.Core/        # Domain models and interfaces
├── Fruit_Store.Services/    # Business logic services
└── Fruit_Store.Infrastructure/ # Data access layer
```

## Technologies Used

- **ASP.NET Core 9.0** - Web framework
- **Entity Framework Core 9.0** - ORM for database access
- **SQL Server** - Database
- **AutoMapper** - Object-to-object mapping
- **ASP.NET Core Identity** - Authentication and authorization
- **Swashbuckle.AspNetCore 7.2.0** - Swagger/OpenAPI documentation

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License.
