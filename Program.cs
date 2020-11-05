using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DibujarRectanguloCiclosAnidados
{
    /*
     * @author: Erick Escamilla Charco.
     */
    public class InputReader {
        public InputReader() {
        }

        public byte ReadByte(string inputMsg, string errorMsg) {
            string readValueAsStr;
            byte value = 0;
            bool error = false;

            do {

                if (error) {
                    Console.WriteLine(errorMsg);
                }

                Console.WriteLine(inputMsg);
                readValueAsStr = Console.ReadLine();
                try
                {
                    value = Byte.Parse(readValueAsStr);
                    error = false;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                    error = true;
                }
            } while (error);

            return value;
        }
    }//--Fin: public class InputReader
    class Program
    {
        static void Main(string[] args)
        {
            InputReader inputReader = new InputReader();
            char continuar;
            byte filas, columnas;
            do {
                Console.Clear();
                Console.WriteLine("##--Dibujar rectángulo (by EEC)--##");

                filas = inputReader.ReadByte("Especifique el número de filas del rectángulo (ENTERO entre 0 y 255): ", "ERROR en el formato del número ingresado, por favor ingrese un ENTERO entre 0 y 255.");
                columnas = inputReader.ReadByte("Especifique el número de Columnas del rectángulo (ENTERO entre 0 y 255): ", "ERROR en el formato del número ingresado, por favor ingrese un ENTERO entre 0 y 255.");

                DrawRectangle(filas, columnas, '=');

                Console.WriteLine("\t¿Desea dibujar otro rectángulo? [y/n]: ");
                continuar = Console.ReadKey().KeyChar;
            } while (Char.ToLower(continuar).Equals('y'));
        }

        private static void DrawRectangle(byte filas, byte columnas, char symbol) {
            for (int i = 1; i <= filas; i++) {
                for (int j = 1; j <= columnas; j++) {
                    // si es la PRIMERA o la ÚLTIMA COLUMNA Dibujar siempre
                    if (j == 1 || j == columnas)
                    {
                        Console.Write(symbol);
                    }
                    else {
                        // si es una de las Columnas "intermedias"
                        // validar si se trata de la PRIMERA o ÚLTIMA FILA
                        if (i == 1 || i == filas)
                        {
                            // si es PRIMERA o ÚLTIMA FILA dibujar "fila completa" ("######")
                            Console.Write(symbol);
                        }
                        else {
                            // si se trata de una fila "intermedia", rellenar con espacios en blanco
                            Console.Write(" ");
                        }
                    }
                }
                // Para separar cada fila "imprimir" caracter de New line (\n)
                Console.Write("\n");
            }
        }//--Fin: private static void DrawRectangle()

    } //--Fin: class Program


}
