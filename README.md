# ArandaServerAuth

Administra los usuario de Aranda Software

Server Backend Solucion Asp.Net

Clonar la solucion desde GitHub

Clonar
Abrir ella solucion desde (Preferiblemente desde Visual Studio 2013 o superior)
La solución cuanta con dos proyectos web, se debe asegurar que la solución inicie con los dos: Dar click derecho en la solución>properties>(en el menu de la izquierda)Commo Properties>StartUp projects, allí asegurarse que SocialNetwork.Api y SocialNetwork.OAuth tengan en la casilla de accion "Start"
Crear base de datos desde Code First (E.F): Se utiliza code first E.F. 6.0, pa crear la base de datos,tablas y registros de inicio correr en Package manager console seleccionando el proyecto de las migraciones SocialNetwork.Data

update-database -ConfigurationTypeName SocialNetwork.Data.Migrations.ProfileMigrations.Configuration -verbose
update-database -ConfigurationTypeName SocialNetwork.Data.Migrations.CommentMigration.Configuration -verbose
Nota: Los comandos buscaran la configuracion por defecto que tenga el visual studio configurada para crear la BD, pero si se desea un server de BD en particular se requiere que se adicione la nueva cadena de conexión que se quiere en el App.Config y en el Web.Config de las aplicaiones Web

Seguir con la clonacion del cliente desde: https://github.com/OswaldoMartinezMendez/Aranda.Management.git
