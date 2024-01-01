# Principio SRP: El Principio de una Sola Responsabilidad
## ¿Qué significa SRP?
> SRP, o el Principio de una Sola Responsabilidad, establece que una entidad de software, ya sea una función, una clase o incluso un sistema completo, debería tener una única razón para cambiar. En otras palabras, debe realizar una sola tarea y hacerlo de manera efectiva.

## Ejemplo
En este escenario, la clase Customer tiene actualmente dos responsabilidades: validar si el cliente es válido y guardar el cliente en la base de datos. Este diseño no sigue el principio de responsabilidad única de SOLID, que sugiere que cada clase debería tener una única razón para cambiar. Para mejorar el diseño, se deberían separar estas responsabilidades en clases distintas.
~~~
class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }

    public bool Validate()
    {
        // Valida si el cliente es válido
    }

    public void Save()
    {
        // Guarda el cliente en la base de datos
    }
}
~~~

En el siguiente ejemplo, hemos reorganizado el código para cumplir con el principio de responsabilidad única. Ahora, tenemos tres clases distintas: CustomerValidator, CustomerRepository, y Customer. Cada clase tiene una única responsabilidad. 

- CustomerValidator se encarga de validar si el cliente es válido.
- CustomerRepository se encarga de guardar el cliente en la base de datos.
- Customer contiene simplemente la información del cliente.

Este diseño facilita la comprensión del código y su mantenimiento, ya que cada clase tiene un propósito claro.

~~~
class CustomerValidator
{
    public bool Validate(Customer customer)
    {
        // Valida si el cliente es válido
    }
}

class CustomerRepository
{
    public void Save(Customer customer)
    {
        // Guarda el cliente en la base de datos
    }
}

class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
}
~~~
