List<int> lista1 = new List<int>();
List<int> lista2 = new List<int>();

for (int i = 0; i < 5; i++)
{
    int numero;
    bool conversionCorrecta;
    do
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("  PRIMERA LISTA  (solo 5 números)");
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine("  Vas " + (i + 1) + " de 5 para la LISTA 1.");
        Console.WriteLine("  (La LISTA 2 se pedirá después, aparte.)");
        Console.WriteLine();
        Console.Write("  Escribe el número: ");
        string? texto = Console.ReadLine();
        conversionCorrecta = int.TryParse(texto, out numero);
        if (!conversionCorrecta)
        {
            Console.WriteLine();
            Console.WriteLine("  ERROR: Debe ingresar un número entero.");
            Console.WriteLine("  No use letras ni caracteres que no sean dígitos.");
            Console.WriteLine();
            Console.WriteLine("  Presione una tecla para intentar de nuevo...");
            Console.ReadKey();
        }
    } while (!conversionCorrecta);
    lista1.Add(numero);
}

for (int i = 0; i < 5; i++)
{
    int numero;
    bool conversionCorrecta;
    do
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("  SEGUNDA LISTA  (otros 5 números)");
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine("  La LISTA 1 ya tiene sus 5 números guardados.");
        Console.WriteLine("  Vas " + (i + 1) + " de 5 para la LISTA 2.");
        Console.WriteLine();
        Console.Write("  Escribe el número: ");
        string? texto = Console.ReadLine();
        conversionCorrecta = int.TryParse(texto, out numero);
        if (!conversionCorrecta)
        {
            Console.WriteLine();
            Console.WriteLine("  ERROR: Debe ingresar un número entero.");
            Console.WriteLine("  No use letras ni caracteres que no sean dígitos.");
            Console.WriteLine();
            Console.WriteLine("  Presione una tecla para intentar de nuevo...");
            Console.ReadKey();
        }
    } while (!conversionCorrecta);
    lista2.Add(numero);
}

Console.Clear();

Console.WriteLine("========================================");
Console.WriteLine("           RESULTADOS FINALES");
Console.WriteLine("========================================");
Console.WriteLine();

Console.WriteLine("  LISTA 1  (" + lista1.Count + " datos - primera mitad)");
Console.WriteLine("  --------------------------------");
for (int i = 0; i < lista1.Count; i++)
{
    Console.WriteLine("    Lista 1 [" + (i + 1) + "] = " + lista1[i]);
}
Console.WriteLine();

Console.WriteLine("  LISTA 2  (" + lista2.Count + " datos - segunda mitad)");
Console.WriteLine("  --------------------------------");
for (int i = 0; i < lista2.Count; i++)
{
    Console.WriteLine("    Lista 2 [" + (i + 1) + "] = " + lista2[i]);
}
Console.WriteLine();

HashSet<int> valoresUnicos = new HashSet<int>();
foreach (int n in lista1)
{
    valoresUnicos.Add(n);
}
foreach (int n in lista2)
{
    valoresUnicos.Add(n);
}

Console.WriteLine("  Valores únicos ");
Console.WriteLine("  --------------------------------");
foreach (int n in valoresUnicos)
{
    Console.WriteLine("    " + n);
}
Console.WriteLine();

int cantidadRepetidos = 0;
for (int i = 0; i < lista1.Count; i++)
{
    for (int j = 0; j < lista2.Count; j++)
    {
        if (lista1[i] == lista2[j])
        {
            cantidadRepetidos++;
        }
    }
}

Console.WriteLine("  Repeticiones entre ambas listas");
Console.WriteLine("  --------------------------------");
Console.WriteLine("    Total: " + cantidadRepetidos);
Console.WriteLine();
Console.WriteLine("========================================");
