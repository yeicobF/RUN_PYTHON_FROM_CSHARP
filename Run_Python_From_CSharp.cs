using System;
using System.Diagnostics; // Para los procesos.

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
    class RunPythonFromCSharp{
        // BUGFIX
        static void Main(string[] args)
        {
            Console.WriteLine("\nHello, world!\n");
        }

        
/* -------------------------------------------------------------------------- */
/*                    MÉTODO PARA EJECUTAR Python desde C#.                   */
/* -------------------------------------------------------------------------- */
       private static void ExecutePythonFromCSharp(string[] arguments){
           // Creamos una variable en donde inicializaremos el proceso.
           // Para esto hay que utilizar System.Diagnostics.
           var process = new ProcessStartInfo();
           
           // Indicar la ruta del ejecutable de Python.
           string pythonPath = @"C:\Users\games_000.ASHJAC\AppData\Local\Programs\Python\Python38-32\python.exe";
           process.FileName = pythonPath;

           // Mandar el código y los argumentos.
            
       }
    }
}
