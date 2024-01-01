# Principio Abierto-Cerrado
## ¿Qué es Abierto-Cerrado?
> El Principio Abierto-Cerrado es uno de los principios fundamentales en diseño de software que sugiere que una clase debe estar abierta para su extensión pero cerrada para su modificación. En otras palabras, deberíamos poder agregar nuevas funcionalidades o comportamientos a un sistema sin cambiar el código existente.

## Ejemplo
En el primer ejemplo, la clase Shape tiene un método para calcular el área, pero utiliza una estructura de control de flujo (if-else) para determinar el tipo de forma y calcular el área de manera diferente. Si queremos agregar una nueva forma, tendríamos que modificar el código de la clase Shape, lo cual va en contra del principio de abierto-cerrado.
~~~
class Shape
{
    public double Area()
    {
        if (this is Rectangle)
        {
            return (this as Rectangle).Width * (this as Rectangle).Height;
        }
        else if (this is Circle)
        {
            return 3.14 * (this as Circle).Radius * (this as Circle).Radius;
        }
    }
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
}

class Circle : Shape
{
    public double Radius { get; set; }
}
~~~

En el segundo ejemplo, la clase Shape es una clase abstracta que tiene un método abstracto para calcular el área. Las clases Rectangle y Circle heredan de Shape y proporcionan implementaciones específicas para calcular el área. Con esta estructura, podemos agregar nuevas formas (como un triángulo o un cuadrado) sin modificar el código de la clase Shape, cumpliendo con el principio de abierto-cerrado.

~~~
abstract class Shape
{
    public abstract double Area();
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double Area()
    {
        return Width * Height;
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public override double Area()
    {
        return 3.14 * Radius * Radius;
    }
}
~~~

