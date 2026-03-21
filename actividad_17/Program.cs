List<string> nombres = new List<string>();

for (int i = 1; i <= 5; i++)
{
    LimpiarConsola();
    Console.WriteLine("Ingrese 5 nombres:");
    Console.Write($"Nombre {i}: ");
    string? nombre = Console.ReadLine();
    nombres.Add(nombre ?? string.Empty);
}

LimpiarConsola();
Console.Write("Ingrese el nombre a buscar: ");
string? nombreBuscado = Console.ReadLine();

if (nombres.Contains(nombreBuscado ?? string.Empty))
    Console.WriteLine("El nombre existe en la lista.");
else
    Console.WriteLine("El nombre no existe en la lista.");

void LimpiarConsola()
{
    Console.Clear();
}
