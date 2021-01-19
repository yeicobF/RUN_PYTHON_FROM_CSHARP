/** 
 * * PROGRAMA PARA MANEJAR UNA CLASE QUE TRABAJE CON LOS MÉTODOS PARA EJECUTAR
 *      PYTHON DESDE C#.
 * 
 * - Jueves, 14 de enero del 2021.
*/
using System;
using System.Diagnostics; // Para los procesos.
// Listas.
using System.Collections.Generic;

class PythonExecuter {
    // ATRIBUTOS.
    private string scriptName;
    private List<string> arguments;
    /** Constructor que obtendrá el nombre del script que va a correr y los
     *      argumentos. */
    public PythonExecuter(string scriptName, List<string> arguments) {
        this.scriptName = scriptName;
        
        this.arguments = new List<string>();
    
        // Ingresa como el primer argumento el nombre del script.
        this.arguments.Insert(0, scriptName);
        /** Inserta los elementos de una colección a la lista comenzando desde
         *      el índice indicado.*/
        this.arguments.InsertRange(1, arguments);

        PrintArguments();

        Console.Write("\n\n - PYTHON PATH: [" + GetPythonFromUserEnvironmentVariables() + "]\n\n");
    }
    /** MÉTODO DEFINITIVO PARA EJECURAR Python desde C#. */
    public void ExecutePythonFromCSharp() {
        // Creamos una variable en donde inicializaremos el proceso.
        // Para esto hay que utilizar System.Diagnostics.
        ProcessStartInfo pythonProgramStartInfo = new ProcessStartInfo();

        string pythonPath = GetPythonFromUserEnvironmentVariables();




        // Agregamos la ruta de Python al proceso que correremos.
        pythonProgramStartInfo.FileName = pythonPath;
        // 3) PROCESS CONFIGURATION
        /** No ejecutar en la terminal. Se hace directamente desde el ejecutable.
         *  true si queremos que se abra la terminal. 
         * 
         *  ! Si es true, no se pueden obtener los valores de entrada / salida.*/
        pythonProgramStartInfo.UseShellExecute = false;
        // pythonProgramStartInfo.UseShellExecute = true;
        // Indicar que no queremos crearlo en una nueva ventana.
        pythonProgramStartInfo.CreateNoWindow = true;
        // // Indicar que sí queremos obtener el valor que regrese el programa.
        // pythonProgramStartInfo.RedirectStandardOutput = true;
        // // Si pasa algún error en el scrip, lo recibiremos.
        // pythonProgramStartInfo.RedirectStandardError = true;
        // Indicar que sí queremos obtener el valor que regrese el programa.
        pythonProgramStartInfo.RedirectStandardOutput = true;
        // Si pasa algún error en el scrip, lo recibiremos.
        pythonProgramStartInfo.RedirectStandardError = true;

        // 4) EXECUTE THE PROCESS AND GET OUTPUT.
        string errors = "";
        // En resultados se guarda TODO lo que se imprime en el programa.
        string results = "";

        // Iniciamos el proceso y recibimos los errores y valores de regreso.
        using (Process pythonProgramRunning = Process.Start(pythonProgramStartInfo))
        {
            // Obtener errores y resultados.
            errors = pythonProgramRunning.StandardError.ReadToEnd();
            results = pythonProgramRunning.StandardOutput.ReadToEnd();
        }

        //             /** PARA CREAR TERMINAL.*/
        //             // Iniciamos el proceso y recibimos los errores y valores de regreso.
        //             // using(Process pythonProgramRunning = Process.Start(pythonProgramStartInfo)){
        //             //     // Obtener errores y resultados.
        //             //     errors = pythonProgramRunning.StandardError.ReadToEnd();
        //             //     results = pythonProgramRunning.StandardOutput.ReadToEnd();
        //             // }
        // 
        //             Process.Start(pythonProgramStartInfo);

        // 5) DISPLAY OUTPUT
        Console.WriteLine($"\n - ERRORES: {errors}");
        Console.WriteLine("\n - RESULTADOS:\n");
        Console.WriteLine(results);
    }
    /** 
     * * MÉTODO PARA OBTENER PYTHON DESDE LAS VARIABLES DEL SISTEMA. 
     * 
     * ! FUENTE: https://stackoverflow.com/questions/3403895/how-to-read-a-user-environment-variable-in-c
     * 
     * * Environment.GetEnvironmentVariable(variable, target);
     *  ! EnvironmentVariableTarget.Process,
     *  ! EnvironmentVariableTarget.User,
     *  ! EnvironmentVariableTarget.Machine.
    */
    private string GetPythonFromUserEnvironmentVariables() {
        // Indicar la ruta del ejecutable de Python.
        string python = "python.exe", pythonPath = "";

        List<string> pathList = SavePathVariablesInList();

        /* Buscar la variable que contiene la carpeta de Python, pero no la de
            scripts. */
        foreach(string path in pathList) {
            if(path.Contains("Python") && !path.Contains("Scripts")){
                pythonPath = path + python;
                break;
            }
        }

        return pythonPath;
    }
    // Método que guardará todas las variables encontradas en una lista.
    private List<string> SavePathVariablesInList(){
        // Aquí se obtienen TODAS las variables que se encuentran en "Path".
        string path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User);

