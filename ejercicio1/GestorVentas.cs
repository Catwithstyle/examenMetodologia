namespace ejercicio1;

struct GestorVentas
{
    private string archivoVentas;

    public GestorVentas(string archivo)
    {
        archivoVentas = archivo;
    }

    public void AgregarVenta(int idProducto, int cantidad, decimal precio)
    {
        Venta nuevaVenta = new Venta(idProducto, cantidad, precio);
        using (BinaryWriter escritor = new BinaryWriter(File.Open(archivoVentas, FileMode.Append)))
        {
            escritor.Write(nuevaVenta.ObtenerIdProducto());
            escritor.Write(nuevaVenta.ObtenerCantidad());
            escritor.Write(nuevaVenta.ObtenerPrecio());
        }
    }

    public void ConsultarVentas()
    {
        if (File.Exists(archivoVentas))
        {
            using (BinaryReader lector = new BinaryReader(File.Open(archivoVentas, FileMode.Open)))
            {
                decimal totalVentas = 0;
                decimal ventaMayor = decimal.MinValue;
                decimal ventaMenor = decimal.MaxValue;

                while (lector.BaseStream.Position != lector.BaseStream.Length)
                {
                    int idProducto = lector.ReadInt32();
                    int cantidad = lector.ReadInt32();
                    decimal precio = lector.ReadDecimal();
                    decimal totalVenta = cantidad * precio;

                    Console.WriteLine($"ID Producto: {idProducto}, Cantidad: {cantidad}, Precio: {precio:C}, Total Venta: {totalVenta:C}");

                    totalVentas += totalVenta;
                    if (totalVenta > ventaMayor) ventaMayor = totalVenta;
                    if (totalVenta < ventaMenor) ventaMenor = totalVenta;
                }

                Console.WriteLine($"\nTotal de Ventas: {totalVentas:C}");
                Console.WriteLine($"Venta más alta: {ventaMayor:C}");
                Console.WriteLine($"Venta más baja: {ventaMenor:C}");
            }
        }
        else
        {
            Console.WriteLine("No hay ventas registradas.");
        }
    }
}
