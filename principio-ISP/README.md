# Principio ISP: El Principio de Segregacion de Interfaces
## ¿Qué significa ISP?
> ISP, o Principio de Segregación de Interfaces, es un principio de diseño de software que sugiere que una interfaz debe ser específica y contener solo los métodos necesarios para sus implementadores. En lugar de tener interfaces genéricas con múltiples funciones, se prefieren interfaces más pequeñas y específicas que se ajusten a las necesidades de las clases individuales.

## Ejemplo

En este caso, se presenta un ejemplo que ilustra una violación del Principio ISP. La interfaz inicial, llamada IAnimal, incluye métodos para comer, dormir, nadar y volar. Sin embargo, esto resulta problemático, ya que no todos los animales pueden realizar todas estas acciones. En particular, la clase Fish implementa la interfaz, pero se ve obligada a proporcionar una implementación inútil o lanzar una excepción para el método Fly(), ya que los peces no pueden volar.

~~~
interface IAnimal
{
    void Eat();
    void Sleep();
    void Swim();
    void Fly();
}

class Fish : IAnimals
{
    public void Eat() { /* Código para comer */ }
    public void Sleep() { /* Código para dormir */ }
    public void Swim() { /* Código para nadar */ }
    public void Fly() { throw new NotImplementedException(); }
}
~~~

Para resolver este problema, se aplica el Principio ISP creando interfaces más específicas para cada acción que un animal puede realizar: IEat, ISleep, ISwim, IFly. En este nuevo diseño, las clases solo implementan las interfaces que son relevantes para sus capacidades, evitando así la necesidad de proporcionar implementaciones inútiles.

~~~
interface IEat
{
    void Eat();
}

interface ISleep
{
    void Sleep();
}

interface ISwim
{
    void Swim();
}

interface IFly
{
    void Fly();
}

class Fish : IEat, ISleep, ISwim
{
    public void Eat() { /* Código para comer */ }
    public void Sleep() { /* Código para dormir */ }
    public void Swim() { /* Código para nadar */ }
}

class Bird : IEat, ISleep, IFly
{
    public void Eat() { /* Código para comer */ }
    public void Sleep() { /* Código para dormir */ }
    public void Fly() { /* Código para volar */ }
}
~~~

En resumen, el Principio de Segregación de Interfaces insta a diseñar interfaces específicas y especializadas, evitando así métodos innecesarios para ciertas clases. Al seguir este principio, se logra un código más flexible y reutilizable, mejorando la coherencia y la eficiencia del diseño de software.
