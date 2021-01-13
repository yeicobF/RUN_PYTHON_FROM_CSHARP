using System;
using System.Diagnostics; // Para los procesos.
using System.Collections.Generic; // Aquí se encuentran las listas.
/**
 * * PROGRAMA PARA CORRER PYTHON DESDE C#.
 * 
 * Esto será útil para poder realizar el proyecto de la compra de sneakers
 *  con un bot automáticamente en línea.
 * 
 * * Para hacer el programa vi un video en YouTube en donde lo explicaban.
 * * Indicaba que podríamos utilizar 2 métodos:
 *  ! Utilizando procesos
 *  ! Utilizando IronPython, que es Python en .NET.
 * 
 * * Yo decidí utilizar procesos mejor, ya que IronPython al parecer tiene más
 *  limitaciones.
 * LINK: https://www.youtube.com/watch?v=g1VWGdHRkHs&ab_channel=AllTech
 * 
 * * Martes, 12 de enero del 2020.
*/

namespace Run_Python_From_CSharp
{
    class RunPythonFromCSharp {
        static void Main(string[] args)
        {
            // Console.WriteLine("\nHello, world!\n");

            // Mandar el código y los argumentos.
            // Inicializar lista de string.
            List<string> args_list = new List<string>();
            AskUserForArguments(ref args_list);
            // PrintUserInputArguments(args_list);

            ExecutePythonFromCSharp(args_list.ToArray());

            Console.ReadKey(); // Esperar a presionar tecla para terminar.
        }

        
/* -------------------------------------------------------------------------- */
/*                    MÉTODO PARA EJECUTAR Python desde C#.                   */
/* -------------------------------------------------------------------------- */
       private static void ExecutePythonFromCSharp(string[] arguments) {
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
            
            // OPCIÓN 1 ARGUMENTOS: Agregamos los argumentos a una lista de argumentos.
            // pythonProgram.ArgumentList.Add(pythonScriptName);
            // foreach(string arg in arguments){
            //     pythonProgram.ArgumentList.Add(arg);
            // }

            // OPCIÓN 2 ARGUMENTOS: OTRA ALTERNATIVA (COMO LA QUE SALE EN EL VIDEO).
            pythonProgram.Arguments = $"\"{pythonScriptName}\"";
            foreach (string arg in arguments)
            {
                /** La cadena realmente iría como: ' "argumento"'
                 *  Lleva un espacio porque es como si en la terminal
                 *   corriera: 
                 *  
                 *       python pythonScriptName arg1 arg2 arg3 ...
                 */
                pythonProgram.Arguments += $" \"{arg}\"";
            }

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
            using(Process pythonProgramRunning = Process.Start(pythonProgram)){
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

/* ----------------- MÉTODO PARA PEDIR ARGUMENTOS AL USUARIO ---------------- */
        private static void AskUserForArguments(ref List<string> args_list) {
            // Para preguntar si continuar ingresando valores.
            short option = 1; // Represents a 16-bit signed integer.
            for(int argNumber = 1; option == 1; argNumber++){
                Console.WriteLine("\n -> INGRESA EL ARGUMENTO {0}: ", argNumber);
                args_list.Add(Console.ReadLine()); // Lo agregamos a la lista.

                Console.WriteLine("\n - ¿Deseas seguir ingresando valores?\n");
                Console.WriteLine("      1.- Sí, 2.- No.\n");
                // short option: Represents a 16-bit signed integer.
                option = Convert.ToInt16(Console.ReadLine());
            }
        }

/* ------ MÉTODO PARA IMPRIMIR LOS ARGUMENTOS INGRESADOS POR EL USUARIO ----- */
        private static void PrintUserInputArguments(List<string> args_list) {
            int argNumber = 0;
            Console.WriteLine("\n");
            // Foreach que recorrerá cada elemento de la lista y lo imprimirá.
            foreach(string argument in args_list){
                Console.WriteLine("\n - [ARGUMENTO #{0}]: {1}", argNumber, argument);
                
                argNumber++;
            }
            Console.WriteLine("\n");
        }
    }
}
