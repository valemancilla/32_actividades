Console.Clear();
// Pide al usuario un número entero
Console.Write("Ingrese un número entero: ");
string entrada = Console.ReadLine()!;
int numero = int.Parse(entrada);

// Limpia la consola antes de mostrar la tabla de multiplicar
Console.Clear();

// Muestra la tabla del 1 al 10
for (int i = 1; i <= 10; i++)
{
    int resultado = numero * i;
    Console.WriteLine(numero + " x " + i + " = " + resultado);
}
