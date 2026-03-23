List<int> edades = new List<int>();
int edad = 0;

while (edad != -1)
{
    Console.Clear();
    Console.Write("Ingrese una edad (Escribe -1 para terminar):");
    string? linea = Console.ReadLine();
    if (linea == null)
    {
        linea = "";
    }
    edad = int.Parse(linea);
    if (edad != -1)
    {
        edades.Add(edad);
    }
}

Console.Clear();

int cantidad = edades.Count;
int suma = 0;
int mayores = 0;
int menores = 0;
int indice = 0;

while (indice < edades.Count)
{
    int actual = edades[indice];
    suma = suma + actual;
    if (actual >= 18)
    {
        mayores = mayores + 1;
    }
    if (actual < 18)
    {
        menores = menores + 1;
    }
    indice = indice + 1;
}

double promedio = 0;
if (cantidad > 0)
{
    promedio = (double)suma / cantidad;
}

Console.WriteLine("========== RESULTADOS ==========");
Console.WriteLine(        "Gestión de edades"       );
Console.WriteLine("================================");
Console.WriteLine("Cantidad de edades registradas: " + cantidad);
Console.WriteLine("Promedio de edades: " + promedio);
Console.WriteLine("Mayores de edad (>= 18): " + mayores);
Console.WriteLine("Menores de edad (< 18): " + menores);
