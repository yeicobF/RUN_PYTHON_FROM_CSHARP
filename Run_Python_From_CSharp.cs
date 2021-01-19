/**
 * * PROGRAMA PARA CORRER PYTHON DESDE C#.
 * 
 * Esto será útil para poder realizar el proyecto de la compra de sneakers
 *  con un bot automáticamente en línea.
 * 
 * * Para hacer el programa vi un video en YouTube en donde lo explicaban.
 * * Indicaba que podríamos utilizar 2 métodos:
 * ! Utilizando procesos
 * ! Utilizando IronPython, que es Python en .NET.
 * 
 * * Yo decidí utilizar procesos mejor, ya que IronPython al parecer tiene más
 *  limitaciones.
 * LINK: https://www.youtube.com/watch?v=g1VWGdHRkHs&ab_channel=AllTech
 *  
 * * Martes, 12 de enero del 2020.
*/

using System;
// Aquí se encuentran las listas.
using System.Collections.Generic;
// Tiene un método para pasar de Arreglo a Lista.
using System.Linq;

namespace Run_Python_From_CSharp
{
    class RunPythonFromCSharp {
        private static PythonExecuter pyExecuter;
        static void Main(string[] args)
        {
            /** Ahora con esta nueva implementación recibiremos los argumentos
             *      para correr el programa en Python pero desde que corremos
             *      el programa en C#.
             * 
             * *    dotnet run my_solution.sln arg1 arg2 arg3
            */
            pyExecuter = new PythonExecuter("python_script/receive_and_print_arguments.py",
                                            args.ToList());

            pyExecuter.ExecutePythonFromCSharp();


            // PARA PROBAR CON EL MÉTODO ANTIGUO.
            // pyExecuter.FirstVersionExecutePythonFromCSharp(args.ToList());

            Console.Write("\n\n -> PRESIONA UNA TECLA PARA TERMINAR EL PROGRAMA: ");
            // Para no brincar línea. No me funcionó.
            // Console.SetCursorPosition(0, Console.CursorTop);
            /** Esperar a presionar tecla para terminar.
             *  Su parámetro es "false" para que se muestre la tecla que se
             *      presionó.
             */
            Console.ReadKey(false);
        }     

        /**
         * * MÉTODO PARA GUARDAR EL ANTIGUO MAIN ANTES DE MODIFICARLO.
         * Lo pongo simplemente para no borrarlo, ya que aquí está el concepto
         *  original de cómo sería el programa.
        */
       private static void OldMain(){
            // Console.WriteLine("\nHello, world!\n");

            // Mandar el código y los argumentos.
            // Inicializar lista de string.
            List<string> args_list = new List<string>();

            // Mandamos el nombre del código de Python, el cual está en el mismo
            //  directorio.
            string pythonScriptName = "python_script/receive_and_print_arguments.py";
            // Agregamos el nombre del programa a la lista de argumentos.
            // args_list.Add(pythonScriptName);

            AskUserForArguments(ref args_list);
            // PrintUserInputArguments(args_list);

            PythonExecuter pyExecuter = new PythonExecuter(pythonScriptName, args_list);

            pyExecuter.FirstVersionExecutePythonFromCSharp(args_list);

            Console.Write("\n\n -> PRESIONA UNA TECLA PARA TERMINAR EL PROGRAMA: ");
            // Para no brincar línea. No me funcionó.
            // Console.SetCursorPosition(0, Console.CursorTop);
            /** Esperar a presionar tecla para terminar.
             *  Su parámetro es "false" para que se muestre la tecla que se
             *      presionó.
             */
            Console.ReadKey(false);
       }

/* ----------------- MÉTODO PARA PEDIR ARGUMENTOS AL USUARIO ---------------- */
        private static void AskUserForArguments(ref List<string> args_list) {
            // Para preguntar si continuar ingresando valores.
            short option = 1; // Represents a 16-bit signed integer.
            for(int argNumber = 1; option == 1; argNumber++){
                Console.Write("\n -> INGRESA EL ARGUMENTO {0}: ", argNumber);
                // Para no crear nueva línea. No funcionó.
                // Console.SetCursorPosition(0, Console.CursorTop);
                args_list.Add(Console.ReadLine()); // Lo agregamos a la lista.

                Console.Write("\n\t - ¿Deseas seguir ingresando valores?");
                Console.Write(" [1.- Sí | 2.- No]: ");
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
