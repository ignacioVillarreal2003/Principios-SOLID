namespace Library;

public interface IBebida
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public decimal Impuesto { get; set; }
    public decimal ObtenerPrecio();
}

public class Agua : IBebida
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public decimal Impuesto { get; set; }
    public decimal ObtenerPrecio()
    {
        return Precio * Impuesto;
    }
}

public class Alcohol : IBebida
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Promo { get; set; }
    public decimal ObtenerPrecio()
    {
        return (Precio * Impuesto) - Promo;
    }
}

public class Cola : IBebida
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public decimal Impuesto { get; set; }
    public decimal ObtenerPrecio()
    {
        return Precio * Impuesto;
    }
}

public class Factura2
{
    public decimal ObtenerTotal(IEnumerable<IBebida> listaBebidas)
    {
        decimal total = 0;
        foreach (var bebida in listaBebidas)
        {
            total += bebida.ObtenerPrecio();
        }
        return total;
    }
}