        // Meteré todas las variables en una lista y luego obtendré la que busco.
        List<string> pathList = new List<string>();

        string pathSubstring = "";
        // Índice del punto y coma.
        int indexOfSemicolon = 0;
        // Cada variable termina con un ";".
        while(path.Contains(";")){
            indexOfSemicolon = path.IndexOf(";");
            // Busca desde la primera ocurrencia hasta en donde encuentra el ";".
            // Con Trim() quitamos los espacios que queden al inicio o final.
            pathSubstring = path.Substring(0, indexOfSemicolon).Trim();
            pathList.Add(pathSubstring);

            /** Quitamos la variable guardada en la lista.
             * Tuve que empezar la subcadena desde el índice 1 porque en el 0 se
             *  guardaba el punto y coma (";") que quedaba por empezar desde su
             *  subíndice en la cadena.
            */
            path = path.Substring(indexOfSemicolon + 1, path.Length - indexOfSemicolon - 1);
        }

        return pathList;
    }
    // Método para imprimir los argumentos del constructor.
    void PrintArguments(){
        // IMPRIMIR LOS ARGUMENTOS EN TOTAL.
        Console.Write("\n -> ARGUMENTOS: ");
        foreach(string arg in arguments)
            Console.Write($"[{arg}] ");
        Console.Write("\n");
    }
    /** 
     * ! PRIMER VERSIÓN DEL MÉTODO PARA EJECUTAR Python desde C#.
     * * Aquí tomamos como parámetro los argumentos recibidos y definimos el
     *      programa de Python desde aquí.
    */
