/** 
 * * PROGRAMA PARA MANEJAR UNA CLASE QUE TRABAJE CON LOS MÉTODOS PARA EJECUTAR
 *      PYTHON DESDE C#.
 * 
 * - Jueves, 14 de enero del 2020.
*/
using System;
using System.Diagnostics; // Para los procesos.
// Listas.
using System.Collections.Generic;

class PythonExecuter {
    // ATRIBUTOS.
    private string scriptName;
    private List <string> arguments;
    /** Constructor que obtendrá el nombre del script que va a correr y los
     *      argumentos. */
    public PythonExecuter(string scriptName, List <string> arguments) {
        this.scriptName = scriptName;
        // Ingresa como el primer argumento el nombre del script.
        this.arguments.Insert(0, scriptName);
        /** Inserta los elementos de una colección a la lista comenzando desde
         *      el índice indicado.*/
        this.arguments.InsertRange(1, arguments);
    }

    /** 
     * ! PRIMER VERSIÓN DEL MÉTODO PARA EJECUTAR Python desde C#.
     * * Aquí tomamos como parámetro los argumentos recibidos y definimos el
     *      programa de Python desde aquí.
    */
    public void FirstVersionExecutePythonFromCSharp(List <string> arguments)
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
        * Método para guardar los argumentos como una lista. No permite pasarlo
        *   con "ref" por referencia. No sé si regresen modificados.
       */
        SaveArgumentsAsList(pythonProgram.ArgumentList, pythonScriptName, arguments);

        

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
        foreach(string arg in argsReceived){
            argsList.Add(arg);
        }
    }
    /**
     * * MÉTODO PARA GUARDAR LOS ARGUMENTOS COMO CADENA UTILIZANDO EL
     *      ATRIBUTO: ProcessStartInfo.Arguments
    */
    private static void SaveArgumentsAsString(string argsList,
                                              string pythonScriptName,
                                              List<string> argsReceived)
    {
        // OPCIÓN 2 ARGUMENTOS: OTRA ALTERNATIVA (COMO LA QUE SALE EN EL VIDEO).
        argsList = $"\"{pythonScriptName}\"";
        
        foreach (string arg in argsReceived)
        {
            /** La cadena realmente iría como: ' "argumento"'
             *  Lleva un espacio porque es como si en la terminal
             *   corriera: 
             *  
             *       python pythonScriptName arg1 arg2 arg3 ...
             */
            argsList += $" \"{arg}\"";
        }
    }
}
