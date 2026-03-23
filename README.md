## Descripción del Proyecto

Este repositorio reúne **32 proyectos de consola en C#**. Hay **exactamente 32 carpetas** en la raíz, listadas más abajo en **orden real del disco** (de `actividad1` a `actividad_8`, luego `actividad9`, luego `actividad_10` … `actividad_31`, y por último `actividad32`). **No existe** una carpeta `actividad_9`; la actividad 9 es la carpeta **`actividad9`**. Cada carpeta es un ejecutable independiente (`OutputType` Exe) que resuelve un ejercicio distinto: programas lineales, bucles, menús, colecciones (`List`, `HashSet`, `ArrayList`), validación, algoritmos y el caso en capas **actividad9** (BreakLine Events).

La solución en la raíz, **`32actividades.sln`**, referencia de forma explícita el proyecto **actividad9**. Los demás proyectos se abren o compilan con su **`*.csproj`** desde la carpeta correspondiente (por ejemplo `dotnet run` dentro de `actividad_15`).

### Catálogo de las 32 actividades (según el código fuente)

| # | Carpeta | Qué implementa el programa |
|---|---------|----------------------------|
| 1 | `actividad1` | Menú en consola: muestra filas de una tabla de ejemplo y **filtra por texto** (coincidencia parcial, sin distinguir mayúsculas/minúsculas). |
| 2 | `actividad_2` | Dado un arreglo de enteros, **obtiene los valores repetidos** (aparecen más de una vez) y los muestra. |
| 3 | `actividad_3` | **Generador de contraseñas**: longitud aleatoria entre 15 y 87, al menos una mayúscula, minúscula, dígito y símbolo; luego **mezcla** los caracteres. |
| 4 | `actividad_4` | Lee una cadena, normaliza tildes a letras base, cuenta **frecuencia de caracteres alfanuméricos** (solo letras y números). |
| 5 | `actividad_5` | Pide enteros positivos y un **objetivo de suma**; verifica si **existe un subconjunto** cuyos elementos suman ese valor. |
| 6 | `actividad_6` | Lee una cadena y muestra **todas las permutaciones** (intercambio recursivo / backtracking). |
| 7 | `actividad_7` | Comprueba **símbolos equilibrados** `()`, `[]`, `{}` en una expresión; devuelve código de error o posición según la lógica del ejercicio. |
| 8 | `actividad_8` | Determina si dos textos son **anagramas** (mismas letras en otro orden; excluye el caso de cadenas idénticas). |
| 9 | `actividad9` | **BreakLine Events**: conciliación de asistentes (fuentes, lista negra, ausentes) e **inscripciones a talleres** con menú, servicios y reporte (ver detalle en archivos). |
| 10 | `actividad_10` | Registro de **correos** en `HashSet`; indica si cada entrada es nueva o duplicada; termina con `salir` y muestra la lista. |
| 11 | `actividad_11` | CRUD ligero de **estudiantes** (código + nombre) con `HashSet<Estudiante>` y **Equals/GetHashCode** por código; menú registrar / listar / buscar. |
| 12 | `actividad_12` | Lista los **números pares del 1 al 100** y muestra cuántos hay. |
| 13 | `actividad_13` | Pide un entero y muestra su **tabla de multiplicar del 1 al 10**. |
| 14 | `actividad_14` | Lee números hasta que el usuario ingrese **0**; muestra la **suma acumulada** (el 0 no suma). |
| 15 | `actividad_15` | Lee **10 números** y cuenta cuántos son **positivos, negativos o cero**. |
| 16 | `actividad_16` | Lee **8 enteros**, calcula **mayor, menor y promedio**. |
| 17 | `actividad_17` | Lee **5 nombres** en una lista y comprueba si un nombre **buscado existe** (`Contains`). |
| 18 | `actividad_18` | Lee **10 enteros** con validación; construye una lista solo con los **números pares**. |
| 19 | `actividad_19` | Registro de **notas** (`double`) hasta centinela **-1**; muestra listado, **promedio** y cantidad de notas **≥ 3.0**. |
| 20 | `actividad_20` | **Menú**: saludo, fecha simulada (`DateTime` fijo), **cuadrado** de un entero con validación, salir. |
| 21 | `actividad_21` | Pide **8 palabras**; usa `HashSet` para mostrar **cantidad de únicas** y la lista sin duplicados. |
| 22 | `actividad_22` | Bucle de **correos** con `HashSet`; mensajes de duplicado o registro; termina con `salir`. |
| 23 | `actividad_23` | Lee **12 enteros** validados, los lista y muestra **cuántos valores únicos** hay usando `HashSet<int>`. |
| 24 | `actividad_24` | **Inventario** con `ArrayList`: agrega nombres de productos en bucle (s/n) y lista el resultado. |
| 25 | `actividad_25` | Captura **nombre, edad, estatura y bool**; los guarda en `ArrayList` y muestra **valor y tipo** de cada elemento. |
| 26 | `actividad_26` | Lee **15 enteros**, muestra la lista original y otra con solo **múltiplos de 3**. |
| 27 | `actividad_27` | **10 códigos de estudiante** con validación (no vacío) y `HashSet`; avisa duplicados; opción de listar al final. |
| 28 | `actividad_28` | **Lista de compras** (`List<string>`): menú agregar, mostrar (con `while` por índice), eliminar por nombre, salir. |
| 29 | `actividad_29` | Lee **10 nombres** y al final imprime los que aparecen **más de una vez** (detección de repetidos con `HashSet`). |
| 30 | `actividad_30` | Ingreso de **edades** hasta **-1**; calcula **promedio**, cantidad de **mayores de edad (≥18)** y **menores (<18)** con bucle `while` sobre índices. |
| 31 | `actividad_31` | Dos listas de **5 enteros** cada una (con `TryParse`); muestra ambas, **valores únicos** combinados (`HashSet`) y **total de coincidencias** entre listas (pares iguales). |
| 32 | `actividad32` | Grafo de **rutas con costo** (`RedRutas`), carga de ejemplo; **Dijkstra** para la ruta de **menor consumo** entre dos puntos; interacción en consola. |

