namespace ejercicio3;

/// <summary>
/// Struct que gestiona la entrada y salida de libros en un archivo binario.
/// </summary>
struct GestorLibros
{
    private string nombreArchivo; // Nombre del archivo binario donde se guardan los libros

    // Constructor que inicializa el gestor con el nombre del archivo
    public GestorLibros(string archivo)
    {
        nombreArchivo = archivo;
    }

    // Agrega un libro al archivo binario
    public void AgregarLibro(Libro libro)
    {
        using (BinaryWriter escritor = new BinaryWriter(File.Open(nombreArchivo, FileMode.Append)))
        {
            libro.Guardar(escritor); // Llama al método de guardar del struct Libro
        }
    }

    // Lista todos los libros almacenados en el archivo binario
    public Libro[] ListarLibros()
    {
        if (File.Exists(nombreArchivo))
        {
            using (BinaryReader lector = new BinaryReader(File.Open(nombreArchivo, FileMode.Open)))
            {
                var libros = new System.Collections.Generic.List<Libro>();
                while (lector.BaseStream.Position != lector.BaseStream.Length)
                {
                    libros.Add(Libro.Leer(lector)); // Llama al método de leer del struct Libro
                }
                return libros.ToArray(); // Devuelve el arreglo de libros
            }
        }
        else
        {
            return Array.Empty<Libro>(); // Retorna un arreglo vacío si el archivo no existe
        }
    }

    // Busca un libro por título y devuelve el libro encontrado o null si no se encuentra
    public Libro? BuscarLibro(string titulo)
    {
        var libros = ListarLibros(); // Obtiene la lista de libros
        foreach (var libro in libros)
        {
            if (libro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase)) // Compara el título sin distinguir mayúsculas
            {
                return libro; // Retorna el libro encontrado
            }
        }
        return null; // Retorna null si no se encuentra el libro
    }
}
