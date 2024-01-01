namespace Library;


public abstract class AbstractVenta
{
    protected decimal Monto;
    protected string Cliente;
    protected decimal Impuestos;
    public abstract void Generar();
    public abstract void CalcularImpuestos();
   
}

public class Venta : AbstractVenta
{
    public Venta(decimal monto, string cliente, decimal impuestos)
    {
        this.Impuestos = impuestos;
        this.Monto = monto;
        this.Cliente = cliente;
    }

    public override void CalcularImpuestos()
    {
        Console.WriteLine("Se calculan los impuestos.");
    }

    public override void Generar()
    {
        Console.WriteLine("Se genero la venta.");
    }

}

public class VentaExtrangero : AbstractVenta
{
    public VentaExtrangero(decimal monto, string cliente)
    {
        this.Impuestos = 0; // Sobra
        this.Monto = monto;
        this.Cliente = cliente;
    }

    public override void CalcularImpuestos() // Sobra
    {
        throw new NotImplementedException();
    }

    public override void Generar()
    {
        Console.WriteLine("Se genero la venta.");
    }

}



    

