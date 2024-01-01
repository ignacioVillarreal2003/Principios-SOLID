using Library;

namespace Solid_Single_Responsability
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractVenta venta1 = new Venta(100, "venta1", 50);
            venta1.CalcularImpuestos();
            venta1.Generar();
            venta1 = new VentaExtrangero(100, "venta1");
            venta1.CalcularImpuestos(); // Error
            venta1.Generar();


            VentasConImpuestos venta2 = new Venta2(100, "venta1", 50);
            venta2.CalcularImpuestos();
            venta2.Generar();
            AbstractVenta2 venta3 = new VentaExtrangero2(100, "venta1");
            venta3.Generar();
            venta3 = new VentaExtrangeroConBoleta(100, "venta1");
            venta3.Generar();
        }
    }
}
