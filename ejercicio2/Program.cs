using ejercicio2;

class Programa
{
    static void Main()
    {
        GestorNumeros gestor = new GestorNumeros("numeros.bin"); // Crea el gestor con el archivo

        // Solicitar números al usuario
        Console.WriteLine("Ingrese números enteros positivos en el rango de 50 a 100 (0 para finalizar):");
        while (true)
        {
            // Lee el número ingresado por el usuario
            int numero = int.Parse(Console.ReadLine());

            // Termina el ciclo si se ingresa 0
            if (numero == 0) break;

            // Valida que el número esté en el rango permitido
            if (numero >= 50 && numero <= 100)
            {
                gestor.GuardarNumero(numero); // Guarda el número si es válido
                Console.WriteLine("Número guardado.");
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número entre 50 y 100.");
            }
        }

        // Muestra las opciones al usuario
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Mostrar todos los números");
            Console.WriteLine("2. Mostrar número mayor");
            Console.WriteLine("3. Mostrar número menor");
            Console.WriteLine("4. Mostrar promedio");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            // Procesa la opción seleccionada
            switch (opcion)
            {
                case "1":
                    MostrarTodosLosNumeros(gestor); // Llama a la función para mostrar todos los números
                    break;

                case "2":
                    MostrarNumeroMayor(gestor); // Llama a la función para mostrar el número mayor
                    break;

                case "3":
                    MostrarNumeroMenor(gestor); // Llama a la función para mostrar el número menor
                    break;

                case "4":
                    MostrarPromedio(gestor); // Llama a la función para mostrar el promedio
                    break;

                case "5":
                    continuar = false; // Termina el ciclo
                    break;

                default:
                    Console.WriteLine("Opción no válida."); // Mensaje de error para opción no válida
                    break;
            }
        }
    }

    // Muestra todos los números almacenados en el archivo
    static void MostrarTodosLosNumeros(GestorNumeros gestor)
    {
        int[] numeros = gestor.LeerNumeros(); // Lee los números desde el archivo
        if (numeros.Length > 0)
        {
            Console.WriteLine("Todos los números:");
            foreach (var numero in numeros)
            {
                Console.WriteLine(numero); // Muestra cada número
            }
        }
        else
        {
            Console.WriteLine("No hay números registrados."); // Mensaje si no hay números
        }
    }

    // Muestra el número mayor almacenado en el archivo
    static void MostrarNumeroMayor(GestorNumeros gestor)
    {
        int[] numeros = gestor.LeerNumeros(); // Lee los números desde el archivo
        if (numeros.Length > 0)
        {
            int numeroMayor = 0; // Inicializa el número mayor
            foreach (var numero in numeros)
            {
                if (numero > numeroMayor)
                    numeroMayor = numero; // Actualiza el número mayor
            }
            Console.WriteLine($"Número mayor: {numeroMayor}"); // Muestra el número mayor
        }
        else
        {
            Console.WriteLine("No hay números registrados."); // Mensaje si no hay números
        }
    }

    // Muestra el número menor almacenado en el archivo
    static void MostrarNumeroMenor(GestorNumeros gestor)
    {
        int[] numeros = gestor.LeerNumeros(); // Lee los números desde el archivo
        if (numeros.Length > 0)
        {
            int numeroMenor = 101; // Inicializa el número menor
            foreach (var numero in numeros)
            {
                if (numero < numeroMenor)
                    numeroMenor = numero; // Actualiza el número menor
            }
            Console.WriteLine($"Número menor: {numeroMenor}"); // Muestra el número menor
        }
        else
        {
            Console.WriteLine("No hay números registrados."); // Mensaje si no hay números
        }
    }

    // Muestra el promedio de los números almacenados en el archivo
    static void MostrarPromedio(GestorNumeros gestor)
    {
        int[] numeros = gestor.LeerNumeros(); // Lee los números desde el archivo
        if (numeros.Length > 0)
        {
            decimal suma = 0; // Inicializa la suma
            foreach (var numero in numeros)
            {
                suma += numero; // Acumula la suma de los números
            }
            decimal promedio = suma / numeros.Length; // Calcula el promedio
            Console.WriteLine($"Promedio: {promedio:F2}"); // Muestra el promedio
        }
        else
        {
            Console.WriteLine("No hay números registrados."); // Mensaje si no hay números
        }
    }
}
