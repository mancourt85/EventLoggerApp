# 🧰 Proyecto - Logs App

Este es un proyecto backend que permite registrar y consultar logs por tipo o por fecha. Incluye una API en .NET 8.

---

## 🖥️ Backend (.NET 8)

### 🔧 Tecnologías utilizadas
- .NET 8  
- Entity Framework Core  
- SQL Server  
- Clean Architecture  
- Unit of Work (UoW)  
- LINQ  
- Swagger para documentación de la API  

### ▶️ ¿Cómo correrlo?

1. Clona el repositorio:
   git clone https://github.com/

2. Entra a la carpeta del backend:
   cd EventLog.API

3. Configura tu cadena de conexión en `appsettings.json`:
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=EventLogsDb;User Id=sa;Password=TuPassword123;TrustServerCertificate=True"
   }

4. Aplica las migraciones:
   dotnet ef database update

5. Corre la aplicación:
   dotnet run

6. Accede a Swagger para probar los endpoints:
   https://localhost:[7030]/swagger

---


## 🗂️ Estructura y arquitectura

- **Backend**:
  - Sigue Clean Architecture.
  - Capas bien separadas: `Domain`, `Application`, `Infrastructure`, `API`.
  - Uso de patrones como `Unit of Work` y `Repository Pattern`.
  - Manejo de errores con `try/catch` y respuestas controladas.


## 📌 Funcionalidades principales

- Registro de logs por tipo y fecha.
- Filtros por tipo o rango de fechas.
- API documentada con Swagger.

---

## ✅ Requisitos

- .NET SDK 8.0+
- SQL Server local o remoto
