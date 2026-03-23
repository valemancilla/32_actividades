List<string> nombres = new List<string>(); // Lista donde guardamos los 5 nombres ingresados por el usuario.

for (int i = 1; i <= 5; i++) // Repite el proceso 5 veces (i vale de 1 a 5).
{
    LimpiarConsola(); // Limpia la consola para que cada entrada se vea más ordenada.
    Console.WriteLine("Ingrese 5 nombres:"); // Muestra el mensaje general de entrada.
    Console.Write($"Nombre {i}: "); // Pide el nombre actual indicando el número de ingreso (1..5).
    string? nombre = Console.ReadLine(); // Lee la línea escrita por el usuario (puede ser null si el input falla).
    nombres.Add(nombre ?? string.Empty); // Agrega a la lista el valor; si fue null, usa cadena vacía.
}

LimpiarConsola(); // Limpia la consola antes de pedir el dato a buscar.
Console.Write("Ingrese el nombre a buscar: "); // Pide al usuario que escriba el nombre a verificar.
string? nombreBuscado = Console.ReadLine(); // Guarda el nombre a buscar (puede ser null).

if (nombres.Contains(nombreBuscado ?? string.Empty)) // Revisa si la lista contiene el nombre (o cadena vacía si era null).
    Console.WriteLine("El nombre existe en la lista."); // Informa que el nombre sí está en la lista.
else
    Console.WriteLine("El nombre no existe en la lista."); // Informa que el nombre no está en la lista.

void LimpiarConsola() // Método auxiliar para limpiar la consola.
{
    Console.Clear(); // Borra el contenido visible de la consola.
}
