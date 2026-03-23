Console.Clear(); // Limpia la consola al iniciar.
Console.Write("Ingrese una cadena de texto:"); // Pide al usuario el texto.
string textoOriginal = Console.ReadLine() ?? ""; // Lee el texto; si viene null, usa cadena vacia.

string textoMinuscula = textoOriginal.ToLower(); // Crea una copia del texto en minuscula.

char[] caracteres = new char[textoMinuscula.Length]; // Guarda cada caracter unico encontrado.
int[] veces = new int[textoMinuscula.Length]; // Guarda cuantas veces aparece cada caracter.
int totalCaracteresUnicos = 0; // Lleva la cantidad de caracteres diferentes.

for (int i = 0; i < textoMinuscula.Length; i++) // Recorre cada caracter del texto.
{
    char caracterActual = textoMinuscula[i]; // Toma el caracter actual del recorrido.

    if (caracterActual == 'á') // Si es a con tilde.
    {
        caracterActual = 'a'; // Lo cambia por a sin tilde.
    }
    else if (caracterActual == 'é') // Si es e con tilde.
    {
        caracterActual = 'e'; // Lo cambia por e sin tilde.
    }
    else if (caracterActual == 'í') // Si es i con tilde.
    {
        caracterActual = 'i'; // Lo cambia por i sin tilde.
    }
    else if (caracterActual == 'ó') // Si es o con tilde.
    {
        caracterActual = 'o'; // Lo cambia por o sin tilde.
    }
    else if (caracterActual == 'ú' || caracterActual == 'ü') // Si es u con tilde o dieresis.
    {
        caracterActual = 'u'; // Lo cambia por u sin acento.
    }

    bool esLetraONumero = (caracterActual >= 'a' && caracterActual <= 'z') || (caracterActual >= '0' && caracterActual <= '9'); // Valida si es letra o numero.

    if (esLetraONumero) // Solo continua si el caracter es alfanumerico.
    {
        bool encontrado = false; // Marca para saber si el caracter ya estaba guardado.

        for (int j = 0; j < totalCaracteresUnicos; j++) // Revisa los caracteres guardados hasta ahora.
        {
            if (caracteres[j] == caracterActual) // Si ya existe ese caracter.
            {
                veces[j] = veces[j] + 1; // Suma 1 al contador de ese caracter.
                encontrado = true; // Marca que ya fue encontrado.
            }
        }

        if (!encontrado) // Si no existia aun.
        {
            caracteres[totalCaracteresUnicos] = caracterActual; // Guarda el nuevo caracter.
            veces[totalCaracteresUnicos] = 1; // Inicia su contador en 1.
            totalCaracteresUnicos = totalCaracteresUnicos + 1; // Aumenta la cantidad de unicos.
        }
    }
}

for (int i = 0; i < totalCaracteresUnicos - 1; i++) // Primer ciclo de ordenamiento burbuja.
{
    for (int j = 0; j < totalCaracteresUnicos - 1 - i; j++) // Segundo ciclo para comparar pares.
    {
        if (caracteres[j] > caracteres[j + 1]) // Si estan en orden incorrecto.
        {
            char temporalCar = caracteres[j]; // Guarda temporalmente el caracter actual.
            caracteres[j] = caracteres[j + 1]; // Mueve el siguiente caracter a la posicion actual.
            caracteres[j + 1] = temporalCar; // Coloca el caracter temporal en su nueva posicion.

            int temporalVeces = veces[j]; // Guarda temporalmente su cantidad.
            veces[j] = veces[j + 1]; // Mueve la cantidad del siguiente.
            veces[j + 1] = temporalVeces; // Coloca la cantidad temporal en su nueva posicion.
        }
    }
}

Console.Clear(); // Limpia consola antes de mostrar resultado.
for (int i = 0; i < totalCaracteresUnicos; i++) // Recorre los resultados finales.
{
    Console.WriteLine("Car: " + caracteres[i] + " - Veces:" + veces[i]); // Imprime caracter y cantidad.
}
