using System;

namespace BuscaminasDefinitivo
{
    class Program
    {
        static void Main(string[] args)
        {
            int filas = 0, columnas = 0, minas = 0, op = 0;
            Console.WriteLine("\n\t\t*****BUSCAMINAS*****");
            Console.WriteLine("Dificultad:\n1) Fácil\n2) Normal\n3) Difícil\n4) Personalizado");
            do 
            {
                Console.Write("Elige una opción: ");
                op = int.Parse(Console.ReadLine());
            } while ((op != 1) && (op != 2) && (op != 3) && (op != 4));
            switch (op)
            {
                case 1:
                    filas = 7;
                    columnas = 6;
                    minas = 10;
                    break;
                case 2:
                    filas = 10;
                    columnas = 9;
                    minas = 15;
                    break;
                case 3:
                    filas = 15;
                    columnas = 14;
                    minas = 20;
                    break;
                case 4:
                    Console.Write("¿Cuántas filas?: ");
                    filas = int.Parse(Console.ReadLine());
                    Console.Write("¿Cuántas columnas?: ");
                    columnas = int.Parse(Console.ReadLine());
                    Console.Write("¿Cuántas minas?: ");
                    minas = int.Parse(Console.ReadLine());
                    break;
            }

            ConsoleGame < Celda > juego = new ConsoleGame<Celda>(columnas, filas, minas);
            Console.ReadKey();

        }
    }

}