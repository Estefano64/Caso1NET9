# Sistema de Gestión de Proyectos de Consultoría

## Arquitectura Implementada

Este proyecto implementa un sistema robusto de gestión de proyectos para una empresa de servicios de consultoría, siguiendo los principios SOLID y las mejores prácticas de desarrollo.

### Estructura del Proyecto

```
caso2net/
├── Controllers/                    # Controladores Web API
├── DTOs/                          # Data Transfer Objects
├── Models/                        # Entidades de Entity Framework
├── Repositories/                  # Repositorios y Unit of Work
│   ├── IRepository.cs            # Interfaz genérica de repositorio
│   ├── IUnitOfWork.cs            # Interfaz Unit of Work
│   └── Implementations/          # Implementaciones de repositorios
│       ├── Repository.cs         # Implementación genérica
│       └── UnitOfWork.cs         # Implementación Unit of Work
├── Services/                      # Servicios de negocio
│   ├── IProyectoService.cs       # Interfaz servicio de proyectos
│   ├── ITareaService.cs          # Interfaz servicio de tareas
│   ├── IComunicacionService.cs   # Interfaz servicio de comunicaciones
│   ├── IPresupuestoService.cs    # Interfaz servicio de presupuesto
│   ├── IEncryptionService.cs     # Interfaz servicio de encriptación
│   └── Implementations/          # Implementaciones de servicios
│       ├── ProyectoService.cs    # Lógica de negocio proyectos
│       ├── TareaService.cs       # Lógica de negocio tareas
│       └── EncryptionService.cs  # Servicio de encriptación
└── Configurations/               # Configuraciones adicionales
```

## Principios SOLID Aplicados

### 1. Single Responsibility Principle (SRP)
- **Interfaces separadas**: Cada interfaz tiene una responsabilidad específica
- **Servicios especializados**: `IProyectoService`, `ITareaService`, `IComunicacionService`
- **Controladores focalizados**: Cada controlador maneja un dominio específico

### 2. Open/Closed Principle (OCP)
- **Repository genérico**: `IRepository<T>` permite extensión sin modificación
- **Servicios extensibles**: Nuevos servicios pueden implementar interfaces sin afectar existentes

### 3. Liskov Substitution Principle (LSP)
- **Implementaciones intercambiables**: Todas las implementaciones de interfaces pueden sustituirse
- **Herencia consistente**: Repository base funciona con cualquier entidad

### 4. Interface Segregation Principle (ISP)
- **Interfaces específicas**: `IProyectoService`, `ITareaService` en lugar de una interfaz monolítica
- **Contratos focalizados**: Cada interfaz expone solo métodos relevantes

### 5. Dependency Inversion Principle (DIP)
- **Inyección de dependencias**: Todos los servicios dependen de abstracciones
- **Inversión de control**: Program.cs configura las dependencias

## Funcionalidades Implementadas

### 1. Gestión de Proyectos
- ✅ Creación, seguimiento y cierre de proyectos
- ✅ Fechas de inicio/fin, estado, objetivos y responsables
- ✅ Cálculo automático de presupuesto real y porcentaje de avance

### 2. Asignación de Tareas
- ✅ Asignar tareas específicas a empleados
- ✅ Plazos y seguimiento del progreso
- ✅ Estados y prioridades de tareas

### 3. Seguimiento de Presupuesto
- ✅ Registro y control de costos por proyecto
- ✅ Comparación presupuesto estimado vs gasto real
- ✅ Categorización de gastos

### 4. Comunicación con Clientes
- ✅ Registro de interacciones, correos y reuniones
- ✅ Tipos de comunicación y seguimiento

### 5. Informes de Progreso
- ✅ Cálculo automático de avance por hitos
- ✅ Comparación entre planificado vs real

## Características de Seguridad

### Encriptación
- **Servicio de encriptación**: `IEncryptionService` con implementación AES
- **Hash de contraseñas**: BCrypt para almacenamiento seguro
- **Tokens seguros**: Generación de tokens criptográficamente seguros

### Headers de Seguridad
- `X-Content-Type-Options: nosniff`
- `X-Frame-Options: DENY`
- `X-XSS-Protection: 1; mode=block`
- `Referrer-Policy: strict-origin-when-cross-origin`

### Configuración Segura
- Connection strings en configuración
- Claves de encriptación externalizadas

## Escalabilidad y Fiabilidad

### Patrón Repository + Unit of Work
- **Transacciones**: Soporte completo para transacciones distribuidas
- **Consistencia**: Unit of Work asegura consistencia de datos
- **Performance**: Repository optimizado con Entity Framework

### Gestión de Errores
- **Exception handling**: Manejo robusto de errores en controladores
- **Logging**: Sistema de logging integrado
- **Health checks**: Endpoint de salud para monitoreo

## Compatibilidad Multiplataforma

### CORS Configurado
- Soporte para diferentes dispositivos (PC, tabletas, móviles)
- Headers apropiados para acceso remoto

### API RESTful
- Endpoints estandarizados
- Serialización JSON optimizada
- Documentación OpenAPI/Swagger

## Comandos Útiles

### Desarrollo
```bash
dotnet build                    # Compilar proyecto
dotnet run                      # Ejecutar en desarrollo
dotnet test                     # Ejecutar pruebas
```

### Entity Framework
```bash
dotnet ef migrations add        # Crear migración
dotnet ef database update       # Actualizar base de datos
```

## API Endpoints

### Proyectos
- `GET /api/proyectos` - Listar todos los proyectos
- `GET /api/proyectos/{id}` - Obtener proyecto específico
- `POST /api/proyectos` - Crear nuevo proyecto
- `PUT /api/proyectos/{id}` - Actualizar proyecto
- `DELETE /api/proyectos/{id}` - Eliminar proyecto

### Tareas
- `GET /api/tareas` - Listar todas las tareas
- `GET /api/tareas/proyecto/{id}` - Tareas por proyecto
- `POST /api/tareas` - Crear nueva tarea
- `PUT /api/tareas/{id}/progreso` - Actualizar progreso

### Health Check
- `GET /health` - Verificar estado del sistema

## Verificación de Relaciones

Las relaciones entre entidades están correctamente configuradas:

- **Proyecto ↔ Cliente**: Relación uno-a-muchos
- **Proyecto ↔ Empleado**: Relación muchos-a-muchos a través de ProyectoEmpleado
- **Proyecto ↔ Tareas**: Relación uno-a-muchos
- **Proyecto ↔ Gastos**: Relación uno-a-muchos
- **Proyecto ↔ Comunicaciones**: Relación uno-a-muchos
- **Proyecto ↔ Hitos**: Relación uno-a-muchos

Todas las claves foráneas y constraints están debidamente configuradas en el DbContext.