List<int> lista1 = new List<int>(); // Primera lista (solo se ingresan 5 números).
List<int> lista2 = new List<int>(); // Segunda lista (otros 5 números).

for (int i = 0; i < 5; i++) // Repite 5 veces para llenar la lista 1.
{
    int numero; // Guardará el número entero válido ingresado.
    bool conversionCorrecta; // Indica si la conversión del texto a int fue correcta.
    do // Ejecuta al menos una vez y repite hasta que la conversión sea correcta.
    {
        Console.Clear(); // Limpia antes de mostrar el mensaje y pedir el número.
        Console.WriteLine("========================================"); // Separador visual.
        Console.WriteLine("  PRIMERA LISTA  (solo 5 números)"); // Título de la sección.
        Console.WriteLine("========================================"); // Separador visual.
        Console.WriteLine(); // Línea en blanco.
        Console.WriteLine("  Vas " + (i + 1) + " de 5 para la LISTA 1."); // Muestra en qué posición va el usuario.
        Console.WriteLine("  (La LISTA 2 se pedirá después, aparte.)"); // Aclara que después se pide la lista 2.
        Console.WriteLine(); // Línea en blanco.
        Console.Write("  Escribe el número: "); // Pide el número de forma directa.
        string? texto = Console.ReadLine(); // Lee la entrada como texto (puede ser null).
        conversionCorrecta = int.TryParse(texto, out numero); // Intenta convertir a int; si falla, no se asigna un valor válido.
        if (!conversionCorrecta) // Si no se pudo convertir...
        {
            Console.WriteLine(); // Línea en blanco para separar el error.
            Console.WriteLine("  ERROR: Debe ingresar un número entero."); // Mensaje de error.
            Console.WriteLine("  No use letras ni caracteres que no sean dígitos."); // Indica qué se requiere.
            Console.WriteLine(); // Línea en blanco.
            Console.WriteLine("  Presione una tecla para intentar de nuevo..."); // Pide pausar antes de reintentar.
            Console.ReadKey(); // Espera una tecla y vuelve a pedir.
        }
    } while (!conversionCorrecta); // Repite mientras la conversión siga fallando.
    lista1.Add(numero); // Agrega el número válido a la lista 1.
}

for (int i = 0; i < 5; i++) // Repite 5 veces para llenar la lista 2.
{
    int numero; // Guardará el número entero válido ingresado.
    bool conversionCorrecta; // Indica si la conversión del texto a int fue correcta.
    do // Repite hasta que el usuario ingrese un entero válido.
    {
        Console.Clear(); // Limpia antes de pedir el número de la lista 2.
        Console.WriteLine("========================================"); // Separador visual.
        Console.WriteLine("  SEGUNDA LISTA  (otros 5 números)"); // Título de la sección.
        Console.WriteLine("========================================"); // Separador visual.
        Console.WriteLine(); // Línea en blanco.
        Console.WriteLine("  La LISTA 1 ya tiene sus 5 números guardados."); // Aclara que lista1 ya está completa.
        Console.WriteLine("  Vas " + (i + 1) + " de 5 para la LISTA 2."); // Muestra la posición actual.
        Console.WriteLine(); // Línea en blanco.
        Console.Write("  Escribe el número: "); // Pide el número.
        string? texto = Console.ReadLine(); // Lee la entrada como texto.
        conversionCorrecta = int.TryParse(texto, out numero); // Convierte a entero si es posible.
        if (!conversionCorrecta) // Si el texto no se pudo convertir...
        {
            Console.WriteLine(); // Línea en blanco.
            Console.WriteLine("  ERROR: Debe ingresar un número entero."); // Mensaje de error.
            Console.WriteLine("  No use letras ni caracteres que no sean dígitos."); // Indica restricciones.
            Console.WriteLine(); // Línea en blanco.
            Console.WriteLine("  Presione una tecla para intentar de nuevo..."); // Aviso para reintentar.
            Console.ReadKey(); // Pausa y luego vuelve a intentar.
        }
    } while (!conversionCorrecta); // Se repite hasta que el valor sea válido.
    lista2.Add(numero); // Agrega el número válido a la lista 2.
}

Console.Clear(); // Limpia para mostrar resultados finales.

Console.WriteLine("========================================"); // Separador visual.
Console.WriteLine("           RESULTADOS FINALES"); // Título final.
Console.WriteLine("========================================"); // Separador visual.
Console.WriteLine(); // Línea en blanco.

Console.WriteLine("  LISTA 1  (" + lista1.Count + " datos - primera mitad)"); // Muestra tamaño y etiqueta.
Console.WriteLine("  --------------------------------"); // Separador.
for (int i = 0; i < lista1.Count; i++) // Recorre la lista 1 para mostrar sus datos.
{
    Console.WriteLine("    Lista 1 [" + (i + 1) + "] = " + lista1[i]); // Imprime el elemento i+1 de lista1.
}
Console.WriteLine(); // Línea en blanco.

Console.WriteLine("  LISTA 2  (" + lista2.Count + " datos - segunda mitad)"); // Muestra tamaño y etiqueta.
Console.WriteLine("  --------------------------------"); // Separador.
for (int i = 0; i < lista2.Count; i++) // Recorre la lista 2 para mostrar sus datos.
{
    Console.WriteLine("    Lista 2 [" + (i + 1) + "] = " + lista2[i]); // Imprime el elemento i+1 de lista2.
}
Console.WriteLine(); // Línea en blanco.

HashSet<int> valoresUnicos = new HashSet<int>(); // Guarda valores únicos combinando ambas listas.
foreach (int n in lista1) // Recorre la lista 1.
{
    valoresUnicos.Add(n); // Agrega cada valor (HashSet evita duplicados).
}
foreach (int n in lista2) // Recorre la lista 2.
{
    valoresUnicos.Add(n); // Agrega y mantiene solo valores únicos.
}

Console.WriteLine("  Valores únicos "); // Encabezado de valores únicos.
Console.WriteLine("  --------------------------------"); // Separador.
foreach (int n in valoresUnicos) // Recorre el HashSet para imprimir los únicos.
{
    Console.WriteLine("    " + n); // Imprime cada valor único.
}
Console.WriteLine(); // Línea en blanco.

int cantidadRepetidos = 0; // Contará coincidencias entre lista1 y lista2.
for (int i = 0; i < lista1.Count; i++) // Recorre todos los elementos de la lista 1.
{
    for (int j = 0; j < lista2.Count; j++) // Compara con cada elemento de la lista 2.
    {
        if (lista1[i] == lista2[j]) // Si hay igualdad...
        {
            cantidadRepetidos++; // Incrementa el contador de repetidos.
        }
    }
}

Console.WriteLine("  Repeticiones entre ambas listas"); // Encabezado del total de repetidos.
Console.WriteLine("  --------------------------------"); // Separador.
Console.WriteLine("    Total: " + cantidadRepetidos); // Muestra cuántas coincidencias se encontraron.
Console.WriteLine(); // Línea en blanco final.
Console.WriteLine("========================================"); // Separador final.