/* -------------------------------------------------------------------------- */
/*                    MÉTODO PARA EJECUTAR Python desde C#.                   */
/* -------------------------------------------------------------------------- */
  
    public void FirstVersionExecutePythonFromCSharp(List <string> receivedArgsList)
    {
        // Creamos una variable en donde inicializaremos el proceso.
        // Para esto hay que utilizar System.Diagnostics.
        ProcessStartInfo pythonProgram = new ProcessStartInfo();

        // Indicar la ruta del ejecutable de Python.
        string pythonPath = @"C:\Users\games_000.ASHJAC\AppData\Local\Programs\Python\Python38-32\python.exe";
        // Agregamos la ruta de Python al proceso que correremos.
        pythonProgram.FileName = pythonPath;

        // Mandar el código y los argumentos.
        // Inicializar lista de string.
        // List<string> args_list = new List<string>();
        // AskUserForArguments(ref args_list);
        // PrintUserInputArguments(args_list);

        // Mandamos el nombre del código de Python, el cual está en el mismo
        //  directorio.
        string pythonScriptName = "python_script/receive_and_print_arguments.py";
        /**
         * * $ Antes de una cadena es parecido a string.Format(), pero en
         *  lugar de escribir:
         * 
         *      string.Format("{0},{1},{2}", anInt, aBool, aString);
         *  
         *  se escribiría:
         *      
         *      $"{anInt},{aBool},{aString}";
         * 
         * ! FUENTE: What does $ mean before a string?
         * LINK: https://stackoverflow.com/questions/31014869/what-does-mean-before-a-string 
        */

        /** 
         * * Método para guardar los argumentos como una lista. No permite pasarlo
         * ? con "ref" por referencia. No sé si regresen modificados.
         * 
         * * YA VI QUE SÍ REGRESA MODIFICADO.
         * 
         * ! COMO LISTA SÍ MANDA TODO Y COMILLAS, ASÍ QUE ES LA MEJOR FORMA PARA
         *      EVITAR CONFLICTOS.
        */
        SaveArgumentsAsList(pythonProgram.ArgumentList, pythonScriptName, receivedArgsList);

        /** 
         * * Método para guardar los elementos como una cadena.
         * ? Tampoco se pueden pasar como "ref", por lo que no se si se
         *      modifique.
         * * NO REGRESA MODIFICADO. Por esta razón el método devolverá la cadena
         *      y se la asignaremos a la variable.
         * 
         * ! COMO CADENA NO GUARDA LAS COMILLAS NI NADA DE ESO. NO LAS PASA COMO
         *      ARGUMENTOS DEL PROGRAMA.
        */

        // * pythonProgram.Arguments = SaveArgumentsAsString(pythonScriptName, receivedArgsList);

        // 3) PROCESS CONFIGURATION
        /** No ejecutar en la terminal. Se hace directamente desde el ejecutable.
         *  true si queremos que se abra la terminal. 
         * 
         *  ! Si es true, no se pueden obtener los valores de entrada / salida.*/
        pythonProgram.UseShellExecute = false;
        // pythonProgram.UseShellExecute = true;
        // Indicar que no queremos crearlo en una nueva ventana.
        pythonProgram.CreateNoWindow = true;
        // // Indicar que sí queremos obtener el valor que regrese el programa.
        // pythonProgram.RedirectStandardOutput = true;
        // // Si pasa algún error en el scrip, lo recibiremos.
        // pythonProgram.RedirectStandardError = true;
        // Indicar que sí queremos obtener el valor que regrese el programa.
        pythonProgram.RedirectStandardOutput = true;
        // Si pasa algún error en el scrip, lo recibiremos.
        pythonProgram.RedirectStandardError = true;

        // 4) EXECUTE THE PROCESS AND GET OUTPUT.
        string errors = "";
        // En resultados se guarda TODO lo que se imprime en el programa.
        string results = "";

        // Iniciamos el proceso y recibimos los errores y valores de regreso.
        using (Process pythonProgramRunning = Process.Start(pythonProgram))
        {
            // Obtener errores y resultados.
            errors = pythonProgramRunning.StandardError.ReadToEnd();
            results = pythonProgramRunning.StandardOutput.ReadToEnd();
        }

        //             /** PARA CREAR TERMINAL.*/
        //             // Iniciamos el proceso y recibimos los errores y valores de regreso.
        //             // using(Process pythonProgramRunning = Process.Start(pythonProgram)){
        //             //     // Obtener errores y resultados.
        //             //     errors = pythonProgramRunning.StandardError.ReadToEnd();
        //             //     results = pythonProgramRunning.StandardOutput.ReadToEnd();
        //             // }
        // 
        //             Process.Start(pythonProgram);

        // 5) DISPLAY OUTPUT
        Console.WriteLine($"\n - ERRORES: {errors}");
        Console.WriteLine("\n - RESULTADOS:\n");
        Console.WriteLine(results);
    }

    /**
     * * MÉTODO PARA GUARDAR LOS ARGUMENTOS COMO LISTA UTILIZANDO EL
     *      ATRIBUTO: ProcessStartInfo.ArgumentList
    */
    private static void SaveArgumentsAsList(System.Collections.ObjectModel.Collection<string> argsList,
                                            string pythonScriptName,
                                            List <string> argsReceived)
    {
        // OPCIÓN 1 ARGUMENTOS: Agregamos los argumentos a una lista de argumentos.
        argsList.Add(pythonScriptName);
        foreach(string arg in argsReceived)
            argsList.Add(arg);
        

        // IMPRIMIR LISTA DE ARGUMENTOS.
        // for(int i = 0; i < argsList.Count; i++)
        //     Console.WriteLine($"\n - ARGUMENT [{i}]: {argsList[i]}");
    }
    /**
     * * MÉTODO PARA GUARDAR LOS ARGUMENTOS COMO CADENA UTILIZANDO EL
     *      ATRIBUTO: ProcessStartInfo.Arguments
    */
    private static string SaveArgumentsAsString(string pythonScriptName,
                                              List<string> argsReceived)
    {
        // OPCIÓN 2 ARGUMENTOS: OTRA ALTERNATIVA (COMO LA QUE SALE EN EL VIDEO).
        string argsString = $"\"{pythonScriptName}\"";
        
        // Vamos agregando a la cadena los argumentos.
        foreach (string arg in argsReceived)
        {
            /** La cadena realmente iría como: ' "argumento"'
             *  Lleva un espacio porque es como si en la terminal
             *   corriera: 
             *  
             *       python pythonScriptName arg1 arg2 arg3 ...
             */
            argsString += $" \"{arg}\"";
        }
        return argsString;
    }
}
