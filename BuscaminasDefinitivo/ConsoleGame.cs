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

        public int x = 0;
        public int y = 0;
        int[,] coordenadas = new int[1,2]; 

        public ConsoleGame(int Widht, int Height, int minas) : base(Widht, Height, minas)
        {
            this.hiddenSymbol = (char)9632;
            this.mineSymbol = '*';
            this.flagSymbol = '#';
            Console.Clear();
            this.Showgrid();
        }

        public void Showgrid()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', Console.WindowWidth * 3));
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Minas restantes : {0}", this.FlagCounter);
            Console.Write((" ").PadLeft(4));
            for (int i = 0; i < Width; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write((char)(65 + i) + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            string printingValue;
            for (uint i = 0; i < this.Height; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(((i + 1) + " ").PadLeft(4));
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < this.Width; j++)
                {
                    switch (this.celdas[j, i].cell.GetStatus())
                    {
                        case Celda.Status.SHOWN:
                            if (this.celdas[j, i].cell is Mina)
                            {
                                printingValue = this.mineSymbol.ToString();
                            }
                            else
                            {
                                printingValue = "" + this.celdas[j, i].cell.GetValue(); //valor de cuando estan  erca las minas
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
                //Console.Write("COORDENADA: ");
                //this.coordenada = Console.ReadLine();
                //BUSCAAR(coordenada);
            }
            if (gameover == false && wingame == false)
            {
                this.IngresarCoordenada();
                Showgrid();
            }
            if (gameover == true)
            {
                Console.WriteLine("*****PERDISTE*****");
            }
            if (wingame == true)
            {
                Console.WriteLine("*****GANASTE*****");
            }

        }

        public void IngresarCoordenada()
        {
            int[] arr = new int[this.Width];
            for (int i = 0; i < this.Width; i++)
            {
                arr[i] = i; 
            }
            bool bandera = true;
            bool banderita = false;
            string resp;
            do
            {
                do
                {
                    Console.Write("¿Desea colocar bandera?: (S/N): ");
                    resp = Console.ReadLine().ToUpper();
                    if (resp == "S")
                    {
                        banderita = true;
                        this.FlagCounter = FlagCounter - 1;
                    }
                    if (resp != "S" && resp != "N")
                    {
                        Console.WriteLine("Valor incorrecto.");

                    }
                } while (resp != "S" && resp != "N");
                Console.Write("COLUMNA (LETRA): ");

                string entrada = Console.ReadLine().ToUpper();
                int indice = (int)entrada[0] - 65; 

                if (indice < arr.Length)
                {
                    this.x = arr[indice];
                    Console.Write("FILA (NÚMERO): ");
                    int fila = int.Parse(Console.ReadLine());
                    if (fila <= this.Height && fila > 0) 
                    {
                        this.y = fila - 1 ; 
                        bandera = false; //AL FINAL DE CONDICION
                    }
                    else
                    {
                        Console.WriteLine("Número incorrecto.");
                    }
                }
                else
                {
                    Console.WriteLine("Letra incorrecta.");
                }
            } while (bandera == true);
            this.coordenadas[0, 0] = this.x;
            this.coordenadas[0, 1] = this.y; 
            if (banderita == false)
            {
                Accion(this.x, this.y); 
            }
            if (banderita == true)
            {
                Accion2(this.x, this.y); 
            }
        }

       

    }


}
