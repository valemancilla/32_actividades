// Acumulador: aquí se guarda la suma de todos los números ingresados
int suma = 0;
// Valor leído en cada vuelta; -1 solo para entrar al while la primera vez (no es un número que se sume)
int numero = -1;

// Se repite mientras el número sea distinto de 0; al ingresar 0 termina el ciclo (condición de salida)
while (numero != 0)
{
    Console.Clear();
    Console.WriteLine("Ingrese un número (escriba 0 para terminar y ver la suma):");
    string entrada = Console.ReadLine()!;
    // Convierte el texto a entero para poder sumar
    numero = int.Parse(entrada);
    // El 0 no se suma; solo indica que el usuario quiere ver el resultado
    if (numero != 0)
    {
        suma = suma + numero;
    }
}

Console.Clear();
// Muestra el total acumulado después de salir del while
Console.WriteLine("Suma total: " + suma);
