namespace Library;

public interface IAccionesBasicas<T>
{
    public T ObtenerElemento(int id);
    public List<T> ObtenerLista();
    public void Añadir(T elemento);
}

public interface IAccionesEdicion<T>
{
    public void Actualizar(T elemento);
    public void Eliminar(T elemento);
}

public class Usuario2
{
    public int Id {get ; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
}

public class Venta2
{
    public int Cantidad {get ; set; }
    public DateTime Fecha { get; set; }
}

public class UserService2: IAccionesBasicas<Usuario2>,  IAccionesEdicion<Usuario2>
{
    public Usuario2 ObtenerElemento(int id)
    {
        Console.WriteLine("Devolver usuario.");
        return new Usuario2();
    }
    public List<Usuario2> ObtenerLista()
    {
        Console.WriteLine("Devolver lista usuarios.");
        return new List<Usuario2>();
    }
    public void Añadir(Usuario2 elemento)
    {
        Console.WriteLine("Añadir usuario.");
    }
    public void Actualizar(Usuario2 elemento)
    {
        Console.WriteLine("Actualizar usuario.");
    }
    public void Eliminar(Usuario2 elemento)
    {
        Console.WriteLine("Eliminar usuario.");
    }

}

public class VentaService2 : IAccionesBasicas<Venta2>
{
    public Venta2 ObtenerElemento(int id)
    {
        Console.WriteLine("Devolver Venta.");
        return new Venta2();
    }
    public List<Venta2> ObtenerLista()
    {
        Console.WriteLine("Devolver lista Ventas.");
        return new List<Venta2>();
    }
    public void Añadir(Venta2 elemento)
    {
        Console.WriteLine("Añadir Venta.");
    }   

}