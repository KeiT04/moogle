##Como usar

1- Antes de usar el Moogle debe introducir su base de datos, dicha base de datos se debe introducir en la carpeta llamada "Contenido". Este proyecto solo permite la lectura y busqueda de archivos de formato txt por lo tanto otros archivos de texto como pdf o doc no apareceran en su busqueda, tengalo en cuenta antes de introducir los archivos en dicha carpeta.
----En caso de que no le convenza el nombre "Contenido" para la carpeta donde debe meter los txt puede ponerle otro nombre y dirigirse al .cs llamado "Program" dentro de la carpeta con el nombre "MoogleServer" dirigirse a donde pone "MoogleEngine.Data.DataBase.Loading("Contenido");" y donde se encuentra la palabra "Contenido" ponerle el nuevo nombre que le introdujo a su carpeta.

2- Una vez haya introducido los archivos .txt en el directrorio mencionado en el paso 1, abra el proyecto y escriba en la terminal "dotnet run --project MoogleServer". En la misma terminal unos segundos (o minutos despues) de que terminen de cargar todos los archivos le aparecera una linea que contendra "http://localhost:XXXX", haga "ctrl + click izquierdo" sobre ese enlace.

3- Una vez hecho el paso anterior se le abrira el navegador con la imagen "Moogle!", donde podra introducir su busqueda para saber que archivos dentro de la carpeta coinciden con la palabra (o palabras) que introdujo en su busqueda.

##Especificaciones

-El proyecto *deberia* funcionar en Windows siguiendo los mismos pasos anteriores. Con los constantes cambios realizados al proyecto y el limitado tiempo para comprobarlo en ese SO no se tiene garantia de que funcione con las versiones mas actualizadas del proyecto.
-Los archivos utilizados donde la fase de pruebas para comprobar el funcionamiento del moogle estaban todos en ingles, en caso de probar archivos en otro idioma se espera se obtengan resultados igual de satisfactorios.
-NO se ha comprobado el limite de la cantidad de archivos que pueda aguantar el proyecto, se estima que pueda aguantar hasta alrededor de 4000 archivos.
-Tenga en cuenta que mientras mas documentos usted introduzca en la carpeta mas tardara en cargar la base de datos.
