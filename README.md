
# 📦 Proyecto ASP.NET MVC: Gestión de Reseñas de Productos

Aplicación web construida con **ASP.NET Core MVC**, diseñada para gestionar reseñas de productos a través de una interfaz CRUD amigable. Este proyecto se conecta a una **API REST externa** que utiliza **autenticación JWT**, consumida mediante `HttpClient`.

---

## 🚀 Funcionalidades

✅ Visualizar todas las reseñas registradas  
✅ Agregar nuevas reseñas de productos  
✅ Modificar reseñas existentes  
✅ Eliminar reseñas de forma segura  
✅ Ver el detalle completo de una reseña  
✅ Validación de formularios y mensajes de error  
✅ Interfaz simple y adaptable

---

## 🛠️ Tecnologías utilizadas

- ASP.NET Core MVC (C#)
- Razor Pages (HTML)
- HttpClient
- Newtonsoft.Json (para serialización JSON)
- API REST con JWT (token bearer)
- Bootstrap 5 (en diseño básico, opcional)

---

## ⚙️ Configuración del proyecto

### 0. Requisitos previos

- Tener una instancia de **SQL Server** en ejecución.
- Restaurar la base de datos `AdventureWorks2022` (disponible en el sitio oficial de Microsoft).
- Verificá que el API al que se conecta el proyecto esté correctamente configurado para usar esa base de datos.

### 1. Clonar el repositorio

```bash
git clone https://github.com/TU-USUARIO/NOMBRE-DEL-REPO.git
```

### 2. Configurar `appsettings.json`

Asegurate de definir tu `baseUrl` en `appsettings.json`:

```json
"ConfigApi": {
  "baseUrl": "https://tudominioapi.com/"
}
```

> También se puede proteger con secretos de usuario para no compartir tokens.

### 3. Ejecutar el proyecto

Desde Visual Studio o con CLI:

```bash
dotnet build
dotnet run
```

---

## 🔐 Autenticación

El sistema se conecta a una API protegida por JWT. El login inicial genera un token que luego se utiliza en las cabeceras de cada solicitud HTTP al API.

---

## 🧑‍🏫 Proyecto académico

Este proyecto fue desarrollado como parte del curso de **Programación Avanzada / Aplicaciones Web** y está destinado a demostrar habilidades en:

- Consumo de APIs REST
- Manejo de autenticación segura
- Separación de capas (servicios, modelos, controladores)
- Uso de patrones MVC en entornos reales

---

## 📄 Licencia

Este proyecto es de uso académico. Puedes reutilizarlo con fines educativos o personales. ¡Siéntete libre de contribuir!
