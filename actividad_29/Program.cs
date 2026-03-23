List<string> nombres = new List<string>();

for (int i = 0; i < 10; i++)
{
    Console.Clear();
    Console.Write("Ingrese el nombre " + (i + 1) + " de 10:");
    string nombre = Console.ReadLine()!;
    nombres.Add(nombre);
}

HashSet<string> vistos = new HashSet<string>();

Console.Clear();

Console.WriteLine("Nombres repetidos:");

foreach (string nombre in nombres)
{
    if (vistos.Contains(nombre))
    {
        Console.WriteLine(nombre);
    }
    else
    {
        vistos.Add(nombre);
    }
}