## Características Destacadas

- **Cobertura amplia de fundamentos**: control de flujo (`if`, `for`, `while`, `do-while`, `switch`), entrada/salida, validación con `TryParse`, y mensajes en español con **UTF-8** donde se configura.
- **Colecciones**: uso pedagógico de `List<T>`, `HashSet<T>` (unicidad y detección de duplicados), y **`ArrayList`** (no genérico) en actividades 24 y 25.
- **Algoritmos y problemas clásicos**: permutaciones, subconjunto con suma dada, balanceo de paréntesis, anagramas, conteo de frecuencias, filtrado de tablas y **camino mínimo (Dijkstra)** en grafo dirigido ponderado.
- **Interfaces de usuario en consola**: muchas actividades usan `Console.Clear`, menús numéricos, pausas con `ReadKey` o `ReadLine`, y en varios casos bloques visuales (marcos, separadores).
- **Proyecto estructurado**: **actividad9** separa **modelos**, **servicios** y **utilidades** bajo el espacio de nombres orientado al evento **BreakLineEvents**.
- **Proyectos autocontenidos**: cada carpeta compila por sí sola; conviven convenciones distintas de namespace (algunos con `namespace`, otros con **top-level statements** o clases globales).

## Objetivo

Consolidar el aprendizaje de **C# y .NET** mediante una serie numerada de ejercicios que recorren sintaxis, estructuras de datos, buenas prácticas básicas de entrada, uso de colecciones y, en actividades avanzadas, **modelado simple**, **reportes en consola** y **algoritmos sobre grafos**, de forma que cada carpeta sea una entrega o práctica independiente.

## Tecnologías Utilizadas

- **Lenguaje:** C# (versiones de sintaxis acordes al SDK utilizado en el equipo de desarrollo).
- **Framework:** **.NET 10** — `TargetFramework` **net10.0** en todos los `.csproj` del repositorio.
- **Tipo de proyecto:** aplicación de consola — SDK **`Microsoft.NET.Sdk`** con **`OutputType` Exe**.
- **Opciones de compilación habituales:** `ImplicitUsings` y `Nullable` habilitados en la mayoría de proyectos (salvo anotaciones puntuales como `#nullable disable` donde el autor lo indicó).
- **Entorno:** Visual Studio 2022+ y/o **.NET CLI** (`dotnet build`, `dotnet run`).

## Estructura del Sistema

### Listado completo de las 32 carpetas de actividades (todas revisadas)

Estas son **todas** las carpetas `actividad*` que existen en la raíz del repositorio, en el orden en que aparecen al listar el directorio:

