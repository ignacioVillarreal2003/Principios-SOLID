namespace Library;


public abstract class AbstractVenta2
{
    protected decimal Monto;
    protected string Cliente;
    public abstract void Generar();   
}

public abstract class VentasConImpuestos: AbstractVenta2
{
    protected decimal Impuestos;
    public abstract void CalcularImpuestos();
   
}

public class Venta2 : VentasConImpuestos
{
    public Venta2(decimal monto, string cliente, decimal impuestos)
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

public class VentaExtrangero2 : AbstractVenta2
{
    public VentaExtrangero2(decimal monto, string cliente)
    {
        this.Monto = monto;
        this.Cliente = cliente;
    }

    public override void Generar()
    {
        Console.WriteLine("Se genero la venta.");
    }
}

public class VentaExtrangeroConBoleta : AbstractVenta2
{
    public VentaExtrangeroConBoleta(decimal monto, string cliente)
    {
        this.Monto = monto;
        this.Cliente = cliente;
    }

    public override void Generar()
    {
        Console.WriteLine("Se genero la venta.");
    }

    public void GenerarBoleta()
    {
        Console.WriteLine("Se genero una boleta.");
    }
}