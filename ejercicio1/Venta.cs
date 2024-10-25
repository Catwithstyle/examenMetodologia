namespace ejercicio1;

struct Venta
{
    private int idProducto;
    private int cantidad;
    private decimal precio;

    public Venta(int idProducto, int cantidad, decimal precio)
    {
        this.idProducto = idProducto;
        this.cantidad = cantidad;
        this.precio = precio;
    }

    public int ObtenerIdProducto() => idProducto;
    public int ObtenerCantidad() => cantidad;
    public decimal ObtenerPrecio() => precio;

    public decimal CalcularTotal() => cantidad * precio;
}
