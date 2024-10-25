namespace ejercicio3;



/// <summary>
/// Struct que representa un libro.
/// </summary>
struct Libro
{
    public string Titulo; // Título del libro
    public string Autor; // Autor del libro
    public int AnioPublicacion; // Año de publicación del libro
    public decimal Precio; // Precio del libro

    // Método para guardar el libro en un archivo binario
    public void Guardar(BinaryWriter escritor)
    {
        escritor.Write(Titulo);
        escritor.Write(Autor);
        escritor.Write(AnioPublicacion);
        escritor.Write(Precio);
    }

    // Método para leer un libro desde un archivo binario
    public static Libro Leer(BinaryReader lector)
    {
        Libro libro = new Libro
        {
            Titulo = lector.ReadString(),
            Autor = lector.ReadString(),
            AnioPublicacion = lector.ReadInt32(),
            Precio = lector.ReadDecimal()
        };
        return libro;
    }
}
