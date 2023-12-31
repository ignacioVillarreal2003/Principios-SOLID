namespace Library;

public class Bebidas
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public decimal Precio { get; set; }
   
}

public class Factura
{
    public decimal ObtenerTotal(IEnumerable<Bebidas> listaBebidas)
    {
        decimal total = 0;
        foreach (var bebida in listaBebidas)
        {
            if (bebida.Tipo == "Agua")
            {
                total += bebida.Precio;
            }
            else if (bebida.Tipo == "Cola")
            {
                total += bebida.Precio * 0.33m;
            }
            else if (bebida.Tipo == "Alcohol")
            {
                total += bebida.Precio * 0.71m;
            }
        }
        return total;
    }
}




    

