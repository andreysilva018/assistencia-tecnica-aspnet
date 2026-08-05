# ASP.NET Web Application Project
This project is a comprehensive ASP.NET web application designed to manage various aspects of a business, including clients, technicians, equipment, and service orders. The application is built using the ASP.NET framework and utilizes a range of technologies to provide a robust and scalable solution.

## Features
- Client management: create, read, update, and delete (CRUD) client records
- Technician management: CRUD technician records
- Equipment management: CRUD equipment records
- Service order management: create, assign, and track service orders
- User authentication and authorization: secure access to application features
- Data validation and error handling: ensure data integrity and provide user-friendly error messages

## Tech Stack
- ASP.NET framework
- C# programming language
- .NET framework
- System.Web namespace
- System.Web.Routing namespace
- System.Web.Optimization namespace
- ADO.NET for database interactions
- Entity Framework for ORM (Object-Relational Mapping)
- JavaScript and CSS for client-side scripting and styling
- HTML for web page structure and content

## Installation
To set up the project, follow these steps:
1. **Prerequisites**: Ensure you have the .NET framework and ASP.NET installed on your machine.
2. **Clone the repository**: Clone the project repository to your local machine using Git.
3. **Restore NuGet packages**: Open the project in Visual Studio and restore the NuGet packages.
4. **Configure the database**: Update the connection string in the Web.config file to point to your database.
5. **Build and run**: Build the project and run it in your preferred browser.

## Usage
To use the application, follow these steps:
1. **Login**: Navigate to the login page and enter your credentials.
2. **Dashboard**: Once logged in, you will be redirected to the dashboard, where you can access the various features of the application.
3. **Client management**: Click on the "Clients" tab to create, read, update, and delete client records.
4. **Technician management**: Click on the "Technicians" tab to CRUD technician records.
5. **Equipment management**: Click on the "Equipment" tab to CRUD equipment records.
6. **Service order management**: Click on the "Service Orders" tab to create, assign, and track service orders.

## Project Structure
```markdown
├── 0590_24_1_ANDREYVINICIUSDESOUZASILVA.csproj
├── App_Data
├── App_Start
│   ├── BundleConfig.cs
│   ├── RouteConfig.cs
│   └── WebApiConfig.cs
├── Controllers
├── Models
├── Views
│   ├── About.aspx
│   ├── Contact.aspx
│   ├── Default.aspx
│   ├── Equipamentos.aspx
│   ├── Clientes.aspx
│   ├── Tecnicos.aspx
│   └── OrdemdeServico.aspx
├── Web.config
├── Web.Debug.config
└── Web.Release.config
```

## Screenshots
