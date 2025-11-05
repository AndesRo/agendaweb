# 📅 AgendaWeb

Aplicación web moderna desarrollada con **ASP.NET Core 8.0**, conectada a una base de datos **SQLite**, diseñada para gestionar agendas y contactos de manera eficiente.  
El proyecto es completamente **responsivo**, con una interfaz técnica, profesional y adaptable a dispositivos móviles.

---

## 🚀 Características principales

- 📋 Gestión de contactos, tareas y eventos.
- 🧩 Conexión con **SQLite** mediante **Entity Framework Core**.
- 💻 Interfaz moderna con **Bootstrap 5.3**.
- 📱 Diseño **responsivo y adaptable** (PWA ready).
- 🔍 Búsqueda y filtrado dinámico.
- 💾 Persistencia local (Service Worker / modo offline opcional).
- ⚙️ Arquitectura **MVC (Model-View-Controller)**.
- 🌐 Preparado para despliegue en servidores web o **Azure App Service**.

---

## 🛠️ Tecnologías utilizadas

| Tipo                 | Tecnología                              |
| -------------------- | --------------------------------------- |
| Backend              | ASP.NET Core 8.0                        |
| Frontend             | HTML5, CSS3, JavaScript, Bootstrap 5.3  |
| Base de Datos        | SQLite                                  |
| ORM                  | Entity Framework Core                   |
| Herramientas         | Visual Studio Code / Visual Studio 2022 |
| Control de versiones | Git y GitHub                            |

---

## ⚙️ Instalación y ejecución

### 1️⃣ Clonar el repositorio

```bash
git clone https://github.com/AndesRo/AgendaWeb.git
cd AgendaWeb



##  Estructura del proyecto

AgendaWeb/
│
├── Controllers/
│   ├── HomeController.cs
│   ├── ContactosController.cs
│
├── Models/
│   ├── Contacto.cs
│   ├── AgendaContext.cs
│
├── Views/
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   ├── Home/
│   ├── Contactos/
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   ├── images/
│
├── Data/
│   └── agenda.db
│
├── appsettings.json
├── Program.cs
└── README.md


## 📄 Licencia

Este proyecto está licenciado bajo la MIT License – puedes usarlo libremente para proyectos personales o profesionales.
```
