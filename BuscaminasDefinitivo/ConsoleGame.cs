using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaminasDefinitivo
{
    class ConsoleGame<T> : Game<T> where T : ICell, new()
    {
        private char hiddenSymbol;
        private char mineSymbol;
        private char flagSymbol;
        private bool firstMove;
        string coordenada;


        public ConsoleGame(int Widht, int Height, int minas) : base(Widht, Height, minas)
        {
            this.hiddenSymbol = (char)9632;
            this.mineSymbol = '*';
            this.flagSymbol = '#';
            Console.Clear();
            this.Showgrid();
            this.firstMove = true;
        }

        public void Showgrid()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', Console.WindowWidth * 3));
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Minas restantes : {0}", this.FlagCounter);
            Console.Write((" ").PadLeft(4));
            for (int i = 0; i < Width; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write((char)(65+i)+ " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            string printingValue;
            for (uint i = 0; i < this.Height; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(((i + 1)+" ").PadLeft(4));
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < this.Width; j++)
                {
                    switch (this.celdas[j,i].cell.GetStatus())
                    {
                        case Celda.Status.SHOWN:
                            if (this.celdas[j,i].cell is Mina)
                            {
                                printingValue = this.mineSymbol.ToString();
                            }
                            else
                            {
                                printingValue = "" + this.celdas[j,i].cell.GetValue(); //con el .cell esta llamandolo desde cellnode
                            }
                            break;
                        case Celda.Status.FLAG:
                            printingValue = "" + this.flagSymbol;
                            break;
                        default:
                            printingValue = "" + this.hiddenSymbol;
                            break;
                    }
                    Console.Write(printingValue + " ");
                }
                Console.WriteLine();
            }
            Console.Write("COORDENADA: ");
            this.coordenada = Console.ReadLine();
            BUSCAAR(coordenada);
        }
            
    }


}
