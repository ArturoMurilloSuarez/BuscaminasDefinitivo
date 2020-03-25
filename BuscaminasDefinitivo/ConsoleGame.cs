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

        public ConsoleGame(int Widht, int Height, int minas) : base(Widht, Height, minas)
        {
            this.hiddenSymbol = (char)9632;
            this.mineSymbol = '*';
            this.flagSymbol = '#';
            this.Showgrid();
        }

        public void Showgrid()
        {
            Console.Write((" ").PadLeft(4));
            for (int i = 0; i < Width; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write((char)(65+i)+ " ");
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
        }
            
    }


}
