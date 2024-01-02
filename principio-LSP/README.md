# Principio LSP: El Principio de sustitucion de Liskov

## ¿Qué significa LSP?
> LSP, o el Principio de Sustitución de Liskov, establece que los objetos de una clase base deben poder ser reemplazados por objetos de una clase derivada sin afectar la corrección del programa. En otras palabras, si una clase base tiene ciertos comportamientos esperados, sus clases derivadas deben ser capaces de heredar y extender esos comportamientos sin cambiar su esencia.


## Ejemplo

En el ejemplo inicial, no se cumple con el Principio de Sustitución de Liskov. La clase derivada Triangle modifica el comportamiento del método virtual GetSides() de la clase base Rectangle. Esto genera un problema cuando se crea una instancia de Triangle y se asigna a una variable de tipo Rectangle. Al hacerlo, se asume que se puede utilizar esa instancia de la misma manera que si fuera una instancia de Rectangle, lo cual no es correcto en este caso. El método GetSides() de la clase Triangle devuelve "3", mientras que la clase Rectangle debería devolver "4".

~~~
public class Rectangle
{
    public virtual string GetSides()
    {
        return "4";
    }
}

public class Triangle : Rectangle
{
    public override string GetSides()
    {
        return "3";
    }
}

Rectangle rectangle = new Triangle();
Console.WriteLine(rectangle.GetSides()); // Muestra "3", debería mostrar "4"
~~~

En el siguiente ejemplo corregido, se utiliza una interfaz IShape que define un método GetSides(). Tanto la clase Rectangle como la clase Triangle implementan esta interfaz y proporcionan su propia implementación para el método GetSides(). Ahora, se puede utilizar la misma variable shape para hacer referencia a diferentes instancias de clases que implementan la interfaz IShape, demostrando que todas las clases que implementan IShape tienen el mismo comportamiento para el método GetSides(). De esta manera, se cumple el Principio de Sustitución de Liskov.

~~~
public interface IShape
{
    string GetSides();
}

public class Rectangle : IShape
{
    public string GetSides()
    {
        return "4";
    }
}

public class Triangle : IShape
{
    public string GetSides()
    {
        return "3";
    }
}

IShape shape = new Triangle();
Console.WriteLine(shape.GetSides()); // Muestra "3"
shape = new Rectangle();
Console.WriteLine(shape.GetSides()); // Muestra "4"
~~~
