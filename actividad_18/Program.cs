void LimpiarConsola()
{
    try
    {
        Console.Clear();
    }
    catch (IOException)
    {
        
    }
}

// Paso 1: crear List<int> con 10 números (los introduces tú por consola)
List<int> numeros = new List<int>();
for (int i = 1; i <= 10; i++)
{
    int valor;
    do
    {
        Console.Write($"Número {i} de 10: ");
        string? linea = Console.ReadLine();
        if (int.TryParse(linea, out valor))
            break;
        Console.WriteLine("Escribe un número entero válido.");
    } while (true);

    numeros.Add(valor);
}
LimpiarConsola();

// Paso 2: nueva lista solo con números pares (recorrido + if)
List<int> pares = new List<int>();
foreach (int n in numeros)
{
    if (n % 2 == 0)
        pares.Add(n);
}
LimpiarConsola();

// Paso 3: mostrar la lista de pares en consola
Console.WriteLine("Lista con solo números pares:");
foreach (int p in pares)
    Console.WriteLine(p);
