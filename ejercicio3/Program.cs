using ejercicio3;

/// <summary>
/// Clase principal que gestiona la interacción con el usuario.
/// </summary>
class Programa
{
    static void Main()
    {
        GestorLibros gestor = new GestorLibros("libros.bin"); // Crea el gestor con el archivo

        // Muestra las opciones al usuario
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Agregar nuevo libro");
            Console.WriteLine("2. Listar todos los libros");
            Console.WriteLine("3. Buscar un libro por título");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            // Procesa la opción seleccionada
            switch (opcion)
            {
                case "1":
                    AgregarNuevoLibro(gestor); // Llama a la función para agregar un nuevo libro
                    break;

                case "2":
                    ListarTodosLosLibros(gestor); // Llama a la función para listar todos los libros
                    break;

                case "3":
                    BuscarLibroPorTitulo(gestor); // Llama a la función para buscar un libro por título
                    break;

                case "4":
                    continuar = false; // Termina el ciclo
                    break;

                default:
                    Console.WriteLine("Opción no válida."); // Mensaje de error para opción no válida
                    break;
            }
        }
    }

    // Permite al usuario agregar un nuevo libro
    static void AgregarNuevoLibro(GestorLibros gestor)
    {
        Console.Write("Ingrese el título del libro: ");
        string titulo = Console.ReadLine();

        Console.Write("Ingrese el autor del libro: ");
        string autor = Console.ReadLine();

        Console.Write("Ingrese el año de publicación: ");
        int anioPublicacion = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el precio del libro: ");
        decimal precio = decimal.Parse(Console.ReadLine());

        Libro nuevoLibro = new Libro
        {
            Titulo = titulo,
            Autor = autor,
            AnioPublicacion = anioPublicacion,
            Precio = precio
        };

        gestor.AgregarLibro(nuevoLibro); // Agrega el libro al archivo
        Console.WriteLine("Libro agregado con éxito.");
    }

    // Muestra todos los libros almacenados en el archivo
    static void ListarTodosLosLibros(GestorLibros gestor)
    {
        var libros = gestor.ListarLibros(); // Obtiene la lista de libros
        if (libros.Length > 0)
        {
            Console.WriteLine("Libros almacenados:");
            foreach (var libro in libros)
            {
                Console.WriteLine($"Título: {libro.Titulo}, Autor: {libro.Autor}, Año: {libro.AnioPublicacion}, Precio: {libro.Precio:C}"); // Muestra cada libro
            }
        }
        else
        {
            Console.WriteLine("No hay libros registrados."); // Mensaje si no hay libros
        }
    }

    // Permite al usuario buscar un libro por título
    static void BuscarLibroPorTitulo(GestorLibros gestor)
    {
        Console.Write("Ingrese el título del libro a buscar: ");
        string titulo = Console.ReadLine();

        Libro? libroEncontrado = gestor.BuscarLibro(titulo); // Busca el libro

        // Verifica si se encontró el libro
        if (libroEncontrado != null)
        {
            Console.WriteLine($"Libro encontrado: Título: {libroEncontrado.Value.Titulo}, Autor: {libroEncontrado.Value.Autor}, Año: {libroEncontrado.Value.AnioPublicacion}, Precio: {libroEncontrado.Value.Precio:C}");
        }
        else
        {
            Console.WriteLine("Libro no encontrado."); // Mensaje si no se encuentra el libro
        }
    }
}
