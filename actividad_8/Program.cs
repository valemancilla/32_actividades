class Program // Clase que contiene el programa
{
    static void Main() // Punto de entrada: aquí empieza la ejecución
    {
        Console.Clear(); // Limpia la pantalla antes del primer mensaje
        Console.WriteLine("Ingrese la primera palabra o texto:"); // Pide la primera cadena al usuario
        string primera = Console.ReadLine() ?? ""; // Lee texto; si es null, usa cadena vacía
        Console.Clear(); // Limpia antes de pedir la segunda palabra
        Console.WriteLine("Ingrese la segunda palabra o texto:"); // Pide la segunda cadena al usuario
        string segunda = Console.ReadLine() ?? ""; // Lee texto; si es null, usa cadena vacía

        bool resultado = EsAnagrama(primera, segunda); // Llama a la función y guarda true o false

        Console.Clear(); // Limpia antes de mostrar el resultado final
        Console.WriteLine("Primera palabra o texto: " + primera); // Muestra lo que escribió el usuario (1)
        Console.WriteLine("Segunda palabra o texto: " + segunda); // Muestra lo que escribió el usuario (2)
        Console.WriteLine("Son anagramas: " + resultado); // Muestra si son anagramas según la regla
    }

    static bool EsAnagrama(string primera, string segunda) // Devuelve true si una es anagrama de la otra
    {
        string copia1 = QuitarEspacios(primera); // Versión de la primera sin espacios (no altera el original)
        string copia2 = QuitarEspacios(segunda); // Versión de la segunda sin espacios

        if (copia1 == copia2) // Si son iguales tras quitar espacios, no son anagramas
        {
            return false; // Salir: mismas palabras exactas
        }

        if (copia1.Length != copia2.Length) // Si la cantidad de letras difiere, no pueden ser anagramas
        {
            return false; // Salir: longitudes distintas
        }

        for (int i = 0; i < copia1.Length; i++) // Recorre cada posición de la primera cadena
        {
            char letra = copia1[i]; // Letra actual que vamos a analizar

            bool esPrimeraVezQueAparece = true; // Asumimos que es la primera vez que vemos esta letra
            for (int j = 0; j < i; j++) // Revisa las posiciones anteriores en copia1
            {
                if (copia1[j] == letra) // Si la letra ya salió antes en copia1
                {
                    esPrimeraVezQueAparece = false; // No debemos contarla otra vez
                    break; // Sale del for j; ya sabemos que está repetida
                }
            }

            if (!esPrimeraVezQueAparece) // Si esta letra ya se procesó antes
            {
                continue; // Pasa a la siguiente i sin contar de nuevo
            }

            int vecesEnPrimera = 0; // Contador de cuántas veces aparece la letra en copia1
            for (int k = 0; k < copia1.Length; k++) // Recorre toda copia1
            {
                if (copia1[k] == letra) // Si en la posición k está la misma letra
                {
                    vecesEnPrimera++; // Suma una aparición en la primera cadena
                }
            }

            int vecesEnSegunda = 0; // Contador de la misma letra en copia2
            for (int k = 0; k < copia2.Length; k++) // Recorre toda copia2
            {
                if (copia2[k] == letra) // Si en la posición k está la misma letra
                {
                    vecesEnSegunda++; // Suma una aparición en la segunda cadena
                }
            }

            if (vecesEnPrimera != vecesEnSegunda) // Si las cantidades no coinciden
            {
                return false; // No son anagramas
            }
        }

        return true; // Todas las letras coincidieron en cantidad: son anagramas
    }

    static string QuitarEspacios(string texto) // Construye una cadena nueva sin caracteres espacio
    {
        string sinEspacios = ""; // Acumulador del resultado (empieza vacío)
        for (int i = 0; i < texto.Length; i++) // Recorre cada carácter del texto original
        {
            if (texto[i] != ' ') // Si no es un espacio en blanco
            {
                sinEspacios = sinEspacios + texto[i]; // Añade ese carácter al resultado
            }
        }
        return sinEspacios; // Devuelve el texto sin espacios
    }
}
