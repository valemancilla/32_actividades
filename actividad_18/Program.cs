void LimpiarConsola() // Función auxiliar para limpiar la consola de forma segura.
{
    try // Intentamos limpiar la consola.
    {
        Console.Clear(); // Borra el contenido visible de la consola.
    }
    catch (IOException) // Si ocurre un error de E/S, ignoramos para no detener el programa.
    {
    }
}

List<int> numeros = new List<int>(); // Lista donde guardaremos los 10 números ingresados.
for (int i = 1; i <= 10; i++) // Recorremos 10 entradas (i va de 1 a 10).
{
    int valor; // Variable donde guardaremos el número ya validado.
    do // Ejecuta el bloque al menos una vez, y se repetirá hasta que el usuario ingrese un entero válido.
    {
        Console.Write($"Número {i} de 10: "); // Pide el número indicando en qué posición va (1..10).
        string? linea = Console.ReadLine(); // Lee la entrada como texto (puede ser null).
        if (int.TryParse(linea, out valor)) // Intenta convertir el texto a entero; si funciona, guarda en `valor`.
            break; // Sale del `do-while` porque ya tenemos un entero válido.
        Console.WriteLine("Escribe un número entero válido."); // Mensaje si la conversión falló.
    } while (true);

    numeros.Add(valor); // Agregamos el entero válido a la lista.
}
LimpiarConsola(); // Limpia la consola antes de mostrar/usar resultados.

List<int> pares = new List<int>(); // Lista donde guardaremos solo los números pares.
foreach (int n in numeros) // Recorremos cada número de la lista `numeros`.
{
    if (n % 2 == 0) // Un número es par si al dividir entre 2 el residuo es 0.
        pares.Add(n); // Si es par, lo agregamos a la lista `pares`.
}
LimpiarConsola(); // Limpia nuevamente antes de imprimir el resultado final.

Console.WriteLine("Lista con solo números pares:"); // Muestra un encabezado para el resultado.
foreach (int p in pares) // Recorremos la lista de pares.
    Console.WriteLine(p); // Imprimimos cada número par en una línea.
