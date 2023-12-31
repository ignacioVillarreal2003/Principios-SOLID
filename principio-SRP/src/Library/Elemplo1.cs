namespace Library;

public class Refresco
{
    public string Nombre { get; set; }

    public string Marca { get; set; }

    public bool Alcohol { get; set; }

    public Refresco(string nombre, string marca, bool alcohol)
    {
        this.Nombre = nombre;
        this.Marca = marca;
        this.Alcohol = alcohol;
    }

    public void guardarEnBaseDatos()
    {
        Console.WriteLine($"Guardando en la base {Nombre}");
    }

    public void enviar()
    {
        Console.WriteLine($"Enviamos el refresco {Nombre}");
    }

    public void validar()
    {
        Console.WriteLine($"Validando el refresco {Nombre}");
    }
}



    

