// Limpia la pantalla de la consola
Console.Clear();

// Lleva la cuenta de cuántos números pares encontramos
int contador = 0;

// Recorre todos los números del 1 al 100
for (int i = 1; i <= 100; i++)
{
    // Si el número es par (divisible entre 2)
    if (i % 2 == 0)
    {
        // Muestra el número par en pantalla
        Console.WriteLine(i);
        // Suma 1 al contador de pares
        contador = contador + 1;
    }
}

// Al terminar el ciclo, muestra cuántos pares hubo
Console.WriteLine("Hubo " + contador + " números pares.");
