List<string> nombres = new List<string>(); // Lista donde guardamos los 10 nombres ingresados.

for (int i = 0; i < 10; i++) // Recorre 10 veces para pedir 10 nombres.
{
    Console.Clear(); // Limpia la pantalla para la captura del nombre i.
    Console.Write("Ingrese el nombre " + (i + 1) + " de 10:"); // Pide el nombre indicando el turno.
    string nombre = Console.ReadLine()!; // Lee el nombre (se asume que no será null).
    nombres.Add(nombre); // Guarda el nombre en la lista.
}

HashSet<string> vistos = new HashSet<string>(); // Conjunto para detectar nombres repetidos (evita duplicados al guardar).

Console.Clear(); // Limpia antes de mostrar el resultado final.

Console.WriteLine("Nombres repetidos:"); // Encabezado del listado de repetidos.

foreach (string nombre in nombres) // Recorre todos los nombres ingresados.
{
    if (vistos.Contains(nombre)) // Si el nombre ya fue visto antes...
    {
        Console.WriteLine(nombre); // ...lo imprime como repetido.
    }
    else
    {
        vistos.Add(nombre); // Si no se había visto, lo registramos en el conjunto.
    }
}
