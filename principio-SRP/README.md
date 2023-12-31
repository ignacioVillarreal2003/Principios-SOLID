# Principio SRP

SRP: El principio de una sola responsabilidad

## ¿Qué es SRP?
> Una entidad de software debe tener una y solo una razón para cambiar. Haz UNA SOLA COSA y hazla bien, esto se puede aplicar a cualquier nivel: De clase, de función o incluso a nivel de sistema.

### A bajo nivel: Funciones
Todo el mundo sabe que una función que hace una sola cosa es más fácil de leer, más fácil de entender y por lo tanto mucho más fácil de depurar y de probar.
### A nivel medio: Clases
Es al nivel para el que fue descrito inicialmente el principio de responsabilidad única, donde una responsabilidad se define como un motivo para cambiar.
Este principio incita a que mantengamos una alta cohesión dentro de nuestras clases de forma que funciones las relacionadas se encuentran dentro de una misma clase y las funciones no relacionadas se encuentran en clases separadas.
### A nivel de sistema
Este principio de responsabilidad única, y de mantener bajo acoplamiento y alta cohesión en nuestros componentes también se puede aplicar a alto nivel. Ya hace unos años están de moda en arquitectura de sistemas los microservicios que de nuevo son sistemas completos con una responsabilidad única podríamos tener un servicio de logging, uno de autenticación…etc de nuevo, esto facilita saber donde buscar a la hora de depurar, y el bajo acoplamiento permite reemplazar un componente por otro sin demasiada dificultad.


## Ejemplo
~~~
var mysql = require('mysql');

function addUser( user, dbConfig ) {
   var dbConnection = mysql.createConnection( {
				host : dbConfig.dbHost,
				user : dbConfig.dbUser,
				password: dbConfig.dbPwd,
				database : dbConfig.dbName
			});

   var sqlQuery = mysql.format("INSERT INTO users (mail, password, alias) VALUES (?, ?, ?)",
		 	       [user.loginMail, user.loginUserPassword, user.loginAlias] );

   return dbConnection.query( sqlQuery );
};
~~~

De acuerdo, la función addUser() puede que funcione, pero está violando el principio SRP, porque se encarga de tres responsabilidades diferentes:

- Crear la conexión con la base de datos.
- Construir la consulta sql.
- Ejecutar la consulta.
De este modo, estamos dando pie a que cuando añadamos otra función de manipulación de la base de datos, repitamos en él la creación de la conexión de la base de datos, etc. O sea, que lo anterior nos deja poco margen para la reutilización y sin duda duplicaremos mucho código.

Una mejor más alineada con SRP sería la siguiente.
~~~
var util = require('util');

function getDBConnection( dbConfig ) {
   return mysql.createConnection( {
 			        host : dbConfig.dbHost,
				user : dbConfig.dbUser,
				password: dbConfig.dbPwd,
				database : dbConfig.dbName
			});
}

function execQuery( sqlQuery, dbConfig ) {
   var dbConnection = getDBConnection( dbConfig );

  return dbConnection.query( sqlQuery );
}

function buildInsertQuery( entity, fields, values ) {
   return util.format( "INSERT INTO %d (%s) values [%s]", entity, fields.join(','), values.join(',') );
}

function addUser( user, dbConfig ) {
   var sqlQuery = buildInsertQuery( 'users', 
  			            ['mail', 'password', 'alias']
				    [user.loginMail, user.loginUserPassword, user.loginAlias] );
   return execQuery( sqlQuery, dbConfig )
}
~~~

Se puede pensar que ahora el código es mayor, pero:

- la función addUser() es mucho más pequeña: en dos líneas inserta los datos del nuevo usuario en la base de datos. Deja a otras funciones la creación de la fontanería necesaria para ello.
- Se han creado algunas funciones reutilizables, como buildInsertQuery(), getDBConnection() y execQuery(), que, en caso de tratarse de un proyecto real, serían fácilmente reutilizables.
- Ahora este código es más fácil de probar en tests automatizados.
- Descoplamos más la solución de la infraestructura subyacente: si el proceso de creación de la conexión de la base de datos cambia, tan solo hay que modificar getDBConnection(), por poner un ejemplo.
