# How to create and work in a C# solution file

> Miércoles, 13 de enero del 2021 [02:53 AM - 03:07 AM]

En este archivo indicaré la forma para trabajar com C# en Visual Studio Code
    con IntelliSense, pero para esto requerimos utilizar "dotnet".

## PASOS

1.- Crear la carpeta en donde vamos a trabajar con el programa.
2.- Crear una aplicación de consola. Esto creará varias carpetas y un archivo
    con la extensión ".csproj", el cual será útil más adelante.

        COMANDO: `dotnet new console``

3.- Crear una solución, la cual podrá almacenar más de un proyecto para
    compilarlos todos al mismo tiempo.

        COMANDO: `dotnet new sln -n solution_name`

    Al utilizar este comando se creará un archivo con el nombre que le dimos,
        "solution_name", y la extensión ".sln". Esto dará como resultado un
        archivo con el siguiente formato: "solution_name.sln".
    
4.- Agregar el archivo que se creó en el paso 2, cuya extensión es ".csproj"
    a la solución. Esto se logra con el siguiente comando:

        COMANDO: `dotnet sln solution_name.sln add file_name.csproj`

    Este paso se deberá repetir cada que se cree un nuevo proyecto (aplicación
        de consola, librería, etcétera).

5.- Ahora ya casi todo está listo para que IntelliSense funcione, pero falta un
    paso por si sigue sin funcionar. Hay que indicarle la solución en la que
    estamos trabajando a OmniSharp, que es lo que hace funcionar a IntelliSense.
    Esto se logra con los siguientes pasos:

        5.1.- Presiona la tecla "`F1`".
        5.2.- Escribe "`OmniSharp: Select Project`". Te aparecerá una lista de
                numerosos archivos.
        5.3.- Selecciona la solución con la que estás trabajando.
        5.4.- Ya debería detectar tu solución y comenzar a funcionar
                IntelliSense.

6.- El último paso solo es para asegurar que todo funcione correctamente. Hay
    que configurar que OmniSharp tome como directorio (path) el último en el que
    se trabajó. Para esto vamos al archivo "`settings.json`", al cual podremos
    acceder con el comando (personalizado):

        `Ctrl + , + Ctrl + ,`
    
    Ahora, agregar lo siguiente:

        `"omnisharp.path": "latest"`

7.- Y listo. Esto es todo lo necesario para hacer funcionar IntelliSense, crear
    soluciones, y hacerlas trabajar.
