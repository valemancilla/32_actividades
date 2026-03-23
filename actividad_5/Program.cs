using System;

class Program
{
    // Metodo para limpiar la consola sin romper el programa en entornos donde no se pueda limpiar.
    static void LimpiarConsola()
    {
        // Se intenta limpiar la consola.
        try
        {
            Console.Clear();
        }
        // Si falla, se ignora para continuar la ejecucion.
        catch
        {
        }
    }

    // Punto de entrada del programa.
    static void Main()
    {
        // Guarda la cantidad de numeros que ingresara el usuario.
        int cantidad = 0;
        // Controla si la cantidad ingresada es valida.
        bool entradaValida = false;

        // Repite hasta que el usuario ingrese una cantidad valida mayor que 0.
        while (!entradaValida)
        {
            // Limpia la consola antes de pedir datos.
            LimpiarConsola();
            Console.WriteLine("================================================================");
            Console.WriteLine("Actividad 5: Verificar si existe un subconjunto con suma dada");
            Console.WriteLine("====================================================================");
            Console.WriteLine();
            Console.Write("Ingrese la cantidad de numeros enteros positivos: ");

            // Lee la cantidad como texto.
            string textoCantidad = Console.ReadLine() ?? "";

            // Convierte el texto a entero y valida que sea mayor que 0.
            if (int.TryParse(textoCantidad, out cantidad) && cantidad > 0)
            {
                // Marca la entrada como valida para salir del ciclo.
                entradaValida = true;
            }
        }

        // Arreglo donde se guardan los numeros ingresados.
        int[] numeros = new int[cantidad];

        // Recorre las posiciones del arreglo para pedir cada numero.
        for (int i = 0; i < cantidad; i++)
        {
            // Controla si el numero actual fue ingresado correctamente.
            bool numeroValido = false;

            // Repite hasta que el numero actual sea valido y positivo.
            while (!numeroValido)
            {
                // Limpia la consola antes de pedir el numero.
                LimpiarConsola();
                Console.WriteLine("===================");
                Console.WriteLine("Ingreso de numeros");
                Console.WriteLine("=======================");
                Console.WriteLine();
                Console.Write("Ingrese el numero " + (i + 1) + ": ");

                // Lee el numero actual como texto.
                string textoNumero = Console.ReadLine() ?? "";
                // Variable temporal para convertir el numero.
                int numero = 0;

                // Convierte y valida que el numero sea positivo.
                if (int.TryParse(textoNumero, out numero) && numero > 0)
                {
                    // Guarda el numero en la posicion correspondiente.
                    numeros[i] = numero;
                    // Marca como valido para salir del ciclo.
                    numeroValido = true;
                }
            }
        }

        // Guarda la suma objetivo.
        int objetivo = 0;
        // Controla si el objetivo ingresado es valido.
        bool objetivoValido = false;

        // Repite hasta que el usuario ingrese un objetivo valido.
        while (!objetivoValido)
        {
            // Limpia la consola antes de pedir el objetivo.
            LimpiarConsola();
            Console.WriteLine("=====================");
            Console.WriteLine("Ingreso del objetivo");
            Console.WriteLine("========================");
            Console.WriteLine();
            Console.Write("Ingrese la suma objetivo: ");

            // Lee el objetivo como texto.
            string textoObjetivo = Console.ReadLine() ?? "";

            // Convierte el objetivo y valida que sea 0 o mayor.
            if (int.TryParse(textoObjetivo, out objetivo) && objetivo >= 0)
            {
                // Marca el objetivo como valido para salir del ciclo.
                objetivoValido = true;
            }
        }

        // Arreglo binario para representar subconjuntos (1 incluye, 0 no incluye).
        int[] seleccion = new int[cantidad];
        // Llama a la funcion recursiva que verifica si existe una suma posible.
        bool existe = ExisteSuma(numeros, objetivo, cantidad - 1);

        // Solo busca y guarda una combinacion concreta si existe solucion.
        if (existe)
        {
            // Indica si ya se encontro una combinacion que suma el objetivo.
            bool encontrado = false;
            // Indica que ya no quedan combinaciones por revisar.
            bool fin = false;

            // Recorre combinaciones hasta encontrar una o terminar.
            while (!fin && !encontrado)
            {
                // Acumula la suma del subconjunto actual.
                int suma = 0;

                // Suma los elementos marcados con 1 en seleccion.
                for (int i = 0; i < cantidad; i++)
                {
                    if (seleccion[i] == 1)
                    {
                        suma = suma + numeros[i];
                    }
                }

                // Si coincide con el objetivo, se detiene la busqueda.
                if (suma == objetivo)
                {
                    encontrado = true;
                }
                else
                {
                    // Simula un contador binario para pasar a la siguiente combinacion.
                    int posicion = 0;

                    // Cambia 1 por 0 mientras haya arrastre.
                    while (posicion < cantidad && seleccion[posicion] == 1)
                    {
                        seleccion[posicion] = 0;
                        posicion++;
                    }

                    // Si se paso del final, ya no hay mas combinaciones.
                    if (posicion == cantidad)
                    {
                        fin = true;
                    }
                    else
                    {
                        // Activa la siguiente posicion para continuar el conteo binario.
                        seleccion[posicion] = 1;
                    }
                }
            }
        }

        // Limpia la consola antes de mostrar el resultado final.
        LimpiarConsola();
        // Muestra true o false segun exista o no una solucion.
        Console.WriteLine(existe);

        // Si existe solucion, muestra los numeros del subconjunto encontrado.
        if (existe)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Numeros que forman el objetivo: ");
            Console.WriteLine("====================================");
            // Controla si es el primer numero para formatear el separador.
            bool primero = true;

            // Recorre el arreglo de seleccion para imprimir los numeros elegidos.
            for (int i = 0; i < cantidad; i++)
            {
                if (seleccion[i] == 1)
                {
                    // Agrega el separador entre numeros cuando no es el primero.
                    if (!primero)
                    {
                        Console.Write(" + ");
                    }

                    // Imprime el numero que forma parte del subconjunto.
                    Console.Write(numeros[i]);
                    // Marca que ya se imprimio el primer numero.
                    primero = false;
                }
            }

            // Salto de linea final.
            Console.WriteLine();
        }
    }

    // Funcion recursiva que verifica si existe un subconjunto con suma igual al objetivo.
    static bool ExisteSuma(int[] numeros, int objetivo, int indice)
    {
        // Caso base: si el objetivo llega a 0, se encontro una combinacion valida.
        if (objetivo == 0)
        {
            return true;
        }

        // Caso base: sin elementos o con objetivo negativo, no hay solucion en este camino.
        if (indice < 0 || objetivo < 0)
        {
            return false;
        }

        // Opcion 1: incluir el numero actual y restarlo del objetivo.
        bool incluir = ExisteSuma(numeros, objetivo - numeros[indice], indice - 1);
        // Opcion 2: no incluir el numero actual.
        bool noIncluir = ExisteSuma(numeros, objetivo, indice - 1);

        // Devuelve true si alguna opcion encuentra solucion.
        return incluir || noIncluir;
    }
}
