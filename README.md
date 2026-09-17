# Fruit Store MVC

A portfolio-grade ASP.NET Core 9.0 MVC web application implementing a complete, secure e-commerce shopping and administrative management workflow for a fruit and produce store.

---

## Overview

**Fruit Store MVC** demonstrates structured, production-ready enterprise application development with ASP.NET Core MVC, Entity Framework Core 9, SQL Server, and ASP.NET Core Identity. 

The application implements end-to-end shopping workflows (product browsing, category filtering, product details with customer reviews, session-based shopping cart, and transactional checkout with stock decrement) alongside administrative store management (role-protected dashboard, product catalog CRUD, category management, and customer order fulfillment).

---

## Features

### Customer Features
- **Product Catalog**: Browse active produce items with live stock badges, dynamic pricing, and category filtering.
- **Product Details**: View detailed descriptions, pricing, inventory availability, and customer reviews.
- **Shopping Cart**: Session-based cart allowing customers to add items, adjust quantities, remove items, and view calculated subtotals with live cart count badges.
- **Transactional Checkout**: Form-validated shipping details entry, server-side cart verification, price snapshotting, stock reservation, and atomic order placement.
- **Order Confirmation**: Receipt view displaying unique order ID, shipping destination, order date, status, and purchased items.
- **Customer Order History**: Authorized "My Orders" dashboard allowing customers to view past purchases and itemized receipts, enforced with strict server-side ownership checks (preventing IDOR).

### Administrative Management (Protected by `Admin` Role)
- **Admin Dashboard**: Real-time metrics tracking product count, category count, total orders, pending orders, and non-cancelled revenue.
- **Product Management**: Full CRUD operations for produce items, including category assignment, price validation (> $0), stock tracking (>= 0), and referential integrity protection on deletion.
- **Category Management**: Create, edit, list, and safely delete categories (deletion is blocked if products are assigned).
- **Order Fulfillment**: Review customer orders and update status (`Pending`, `Processing`, `Shipped`, `Delivered`, `Cancelled`).
- **Inventory Consistency**: Order placement automatically decrements available inventory; order cancellation restores inventory.

### Security & Hardening
- **Authentication & Identity**: ASP.NET Core Identity with secure cookie authentication.
- **Role-Based Access Control (RBAC)**: Distinct `Admin` and `Customer` roles. Administrative controllers and views are protected server-side with `[Authorize(Roles = "Admin")]`.
- **Anti-Forgery Protection**: `[ValidateAntiForgeryToken]` applied to all state-mutating HTTP POST endpoints.
- **Server-Authoritative Pricing**: Cart totals and order snapshots query database pricing at checkout, never trusting client-submitted prices.
- **IDOR Protection**: Customers can only query and view orders associated with their own `UserId`.
- **Open Redirect Prevention**: Local URL validation on redirect headers.

---

## Architecture

The solution strictly adheres to a clean, multi-project layered architecture:

```
FruitStore.sln
├── Fruit_Store.Core/           # Domain Layer (Pure business models, interfaces, DTOs, Enums)
├── Fruit_Store.Infrastructure/ # Data Layer (AppDbContext, EF Core Configurations, Repositories, Migrations)
├── Fruit_Store.Services/       # Application Layer (Business service implementations, AutoMapper profiles)
├── Fruit_Store_MVC/            # Presentation Layer (MVC Controllers, Areas/Admin, Razor Views, ViewModels)
└── Fruit_Store.Tests/          # Automated Test Suite (Unit and security integration tests via xUnit & Moq)
```

- **Generic Repository & Unit of Work**: Encapsulates EF Core operations, allowing clean testability and transaction management.
- **Data Transfer Objects (DTOs)**: Isolates database entity models from view models and external consumers.
- **AutoMapper**: Standardized object-to-object mapping across domain models and DTOs.
- **Session Cart**: Lightweight, high-performance in-memory session caching for pre-checkout cart state.

---

## Tech Stack

- **C# / .NET 9.0** (with `RollForward` support)
- **ASP.NET Core MVC**
- **Entity Framework Core 9.0**
- **Microsoft SQL Server**
- **ASP.NET Core Identity** (Cookie-based auth & RBAC)
- **AutoMapper 12**
- **xUnit & Moq** (Unit & architecture tests)
- **Bootstrap & FontAwesome** (Responsive UI)

---

## Business Workflow

```
[Product Catalog] 
       │
       ▼
[Product Details & Reviews] 
       │ (Add to Cart)
       ▼
[Session Cart] ── (Update / Remove Items)
       │
       ▼ (Proceed to Checkout)
[Checkout Form] ── (Validate User & Shipping Details)
       │
       ▼ (Submit Order - Transactional)
┌──────────────────────────────────────────────┐
│ 1. Verify product availability in DB         │
│ 2. Snapshot current unit prices              │
│ 3. Decrement product inventory               │
│ 4. Persist Order and OrderItems in DB        │
│ 5. Clear session cart                        │
└──────────────────────────────────────────────┘
       │
       ▼
[Order Confirmation] ──► [Customer Order History]
                                │
                                ▼
                    [Admin Order Management]
                 (Status updates & Restock on Cancel)
```

---

## Authentication & Authorization

