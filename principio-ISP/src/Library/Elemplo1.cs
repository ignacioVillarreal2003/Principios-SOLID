namespace Library;


public interface ICrud<T>
{
    public T ObtenerElemento(int id);
    public List<T> ObtenerLista();
    public void Añadir(T elemento);
    public void Actualizar(T elemento);
    public void Eliminar(T elemento);
}

public class Usuario
{
    public int Id {get ; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
}

public class Venta
{
    public int Cantidad {get ; set; }
    public DateTime Fecha { get; set; }
}

public class UserService: ICrud<Usuario>
{
    public Usuario ObtenerElemento(int id)
    {
        Console.WriteLine("Devolver usuario.");
        return new Usuario();
    }
    public List<Usuario> ObtenerLista()
    {
        Console.WriteLine("Devolver lista usuarios.");
        return new List<Usuario>();
    }
    public void Añadir(Usuario elemento)
    {
        Console.WriteLine("Añadir usuario.");
    }
    public void Actualizar(Usuario elemento)
    {
        Console.WriteLine("Actualizar usuario.");
    }
    public void Eliminar(Usuario elemento)
    {
        Console.WriteLine("Eliminar usuario.");
    }

}

public class VentaService : ICrud<Venta>
{
    public Venta ObtenerElemento(int id)
    {
        Console.WriteLine("Devolver Venta.");
        return new Venta();
    }
    public List<Venta> ObtenerLista()
    {
        Console.WriteLine("Devolver lista Ventas.");
        return new List<Venta>();
    }
    public void Añadir(Venta elemento)
    {
        Console.WriteLine("Añadir Venta.");
    }   

    public void Actualizar(Venta elemento)
    {
        throw new NotImplementedException();
    }
    public void Eliminar(Venta elemento)
    {
        throw new NotImplementedException();
    }
}

    

