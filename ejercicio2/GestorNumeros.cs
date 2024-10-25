namespace ejercicio2;

struct GestorNumeros
{
    private string nombreArchivo; // Nombre del archivo binario donde se guardan los números

    // Constructor que inicializa el gestor con el nombre del archivo
    public GestorNumeros(string archivo)
    {
        nombreArchivo = archivo;
    }

    // Guarda un número en el archivo binario
    public void GuardarNumero(int numero)
    {
        // Abre el archivo en modo de añadir y escribe el número
        using (BinaryWriter escritor = new BinaryWriter(File.Open(nombreArchivo, FileMode.Append)))
        {
            escritor.Write(numero);
        }
    }

    // Lee todos los números del archivo binario y los devuelve como un arreglo
    public int[] LeerNumeros()
    {
        if (File.Exists(nombreArchivo))
        {
            // Lee los números desde el archivo y los almacena en una lista
            using (BinaryReader lector = new BinaryReader(File.Open(nombreArchivo, FileMode.Open)))
            {
                var numeros = new System.Collections.Generic.List<int>();
                while (lector.BaseStream.Position != lector.BaseStream.Length)
                {
                    numeros.Add(lector.ReadInt32());
                }
                return numeros.ToArray(); // Devuelve el arreglo de números
            }
        }
            // Si el archivo no existe, retorna un arreglo vacío
            return Array.Empty<int>();
    }
}