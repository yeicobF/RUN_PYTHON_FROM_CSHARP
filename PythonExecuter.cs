/** 
 * * PROGRAMA PARA MANEJAR UNA CLASE QUE TRABAJE CON LOS MÉTODOS PARA EJECUTAR
 *      PYTHON DESDE C#.
 * 
 * - Jueves, 14 de enero del 2020.
*/
// Listas.
using System.Collections.Generic;

class PythonExecuter {
    // ATRIBUTOS.
    private string scriptName;
    private List <string> arguments;
    /** Constructor que obtendrá el nombre del script que va a correr y los
     *      argumentos. */
    PythonExecuter(string scriptName, List <string> arguments) {
        this.scriptName = scriptName;
        // Ingresa como el primer argumento el nombre del script.
        this.arguments.Insert(0, scriptName);
        /** Inserta los elementos de una colección a la lista comenzando desde
         *      el índice indicado.*/
        this.arguments.InsertRange(1, arguments);
    }
    
}
