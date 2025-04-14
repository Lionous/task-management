# API Gestión de Tareas

Este repositorio contiene el código para una API RESTful desarrollada con ASP.NET Core 9.

## Tabla de contenidos
+ Base de datos 
	- [Scritp de la base de datos](#base-de-datos-sqlite)
    - [Conexion de la base de datos](#conexion-de-la-base-de-datos)

+ Instalación y Ejecución Tradicional de la API
	- [Software Requerido](#software-requerido)
    - [Instrucciones de Configuración](#instrucciones-de-configuración)
    - [Visualización con Swagger](#visualización-con-swagger)

+ Ejemplos de Uso
    - [1) CRUD Categorias](#1-crud-categorias)
    - [2) CRUD Tareas](#2-crud-tareas)
    - [3) Reportes](#3-reportes)

## Base de datos SQLite
La base de datos que se está usando es SQLite, dirigirse al proyecto y en la carpeta "resources"
1. **Dirigite a esta ruta**:
```bash
cd resources
```
El script se puede encontrar en...👉 [Script](resources/script.sql)

## Conexion de la base de datos
En la ruta que se encuentra acontinuación se encuentra un archivo `.json`
```bash
cd apitask/application/appsettings.Development.json
```
Abrir el archivo y cambiar la linea "ConnectionStringSQLite", y poner la ruta donde esta la base de datos SQLite.

La base de datos se encontra en...👉 [Base de datos](resources/data.sqlite3)
> Nota: Si desea crear otra base de datos puede ejecutar el script que se menciona en lo anterior.

## Instalación y Ejecución Tradicional de la API

## Software Requerido
| Software Requerido                     | Soporte de OS            |
|----------------------------------------|--------------------------|
| .NET SDK 9.0                           | Windows, macOS, Linux    |

> Nota: Se puede usar un editor de códido, o IDEs como Visual Studio, Rider si se encuentra en Linux o cualquiera de su preferencia.

## Instrucciones de Configuración

1. **Clona el Repositorio**:
    ```bash
    https://github.com/Lionous/task-management.git
    ```

1. **Dirigirse a la ruta**:
    ```bash
    cd task-management/apitask/application
    ```

2. **Restaura Dependencias**:
    ```bash
    dotnet restore
    ```
   
3. **Ejecuta la API en applications**:
    ```bash
    dotnet run
    ```


## Visualización con Swagger
```sh
http://localhost:5257/swagger/index.html
https://localhost:7243/swagger/index.html
```

# Ejemplos de Uso

A continuación, se presentan ejemplos de cómo interactuar con la API a través de Postman. Los ejemplos incluyen solicitudes para crear, leer, actualizar y eliminar categorias.

## 1) CRUD Categorias

Crear
- Método: **POST**
- URL: `http://localhost:5257/api/v1/category/create`
- Encabezados: Content-Type: application/json
- Cuerpo (JSON):
    ```json
    {
    "name": "Nombre de categoria"
    }
    ```

Leer
- Método: **GET**
- URL: `http://localhost:5257/api/v1/category/getbyid/ac912413-9cdb-4769-ae09-2632c2919fc7`
- Encabezados: Content-Type: application/json

Actualizar
- Método: **PUT**
- URL: `http://localhost:5257/api/v1/category/update/ac912413-9cdb-4769-ae09-2632c2919fc7`
- Encabezados: Content-Type: application/json
- Cuerpo (JSON):
    ```json
    {
    "name": "Cambio de nombre"
    }
    ```

Eliminar
- Método: **DELETE**
- URL: `http://localhost:5257/api/v1/category/delete/ac912413-9cdb-4769-ae09-2632c2919fc7`
- Encabezados: Content-Type: application/json


## 2) CRUD Tareas
Crear
- Método: **POST**
- URL: `http://localhost:5257/api/v1/task/create`
- Encabezados: Content-Type: application/json
- Cuerpo (JSON):
    ```json
    {
        "category_id": "ac912413-9cdb-4769-ae09-2632c2919fc7",
        "title": "Realizar backup",
        "description": "Respaldar información crítica del sistema",
        "status": 1 // Pending = 1, Completed = 2
    }
    ```
> `Id de categoria`: La variable `category_id` se obtiene una vez creado la categoria.

> `Estados`: La variable `status` se tiene que poner en enteros 1 u 2, ya que se esta trabajando en formato `ENUM`

Leer
- Método: **GET**
- URL: `http://localhost:5257/api/v1/task/getbyid/07350ecb-a808-411e-a7a3-7aeffcde008a`
- Encabezados: Content-Type: application/json

Actualizar
- Método: **PUT**
- URL: `http://localhost:5257/api/v1/task/update/07350ecb-a808-411e-a7a3-7aeffcde008a`
- Encabezados: Content-Type: application/json
- Cuerpo (JSON):
    ```json
    {
        "category_id": "ac912413-9cdb-4769-ae09-2632c2919fc7",
        "title": "Cambio de nombre",
        "description": "Respaldar información crítica del sistema",
        "status": 2 // Pending = 1, Completed = 2
    }
    ```

Eliminar
- Método: **DELETE**
- URL: `http://localhost:5257/api/v1/task/delete/ac912413-9cdb-4769-ae09-2632c2919fc7`
- Encabezados: Content-Type: application/json


## 3) Reportes
Filtrado por ID CATEGORIA, FECHA, ESTADO

- Método: **GET**
- URL: `http://localhost:5257/api/v1/report/getbyfilters?categoryId=ac912413-9cdb-4769-ae09-2632c2919fc7&date=2025-04-14&status=1`
- Encabezados: Content-Type: application/json


Estadisticas
- Método: **GET**
- URL: `http://localhost:5257/api/v1/report/statistics`
- Encabezados: Content-Type: application/json