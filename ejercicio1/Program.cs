// See https://aka.ms/new-console-template for more information

using ejercicio1;

class Programa
{
    static void Main()
    {
        GestorVentas gestor = new GestorVentas("ventas.bin");

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nMenú de Ventas:");
            Console.WriteLine("1. Agregar Venta");
            Console.WriteLine("2. Consultar Ventas");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el ID del producto: ");
                    int idProducto = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la cantidad: ");
                    int cantidad = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el precio: ");
                    decimal precio = decimal.Parse(Console.ReadLine());

                    gestor.AgregarVenta(idProducto, cantidad, precio);
                    Console.WriteLine("Venta agregada con éxito.");
                    break;

                case "2":
                    gestor.ConsultarVentas();
                    break;

                case "3":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
