Console.Clear();
Console.WriteLine("===================================");
Console.WriteLine("Generador simple de permutaciones");
Console.WriteLine("===================================");
Console.Write("Ingresa una cadena: ");
string? cadena = Console.ReadLine();

if (cadena == null || cadena == "")
{
    Console.WriteLine("No ingresaste una cadena.");
    return;
}

Console.Clear();
Console.WriteLine("===============");
Console.WriteLine("Permutaciones:");
Console.WriteLine("===============");

Permutaciones(cadena);

void Permutaciones(string texto)
{
    char[] caracteres = texto.ToCharArray();
    Generar(caracteres, 0);
}

void Generar(char[] caracteres, int indice)
{
    if (indice == caracteres.Length - 1)
    {
        Console.WriteLine(new string(caracteres));
        return;
    }

    for (int i = indice; i < caracteres.Length; i++)
    {
        char temp = caracteres[indice];
        caracteres[indice] = caracteres[i];
        caracteres[i] = temp;

        Generar(caracteres, indice + 1);

        temp = caracteres[indice];
        caracteres[indice] = caracteres[i];
        caracteres[i] = temp;
    }
}