1. `actividad1`
2. `actividad_2`
3. `actividad_3`
4. `actividad_4`
5. `actividad_5`
6. `actividad_6`
7. `actividad_7`
8. `actividad_8`
9. `actividad9`
10. `actividad_10`
11. `actividad_11`
12. `actividad_12`
13. `actividad_13`
14. `actividad_14`
15. `actividad_15`
16. `actividad_16`
17. `actividad_17`
18. `actividad_18`
19. `actividad_19`
20. `actividad_20`
21. `actividad_21`
22. `actividad_22`
23. `actividad_23`
24. `actividad_24`
25. `actividad_25`
26. `actividad_26`
27. `actividad_27`
28. `actividad_28`
29. `actividad_29`
30. `actividad_30`
31. `actividad_31`
32. `actividad32`

### Árbol del repositorio (sin omitir carpetas de actividad)

```
32_actividades/
├── 32actividades.sln
├── README.md
├── actividad1/                 → actividad1.csproj, Program.cs
├── actividad_2/                → actividad_2.csproj, Program.cs
├── actividad_3/                → actividad_3.csproj, Program.cs
├── actividad_4/                → actividad_4.csproj, Program.cs
├── actividad_5/                → actividad_5.csproj, Program.cs
├── actividad_6/                → actividad_6.csproj, Program.cs
├── actividad_7/                → actividad_7.csproj, Program.cs
├── actividad_8/                → actividad_8.csproj, Program.cs
├── actividad9/                 → actividad9.csproj, Program.cs, models/, services/, utils/
├── actividad_10/               → actividad_10.csproj, Program.cs
├── actividad_11/               → actividad_11.csproj, Program.cs
├── actividad_12/               → actividad_12.csproj, Program.cs
├── actividad_13/               → actividad_13.csproj, Program.cs
├── actividad_14/               → actividad_14.csproj, Program.cs
├── actividad_15/               → actividad_15.csproj, Program.cs
├── actividad_16/               → actividad_16.csproj, Program.cs
├── actividad_17/               → actividad_17.sln, actividad_17.csproj, Program.cs
├── actividad_18/               → actividad_18.csproj, Program.cs
├── actividad_19/               → actividad_19.csproj, Program.cs
├── actividad_20/               → actividad_20.csproj, Program.cs
├── actividad_21/               → actividad_21.csproj, Program.cs
├── actividad_22/               → actividad_22.csproj, Program.cs
├── actividad_23/               → actividad_23.csproj, Program.cs
├── actividad_24/               → actividad_24.csproj, Program.cs
├── actividad_25/               → actividad_25.csproj, Program.cs
├── actividad_26/               → actividad_26.csproj, Program.cs
├── actividad_27/               → actividad_27.csproj, Program.cs
├── actividad_28/               → actividad_28.csproj, Program.cs
├── actividad_29/               → actividad_29.csproj, Program.cs
├── actividad_30/               → actividad_30.csproj, Program.cs
├── actividad_31/               → actividad_31.csproj, Program.cs
├── actividad32/                → actividad32.csproj, Program.cs (también RedRutas y RutaDijkstra en este archivo)
└── en cada proyecto: bin/, obj/   (generados al compilar; no son fuente)
```


## Qué Hace Cada Archivo

### En la raíz del repositorio

| Archivo | Función |
|---------|---------|
| `32actividades.sln` | Archivo de solución de Visual Studio; actualmente **referencia el proyecto `actividad9`**. Para trabajar con otra actividad, abrir su `.csproj` o añadir el proyecto a la solución. |
| `README.md` | Documentación del conjunto de actividades: descripción, catálogo, tecnologías, estructura y referencia de archivos. |

### Archivos principales en **cada** una de las 32 carpetas

Todas las actividades de **`actividad_2`** a **`actividad_31`** y **`actividad32`**, más **`actividad1`** y **`actividad9`**, siguen el mismo esquema mínimo: un **`.csproj`** homónimo de la carpeta y un **`Program.cs`**. La tabla confirma **carpeta → archivos de proyecto** sin saltos.

