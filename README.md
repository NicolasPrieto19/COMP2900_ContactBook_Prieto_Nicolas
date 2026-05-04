# Contact Book — C#

Una aplicación sencilla de libreta de contactos hecha en C# para mi clase de Estructura de Datos. Puedes agregar, editar, eliminar, buscar, ordenar y deduplicar contactos, todo desde la terminal.

> Este código está 100% inspirado en los videos de creación de Contact Book del profesor H. Bruckman de la Universidad Interamericana de Puerto Rico, Recinto Bayamón.

---

## Qué contiene el proyecto

| Archivo | Qué hace |
|---|---|
| `Contact.cs` | El modelo de contacto (nombre, apellido, teléfono, correo) |
| `ContactBook.cs` | Clase principal — maneja la interfaz y todas las operaciones |
| `ContactComparer.cs` | Permite ordenar los contactos por diferentes campos |
| `ContactMerger.cs` | Encuentra contactos duplicados usando el algoritmo DSU |
| `ContactSeed.cs` | Lista de contactos de prueba para iniciar la app con datos |
| `Program.cs` | Punto de entrada, simplemente arranca todo |

---

## Funciones disponibles

- Crear contactos
- Ver contactos
- Editar contactos
- Eliminar contactos
- Buscar y filtrar contactos
- Ordenar por nombre, apellido, teléfono o correo
- Deduplicar contactos (encuentra contactos que comparten teléfono o correo)
- Paginación con tamaño de página ajustable

---

## Estructuras de datos y algoritmos utilizados

- `List<Contact>` — almacena todos los contactos en memoria
- `Dictionary<string, int>` — índice invertido para detectar teléfonos y correos duplicados rápidamente
- `IComparer<Contact>` — comparador personalizado para el ordenamiento
- TimSort — algoritmo de ordenamiento usado internamente por `List<T>.Sort()`
- Disjoint Set Union (DSU) / Union-Find — algoritmo principal detrás de la función de deduplicación, agrupa contactos que probablemente son la misma persona aunque sus nombres sean distintos

---

## Cómo correrlo

Necesitas tener el [.NET SDK](https://dotnet.microsoft.com/download) instalado.

```bash
git clone https://github.com/NicolasPrieto19/COMP2900_ContactBook_Prieto_Nicolas.git
cd TU_REPOSITORIO
dotnet run
```

---

## Notas

- No usa base de datos ni archivos — todo vive en memoria mientras la app está corriendo
- Los datos de prueba incluyen un duplicado intencional (Carmen Beltran) para probar la función de deduplicación
- Hecho con fines educativos como parte de una tarea de la clase de Estructura de Datos
