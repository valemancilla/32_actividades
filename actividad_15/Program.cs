// Contadores: acumulan cuántos números positivos, negativos y ceros se ingresaron
int positivos = 0;
int negativos = 0;
int ceros = 0;

// Se repite 10 veces para pedir los 10 números
for (int i = 1; i <= 10; i++)
{
    Console.Clear();
    Console.WriteLine("Ingrese el número " + i + " de 10:");
    string entrada = Console.ReadLine()!;
    // Convierte el texto escrito por el usuario a número entero
    int numero = int.Parse(entrada);

    if (numero > 0)
    {
        positivos = positivos + 1;
    }
    else if (numero < 0)
    {
        negativos = negativos + 1;
    }
    else
    {
        // Si no es mayor ni menor que 0, entonces es cero
        ceros = ceros + 1;
    }
}

Console.Clear();
// Muestra el resultado final de los tres contadores
Console.WriteLine("Cantidad de positivos: " + positivos);
Console.WriteLine("Cantidad de negativos: " + negativos);
Console.WriteLine("Cantidad de ceros: " + ceros);
