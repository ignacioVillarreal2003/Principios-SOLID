# Principio SRP: El Principio de una Sola Responsabilidad
## ¿Qué significa SRP?
> SRP, o el Principio de una Sola Responsabilidad, establece que una entidad de software, ya sea una función, una clase o incluso un sistema completo, debería tener una única razón para cambiar. En otras palabras, debe realizar una sola tarea y hacerlo de manera efectiva.

### En Funciones:
Cuando aplicamos SRP a funciones, nos referimos a que cada función debería hacer una tarea específica. Esto facilita la lectura, comprensión, depuración y prueba del código.

### En Clases:
A nivel de clases, el principio impulsa a que cada clase tenga una responsabilidad claramente definida, entendiendo una responsabilidad como una razón para cambiar. Las funciones relacionadas deben estar dentro de la misma clase, mientras que funciones no relacionadas deberían residir en clases separadas.

### A Nivel de Sistema:
Este principio no se limita a clases y funciones, también se extiende a sistemas completos. Por ejemplo, en arquitecturas de sistemas como los microservicios, cada servicio tiene una responsabilidad única, como manejar el registro o la autenticación. Esto facilita la depuración, ya que sabemos dónde buscar problemas, y el bajo acoplamiento permite reemplazar un componente por otro con relativa facilidad. En resumen, SRP aporta claridad y mantenibilidad al diseño del software.


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
