using System;

namespace BuscaminasDefinitivo
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleGame<Celda> juego = new ConsoleGame<Celda>(6, 7, 5);
            Console.ReadKey();

        }
    }

}