# Persian Store

A Persian-language (RTL) online store built with ASP.NET Core MVC, Entity Framework Core, and SQL Server. It includes a customer storefront, a role-protected admin area, a cart, and online payment through Zarinpal.

## Features

**Storefront**
- Home page with sliders and promotional images managed from the admin area
- Hierarchical category menu and search
- Product listing with pagination and product detail pages (features and image gallery)
- Shopping cart tracked per browser (cookie) and per signed-in user
- Online payment with Zarinpal (currently configured for the sandbox)
- Order history for signed-in users
- Registration and login with cookie authentication. Passwords are hashed with PBKDF2 (HMAC-SHA256, random salt).

**Admin area**
- Manage categories, products (with features and images), sliders, and home page images
- View orders and payment requests
- Manage users: create, edit, change status, remove
- Role-based access: managers and operators can use the catalog and order tools, and only managers can manage users

**Data**
- Soft delete through global query filters
- Seeded roles: manager, operator, and customer

## Architecture

```
Src
├── Store_Website.Domain         Entities: products, categories, carts, orders, payments, users, roles
├── Store_Website.Application    Use-case services (commands and queries), DTOs, Facade pattern
├── Store_Website.Persistence    EF Core DbContext, migrations, seed data
├── Store_Website_Common         Result DTO, password hasher, pagination, enums
├── Store_Website.Infrastructure Reserved for external concerns
└── EndPoint.Store               ASP.NET Core MVC site (controllers, admin area, view components, views)
```

Each use case is a small service behind an interface (for example `AddNewProductService`), and product services are grouped behind a facade. Controllers call these services and return views or JSON results.

## Tech Stack

C#, .NET 6, ASP.NET Core MVC (Razor views, Areas, View Components), Entity Framework Core 6 (code-first), SQL Server, cookie authentication with role-based authorization, Zarinpal payment gateway, LazZiya TagHelpers (pagination)

## Getting Started

### Prerequisites
- .NET 6 SDK
- SQL Server

### Configuration
1. In `Src/EndPoint.Store/Program.cs`, change the connection string to point to your SQL Server instance. The default is `.\SQL2022` with Windows authentication and a database named `StoreWebsiteDB`.
2. Add your Zarinpal merchant ID under the key `ZarinpalMerchantId` (user secrets or `appsettings.json`). The payment flow is currently set to Zarinpal's sandbox mode.

### Create the database
```bash
dotnet ef database update --project Src/Store_Website.Persistence --startup-project Src/EndPoint.Store
```
The migration creates the schema and seeds three roles. No admin user is seeded, so register a normal account and assign it the manager role directly in the database to access the admin area.

### Run
```bash
dotnet run --project Src/EndPoint.Store
```

## Known Limitations

- The connection string and the Zarinpal sandbox mode are written in code instead of configuration.
- The payment callback and failed-payment handling need further work.
- Uploaded product images are not validated for type or size.
- There are no automated tests yet.
- The repository still contains two older copies of the web project (`EndPoint.Site` and `EndPoint.Store_Website`) that are not part of the solution.
- The projects target .NET 6, which is out of support.

## Roadmap

- Move configuration to `appsettings.json` and user secrets
- Complete the payment verification flow and handle failed payments
- Validate and sanitize file uploads
- Seed a default admin user for development
- Add unit tests for the application services and integration tests for the order and payment flow
- Upgrade to a current .NET LTS version
- Add Docker support and CI

## Author

Behrooz Roozbahani, .NET / C# developer
GitHub: https://github.com/behroozroozbahani
