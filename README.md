# PSI API - Clean Architecture (.NET 9)

API RESTful desarrollada en **.NET 9** siguiendo los principios de **Clean Architecture** y el patrón **CQRS** con MediatR.

## Estructura del Proyecto

- **CleanArchitecture.Domain**: Entidades del dominio (`Customer`, `Prospect`, `User`, `Country`, `Department`, `City`, `Neighborhood`, `Gender`, `IdentificationType`, `Email`, `PhoneNumber`, `Reference`).
- **CleanArchitecture.Application**: Casos de uso (Queries y Commands con MediatR), validadores (`FluentValidation`), mapeos (`Mapster`), servicios (`JwtService`) y wrappers de respuesta.
- **CleanArchitecture.Infrastructure**: Persistencia de datos con Entity Framework Core 9 y SQL Server (`MainContext`, configuraciones Fluent API, migraciones y repositorios).
- **CleanArchitecture.Api**: Controladores REST, configuración de Swagger/OpenAPI con soporte JWT, inyección de dependencias y middleware global de manejo de errores (`ErrorHandlerMiddleware`).

-# # Tecnologías Princip## Tecnologías Principales## Tecnologías Principalesales

- - .NET 9 / ASP.NET Core Web API
  - Entity Framework Core 9 (SQL Server)
  - MediatR 12 & Mapster
  - FluentValidation
  - Autenticación JWT Bearer
  - Quartz, MailKit y ClosedXML
 
  - ## Configuración y Ejecución
 
  - 1. Configura `ConnectionStrings:DatabaseContext` y `JWTSettings` en `CleanArchitecture.Api/appsettings.json`.
    2. Restaura paquetes y aplica migraciones:
   
    3. ```bash
       dotnet restore
       dotnet ef database update --project CleanArchitecture.Infrastructure --startup-project CleanArchitecture.Api
       ```

       3. Ejecuta la API:
      
       4. ```bash
          dotnet run --project CleanArchitecture.Api
          ```
