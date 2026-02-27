# CrudEmpleados Backend - ASP.NET Core

API REST para gestión de empleados con autenticación basada en roles.

## Tecnologías
- C# / ASP.NET Core
- SQL Server (localdb)
- JWT Authentication
- Swagger / OpenAPI

## Requisitos previos
- .NET 8 SDK
- SQL Server LocalDB

## Configuración

1. Clonar el repositorio
   git clone https://github.com/FabrizioValdez/CrudEmpleados-Backend-net

2. Crear la base de datos
   Abrir SQL Server y crear una base de datos llamada Clientes

3. Configurar la conexión en appsettings.json
   "ConnectionStrings": {
     "CadenaSQL": "Server=(localdb)\\TU_INSTANCIA;Database=Clientes;Trusted_Connection=True;TrustServerCertificate=True;"
   }

4. Ejecutar el proyecto
   dotnet run

La API estará disponible en https://localhost:7256
Documentación Swagger en https://localhost:7256/swagger

## Credenciales de prueba
- Rol: ADMIN
- (Registrar usuario desde el endpoint /api/auth/register)

## Endpoints principales
- POST /api/auth/login - Autenticación
- GET /api/empleados - Listar empleados
- POST /api/empleados - Crear empleado
- PUT /api/empleados/{id} - Editar empleado
- DELETE /api/empleados/{id} - Eliminar empleado