| Carpeta | Archivo de proyecto | Código de entrada | Otros archivos fuente (.cs) |
|---------|---------------------|-------------------|-----------------------------|
| `actividad1` | `actividad1.csproj` | `Program.cs` | — |
| `actividad_2` | `actividad_2.csproj` | `Program.cs` | — |
| `actividad_3` | `actividad_3.csproj` | `Program.cs` | — |
| `actividad_4` | `actividad_4.csproj` | `Program.cs` | — |
| `actividad_5` | `actividad_5.csproj` | `Program.cs` | — |
| `actividad_6` | `actividad_6.csproj` | `Program.cs` | — |
| `actividad_7` | `actividad_7.csproj` | `Program.cs` | — |
| `actividad_8` | `actividad_8.csproj` | `Program.cs` | — |
| `actividad9` | `actividad9.csproj` | `Program.cs` | `models/*.cs`, `services/*.cs`, `utils/ConsoleMarcos.cs` |
| `actividad_10` | `actividad_10.csproj` | `Program.cs` | — |
| `actividad_11` | `actividad_11.csproj` | `Program.cs` | — (clase `Estudiante` en el mismo `Program.cs`) |
| `actividad_12` | `actividad_12.csproj` | `Program.cs` | — |
| `actividad_13` | `actividad_13.csproj` | `Program.cs` | — |
| `actividad_14` | `actividad_14.csproj` | `Program.cs` | — |
| `actividad_15` | `actividad_15.csproj` | `Program.cs` | — |
| `actividad_16` | `actividad_16.csproj` | `Program.cs` | — |
| `actividad_17` | `actividad_17.csproj` | `Program.cs` | — |
| `actividad_18` | `actividad_18.csproj` | `Program.cs` | — |
| `actividad_19` | `actividad_19.csproj` | `Program.cs` | — |
| `actividad_20` | `actividad_20.csproj` | `Program.cs` | — |
| `actividad_21` | `actividad_21.csproj` | `Program.cs` | — |
| `actividad_22` | `actividad_22.csproj` | `Program.cs` | — |
| `actividad_23` | `actividad_23.csproj` | `Program.cs` | — |
| `actividad_24` | `actividad_24.csproj` | `Program.cs` | — |
| `actividad_25` | `actividad_25.csproj` | `Program.cs` | — |
| `actividad_26` | `actividad_26.csproj` | `Program.cs` | — |
| `actividad_27` | `actividad_27.csproj` | `Program.cs` | — |
| `actividad_28` | `actividad_28.csproj` | `Program.cs` | — |
| `actividad_29` | `actividad_29.csproj` | `Program.cs` | — |
| `actividad_30` | `actividad_30.csproj` | `Program.cs` | — |
| `actividad_31` | `actividad_31.csproj` | `Program.cs` | — |
| `actividad32` | `actividad32.csproj` | `Program.cs` | — (en el mismo archivo: clases `RedRutas`, `RutaDijkstra`) |

Además, **`actividad_17`** incluye **`actividad_17.sln`** en su carpeta (solución local).

### Rol genérico de los archivos comunes

| Archivo | Función |
|---------|---------|
| `*.csproj` | Define el SDK, `TargetFramework` (net10.0), tipo de salida, usings implícitos y nullable. |
| `Program.cs` | Lógica del ejercicio (ver catálogo arriba). En **actividad32** convive con **`RedRutas`** y **`RutaDijkstra`** en el mismo fichero. |

### Solo en `actividad_17`

| Archivo | Función |
|---------|---------|
| `actividad_17.sln` | Solución que agrupa únicamente `actividad_17.csproj` para abrir ese ejercicio de forma aislada. |

### Proyecto `actividad9` (BreakLine Events) — archivo por archivo

| Ruta | Función |
|------|---------|
| `Program.cs` | Menú principal: **(1)** cargar datos de prueba, **(2)** procesar conciliación (autorizados, no autorizados, ausentes, inscripciones), **(3)** mostrar **reporte consolidado** (tras 1 y 2), **(4)** salir. Usa `ServicioConciliacion`, `ReporteService` y `ConsoleMarcos`. |
| `models/Participante.cs` | Entidad **participante** del dominio (datos de persona para listas e inscripciones). |
| `models/Taller.cs` | Entidad **taller** asociada al evento. |
| `models/InscripcionTaller.cs` | Relación **inscripción** (participante + taller); implementa **`IEquatable`** para usar correctamente en `HashSet`. |
| `services/ServicioConciliacion.cs` | Reglas de negocio: conjuntos (preregistro, manual, VIP, lista negra, asistentes reales), **unión/diferencia** para autorizados y no autorizados, **ausentes**, validación de **inscripciones** y listas de duplicados/rechazos. |
| `services/ReporteService.cs` | Presentación del **reporte consolidado** en consola a partir del estado del servicio. |
| `utils/ConsoleMarcos.cs` | Helpers visuales: **marcos**, líneas y **métricas alineadas** para la salida en consola. |

### Carpetas generadas (todas las actividades)

| Ubicación | Función |
|-----------|---------|
| `bin/` | Ejecutables, DLLs y dependencias publicadas al compilar o publicar. |
| `obj/` | Archivos intermedios de compilación (no deben versionarse en control de código si se usan exclusiones estándar). |

## Autor

valentina mancilla
