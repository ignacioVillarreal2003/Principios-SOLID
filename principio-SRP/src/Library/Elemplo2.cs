namespace Library;

public class Refresco2
{
    public string Nombre { get; set; }

    public string Marca { get; set; }

    public bool Alcohol { get; set; }

    public Refresco2(string nombre, string marca, bool alcohol)
    {
        this.Nombre = nombre;
        this.Marca = marca;
        this.Alcohol = alcohol;
    }

}

public class RefrescoBaseDatos
{
    private Refresco2 Refresco;
    public RefrescoBaseDatos(Refresco2 refresco)
    {
        this.Refresco = refresco;
    }

    public void guardarEnBaseDatos()
    {
        Console.WriteLine($"Guardando en la base {this.Refresco.Nombre}");
    }
}

public class RefrescoPeticion
{
    private Refresco2 Refresco;
    public RefrescoPeticion(Refresco2 refresco)
    {
        this.Refresco = refresco;
    }

    public void enviar()
    {
        Console.WriteLine($"Enviamos el refresco {this.Refresco.Nombre}");
    }
}


public class RefrescoValidacion
{
    private Refresco2 Refresco;
    public RefrescoValidacion(Refresco2 refresco)
    {
        this.Refresco = refresco;
    }

    public void validar()
    {
        Console.WriteLine($"Validando el refresco {this.Refresco.Nombre}");
    }
}
