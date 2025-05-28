
# Desafío Técnico - Gestión de Tareas (Web API)

## ✅ Enfoque aplicado

Este proyecto implementa una Web API para la gestión de tareas siguiendo principios de Clean Architecture** y buenas prácticas como:

- Separación en capas: `Domain`, `Application`, `Infrastructure`
- Uso de **interfaces** e **inyección de dependencias** 
- Aplicación de principios **SOLID** 
- Uso de `LINQ` para consultas filtradas y ordenadas
- Validaciones de negocio (título obligatorio, tareas vencidas, advertencias por acumulación)

## 📁 Estructura de carpetas

La solución está organizada por capas de responsabilidad para favorecer la mantenibilidad y escalabilidad, si bien 
la separacion se basa en carpetas por ser un proyecto chico, se puede realizar esta misma metodologia en distintos proyectos para aumentar sus beneficios:

```
├── api/                     # Proyecto principal Web API (entrada del sistema)
    ├── Controllers/         # Controladores HTTP
    ├── Models/              # Modelos de transferencia para entrada/salida de datos
    ├── Program.cs           # Punto de entrada de la aplicación
    ├── Application/         # Lógica de negocio y servicios
        └── Services/        
    ├── Domain/              # Modelo de dominio
    │   ├── Entities/        # Entidades del negocio
    │   └── Interfaces/      # Funcionalidades
    ├── Infrastructure/      # Implementaciones técnicas (repositorios, datos, etc.)
        └── Repositories/    # Repositorio 
├── .vscode/                 # Configuración de debug para VSCode
└── README.md                # Documentación del proyecto
```

## 🚀 Cómo correr el proyecto

1. Cloná el repositorio y abrí la carpeta del proyecto en Visual Studio Code

2. Restaurá y construí el proyecto:

```bash
dotnet restore
dotnet build
```

3. Corré la API:

```bash
dotnet run
```

4. Accedé a Swagger para probar los endpoints:

```
https://localhost:{PUERTO}/swagger
```

## Manejo de datos para las pruebas. 

Se hace uso de undocumento tasks.json para el enviar y recibir informacion sobre la actividad realizada ya que es una forma, facil, rapida y eficiente para la realizacion de pruebas. Este documento se genera a partir de la primera insercion de datos


## 🧠 Qué mejoraría si tuviera más tiempo

- Implementar persistencia con una base de datos
- Agregar pruebas unitarias
- Añadir autenticación básica
- Crear una UI simple en Blazor o Razor Pages
- Empaquetar con Docker (`Dockerfile` y `docker-compose.yml`)


