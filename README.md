# Sistema de Inventario y Ventas

**Autor:** Diego Alejandro Gómez Vasquez  
**Carnet:** 2500028

---

## Descripción

Este proyecto implementa un sistema de inventario y ventas, permitiendo:

- Gestión de clientes.
- Gestión de productos.
- Registro de ventas y detalles de ventas.
- Consultas por cliente, producto y correo.
- Control de stock de productos.
- Soporte para diferentes métodos de pago.

El sistema está desarrollado con:

- **Base de datos:** MySQL 
- **Lenguaje:** C# 
- **Patrón de diseño:** Repository Pattern
- **Tecnologías adicionales:** ADO.NET para conexión a la base de datos

---

## Estructura de la Base de Datos

- **Tabla `cliente`**: Información de clientes (nombre, nit, correo, teléfono, dirección, fecha de registro).  
- **Tabla `productos`**: Inventario de productos con precio, stock, descripción y estado.  
- **Tabla `ventas`**: Registro de ventas realizadas, vinculadas a clientes.  
- **Tabla `detalles_venta`**: Detalles de cada venta (productos, cantidad, subtotal).  

---

## Cómo usar el proyecto

1. Crear la base de datos ejecutando el script `inventario_db.sql` (adjunta en el apartado de Classroom).
2. Configurar la cadena de conexión en `DbConnectionFactory`.
3. Ejecutar la aplicación y probar las operaciones de:
   - Registrar clientes y productos.
   - Realizar ventas y registrar detalles.
   - Consultar clientes por ID, nombre, nit o correo.
   - Actualizar o eliminar clientes.

---

## Integrantes

- Diego Alejandro Gómez Vasquez - 2500028
