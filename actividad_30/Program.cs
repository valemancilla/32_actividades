List<int> edades = new List<int>(); // Lista donde guardamos las edades ingresadas.
int edad = 0; // Controla el ciclo: se usa -1 como valor de corte.

while (edad != -1) // Continúa pidiendo edades hasta que el usuario escriba -1.
{
    Console.Clear(); // Limpia para que cada ingreso se vea ordenado.
    Console.Write("Ingrese una edad (Escribe -1 para terminar):"); // Pide la edad al usuario.
    string? linea = Console.ReadLine(); // Lee el texto; puede ser null.
    if (linea == null) // Si el usuario no ingresó nada (null)...
    {
        linea = ""; // Convertimos null a "" para que int.Parse no reviente por null.
    }
    edad = int.Parse(linea); // Convierte el texto a entero.
    if (edad != -1) // Si no es el valor de salida (-1)...
    {
        edades.Add(edad); // Guardamos la edad en la lista.
    }
}

Console.Clear(); // Limpia antes de mostrar resultados.

int cantidad = edades.Count; // Cantidad de edades registradas.
int suma = 0; // Acumulador para la suma total.
int mayores = 0; // Contador de mayores (>= 18).
int menores = 0; // Contador de menores (< 18).
int indice = 0; // Índice para recorrer la lista con while.

while (indice < edades.Count) // Recorre toda la lista usando índices.
{
    int actual = edades[indice]; // Toma la edad actual según el índice.
    suma = suma + actual; // Suma esa edad al acumulador.
    if (actual >= 18) // Si la edad es mayor o igual a 18...
    {
        mayores = mayores + 1; // Incrementa el contador de mayores.
    }
    if (actual < 18) // Si la edad es menor que 18...
    {
        menores = menores + 1; // Incrementa el contador de menores.
    }
    indice = indice + 1; // Avanza al siguiente índice.
}

double promedio = 0; // Variable donde guardaremos el promedio.
if (cantidad > 0) // Solo calculamos promedio si hay al menos una edad.
{
    promedio = (double)suma / cantidad; // Promedio con división decimal.
}

Console.WriteLine("========== RESULTADOS =========="); // Separador de resultados.
Console.WriteLine(        "Gestión de edades"       ); // Título de la sección.
Console.WriteLine("================================"); // Separador.
Console.WriteLine("Cantidad de edades registradas: " + cantidad); // Muestra cuántas edades se registraron.
Console.WriteLine("Promedio de edades: " + promedio); // Muestra el promedio final.
Console.WriteLine("Mayores de edad (>= 18): " + mayores); // Muestra cuántos son mayores de edad.
Console.WriteLine("Menores de edad (< 18): " + menores); // Muestra cuántos son menores de edad.
