# Code Challenge

#### Info
The product includes a REST API and a Web interface.
- **IDE:** Visual Studio 2017
- **Technology:** ASP.NET Core MVC
- **Database:** SQL Server Express
- **Front End Framework:** Bulma
- **Languages:** C#, JavaScript



#### Requirements
- The persistence layer is built using Entity Framework Core.
- The current configuration targets the local instance of SQL Server Express. Please configure the connection string in appsettings.json accordingly.
  ```
  "SqlServerExpress": "Server=localhost\\SQLEXPRESS;Database=EmployeeManagement;Trusted_Connection=True"
  ```

#### Database Preparation (important)
In order for the web app to run you need to create the database.
- Using Command Line (navigate to the DataLayer project directory):
  - `dotnet ef migrations add Init`
  - `dotnet ef database update`

- Using Package Manager Console (Default project: DataLayer):
  - `add-migration Init`
  - `update-database`
