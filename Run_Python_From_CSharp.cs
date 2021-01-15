using System;
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

            // Mandamos el nombre del código de Python, el cual está en el mismo
            //  directorio.
            string pythonScriptName = "python_script/receive_and_print_arguments.py";
            // Agregamos el nombre del programa a la lista de argumentos.
            args_list.Add(pythonScriptName);

            AskUserForArguments(ref args_list);
            // PrintUserInputArguments(args_list);

            PythonExecuter pyExecuter = new PythonExecuter(pythonScriptName, args_list);

            pyExecuter.ExecutePythonFromCSharp();

            Console.ReadKey(); // Esperar a presionar tecla para terminar.
        }

        
/* -------------------------------------------------------------------------- */
/*                    MÉTODO PARA EJECUTAR Python desde C#.                   */
/* -------------------------------------------------------------------------- */
       

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