ASP.NET Core Identity manages user credentials and claims. Two standard roles are seeded:
- **`Admin`**: Full access to administrative areas (`/Admin/Dashboard`, `/Admin/Products`, `/Admin/Categories`, `/Admin/Orders`). Unauthorized visitors receive HTTP 403 / Access Denied.
- **`Customer`**: Access to personal shopping features (`/Cart`, `/CheckOut`, `/Order/MyOrders`).

Cookie authentication is configured with safe defaults:
- `HttpOnly = true`
- `ExpireTimeSpan = 8 hours`
- `LoginPath = /Identity/Account/Login`
- `AccessDeniedPath = /Identity/Account/AccessDenied`

---

## Default Development Accounts

For development, demo, and portfolio evaluation, a seeded administrator account is automatically initialized at startup:

| Role | Email | Password | Purpose |
|------|-------|----------|---------|
| **Admin** | `admin@fruitstore.com` | `Admin123!` | Store administration, inventory, & order management |
| **Customer** | *(Self-register via UI)* | *(Min 6 chars, upper/lower/digit)* | Shopping, checkout, and order history |

> *Note: These credentials are for local development and demonstration only.*

---

## Database & Migrations

Database configurations are defined using EF Core Fluent API with explicit column mappings, foreign key relationships, cascade behaviors, and seed data.

Two EF Core migrations are included in `Fruit_Store.Infrastructure/Migrations/`:
1. `20260917161215_InitialCreate`: Initial schema for Products, Categories, Orders, OrderItems, Reviews, News, Coupons, and ASP.NET Identity tables.
2. `20260917191330_AddOrderUserStringAndShipping`: Updates `Order.UserId` to string for Identity integration and adds shipping fields (`ShippingName`, `ShippingAddress`, `ShippingCity`).

---

## Getting Started

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (or higher)
- SQL Server, SQL Server Express, or LocalDB

### Installation & Run

1. **Clone the repository**:
   ```bash
   git clone https://github.com/716W/Fruit_Store-MVC.git
   cd Fruit_Store-MVC
   ```

2. **Configure Database Connection**:
   Update `Fruit_Store_MVC/appsettings.json` with your SQL Server connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=Fruit_Store;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```

3. **Apply Database Migrations**:
   ```bash
   dotnet ef database update --project Fruit_Store.Infrastructure --startup-project Fruit_Store_MVC
   ```

4. **Run the Application**:
   ```bash
   dotnet run --project Fruit_Store_MVC
   ```
   Navigate to `https://localhost:5001` or `http://localhost:5000` in your browser.

5. **Run the Automated Tests**:
   ```bash
   dotnet test
   ```

---

## Project Structure

```
Fruit_Store-MVC/
├── Fruit_Store.Core/
│   ├── DTOs/                      # Data transfer objects (ProductDTO, OrderDTO, OrderItemDTO, etc.)
│   ├── Enums/                     # Business enums (OrderStatus)
│   ├── Interfaces/
│   │   ├── Repository/            # IGenericRepository, IProductRepository, IUnitOfWork
│   │   └── Services/              # IProductServices, IOrderServices, ICategoryServices
│   └── Models/                    # Domain entities (Product, Category, Order, OrderItem, Review)
│
├── Fruit_Store.Infrastructure/
│   ├── Data/                      # AppDbContext and Fluent API entity configurations
│   ├── Migrations/                # EF Core database migrations
│   └── Reposetory/                # Generic and specialized repository implementations
│
├── Fruit_Store.Services/
│   ├── Mappings/                  # AutoMapper GeneralMappingProfile
│   └── Services/                  # Business service implementations (OrderServices, ProductServices, etc.)
│
├── Fruit_Store_MVC/
│   ├── Areas/
│   │   ├── Admin/                 # Admin controllers and views (Dashboard, Products, Categories, Orders)
│   │   └── Identity/              # ASP.NET Core Identity Razor Pages (Login, Register, Manage)
│   ├── Controllers/               # Public & customer controllers (Shop, Cart, CheckOut, Order, StaticPage)
│   ├── Models/                    # Presentation models (CartItem)
│   ├── Services/                  # Presentation services (CartService)
│   ├── ViewModels/                # ViewModels for inputs and data aggregation (CheckoutViewModel)
│   ├── Views/                     # Customer-facing Razor views
│   └── wwwroot/                   # Static assets (CSS, JavaScript, vendor libraries, images)
│
└── Fruit_Store.Tests/             # Automated xUnit test project
    ├── CartServiceTests.cs
    ├── OrderServicesTests.cs
    └── SecurityAndAuthorizationTests.cs
```

---

## Automated Test Results

The test suite validates core business logic, cart operations, stock consistency, and authorization constraints:

```bash
Passed!  - Failed: 0, Passed: 34, Skipped: 0, Total: 34, Duration: 118 ms
```

- **CartService (8 tests)**: Add, item increment, quantity update, zero-quantity removal, item removal, cart clearing, subtotal accuracy.
- **OrderServices (9 tests)**: Stock availability verification, atomic stock decrement with transaction rollback, purchase price snapshotting, restock on order cancellation, duplicate cancellation prevention, status transition validation, empty cart handling, and IDOR customer order isolation.
- **Security & Authorization (17 tests)**: Admin role enforcement on all admin controllers, customer authentication constraints, and Anti-Forgery token enforcement on all state-mutating POST actions.

---

## License

This project is licensed under the MIT License.
