using System;

class Program
{
    static void LimpiarConsola()
    {
        try
        {
            Console.Clear();
        }
        catch
        {
        }
    }

    static void Main()
    {
        int cantidad = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            LimpiarConsola();
            Console.WriteLine("================================================================");
            Console.WriteLine("Actividad 5: Verificar si existe un subconjunto con suma dada");
            Console.WriteLine("====================================================================");
            Console.WriteLine();
            Console.Write("Ingrese la cantidad de numeros enteros positivos: ");

            string textoCantidad = Console.ReadLine() ?? "";

            if (int.TryParse(textoCantidad, out cantidad) && cantidad > 0)
            {
                entradaValida = true;
            }
        }

        int[] numeros = new int[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            bool numeroValido = false;

            while (!numeroValido)
            {
                LimpiarConsola();
                Console.WriteLine("===================");
                Console.WriteLine("Ingreso de numeros");
                Console.WriteLine("=======================");
                Console.WriteLine();
                Console.Write("Ingrese el numero " + (i + 1) + ": ");

                string textoNumero = Console.ReadLine() ?? "";
                int numero = 0;

                if (int.TryParse(textoNumero, out numero) && numero > 0)
                {
                    numeros[i] = numero;
                    numeroValido = true;
                }
            }
        }

        int objetivo = 0;
        bool objetivoValido = false;

        while (!objetivoValido)
        {
            LimpiarConsola();
            Console.WriteLine("=====================");
            Console.WriteLine("Ingreso del objetivo");
            Console.WriteLine("========================");
            Console.WriteLine();
            Console.Write("Ingrese la suma objetivo: ");

            string textoObjetivo = Console.ReadLine() ?? "";

            if (int.TryParse(textoObjetivo, out objetivo) && objetivo >= 0)
            {
                objetivoValido = true;
            }
        }

        int[] seleccion = new int[cantidad];
        bool existe = ExisteSuma(numeros, objetivo, cantidad - 1);

        if (existe)
        {
            bool encontrado = false;
            bool fin = false;

            while (!fin && !encontrado)
            {
                int suma = 0;

                for (int i = 0; i < cantidad; i++)
                {
                    if (seleccion[i] == 1)
                    {
                        suma = suma + numeros[i];
                    }
                }

                if (suma == objetivo)
                {
                    encontrado = true;
                }
                else
                {
                    int posicion = 0;

                    while (posicion < cantidad && seleccion[posicion] == 1)
                    {
                        seleccion[posicion] = 0;
                        posicion++;
                    }

                    if (posicion == cantidad)
                    {
                        fin = true;
                    }
                    else
                    {
                        seleccion[posicion] = 1;
                    }
                }
            }
        }

        LimpiarConsola();
        Console.WriteLine(existe);

        if (existe)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Numeros que forman el objetivo: ");
            Console.WriteLine("====================================");
            bool primero = true;

            for (int i = 0; i < cantidad; i++)
            {
                if (seleccion[i] == 1)
                {
                    if (!primero)
                    {
                        Console.Write(" + ");
                    }

                    Console.Write(numeros[i]);
                    primero = false;
                }
            }

            Console.WriteLine();
        }
    }

    static bool ExisteSuma(int[] numeros, int objetivo, int indice)
    {
        if (objetivo == 0)
        {
            return true;
        }

        if (indice < 0 || objetivo < 0)
        {
            return false;
        }

        bool incluir = ExisteSuma(numeros, objetivo - numeros[indice], indice - 1);
        bool noIncluir = ExisteSuma(numeros, objetivo, indice - 1);

        return incluir || noIncluir;
    }
}
