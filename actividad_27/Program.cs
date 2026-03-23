class Program
{
    static void Main()
    {
        HashSet<string> codigosEstudiantes = new HashSet<string>();

        for (int i = 0; i < 10; i++)
        {
            Console.Clear();

            string codigo = "";
            while (true)
            {
                Console.Write("Ingrese el código del estudiante (" + (i + 1) + " de 10):");
                codigo = (Console.ReadLine() ?? "").Trim();

                if (codigo == "")
                {
                    Console.Clear();
                    Console.WriteLine("Debe ingresar un código. No puede dejar el campo vacío.");
                    continue;
                }

                break;
            }

            if (codigosEstudiantes.Contains(codigo))
            {
                Console.WriteLine("Ese código ya fue registrado.");
            }
            else
            {
                codigosEstudiantes.Add(codigo);
            }
        }

        Console.Clear();
        Console.WriteLine("¿Desea ver todos los códigos agregados? (s/n):");
        string opcion = Console.ReadLine() ?? "";

        if (opcion == "s" || opcion == "S")
        {
            Console.Clear();
            Console.WriteLine("======Códigos agregados:==========");
            foreach (string c in codigosEstudiantes)
            {
                Console.WriteLine(c);
            }
        }
    }
}
