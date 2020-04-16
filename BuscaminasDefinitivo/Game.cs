using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaminasDefinitivo
{
    class Game<T> where T : ICell, new()
    {
        protected int tiempo;
        protected int TotalMinas;

        protected int FlagCounter;
        protected int MineCounter;

        protected int Width;
        protected int Height;
        protected CellNode[,] celdas;

        List<int> minass = new List<int>();
        //int n = 0;
        //static int m = this.n;
        public int[,] minasss = new int[10, 2];      

        protected int definitivo;
        public int lugar;


        public Game(int Widht, int Height, int minas)
        {
            this.Width = Widht;
            this.Height = Height;
            this.TotalMinas = minas;
            //this.n = this.TotalMinas;
            //int[,] minasss = new int[this.TotalMinas, 2]; //////USARRRRRRR, ¿Cómo lo puedo hacer que sea un atributo de la clase?

            this.celdas = new CellNode[Widht, Height];
            for (uint i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    this.celdas[i, j] = new CellNode(new T()); //llama al constructor de NodeCell, pasandole newT
                } //crea objetos tipo CellNode
            }

            this.GenerateMines();
            //this.GenerateMinesTarea();
            this.CambiarCoordenadas();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < this.TotalMinas; j++)
                {
                    Console.Write("{0}, ", minasss[j, i]); //j es x e i es y
                }
            }
        }

        public void GenerateMines()
        {
            Random random = new Random();
            List<CellNode> list = new List<CellNode>(); //Guarda todas las posiciones celdas que ya se generaron en una lista
            for (uint i = 0; i < this.Width; i++) //Aqui solo las va agregando
            {
                for (uint j = 0; j < this.Height; j++)
                {
                    list.Add(this.celdas[i, j]);
                }
            } //YA tiene una lista del tamaño de la cantidad de posiciones que hay
            int pos;
            for (uint i = 0; i < this.TotalMinas; i++)
            {
                pos = random.Next(0, list.Count); //Genera un numero aleatorio teniendo limite el tamaño de la lista
                list[pos].cell = new Mina(); //en esa posicion crea/pone una mina
                list.RemoveAt(pos); //quita esa posicion de la lista para que no se vuelva a elegir
                minass.Add(pos); //AQUI CON POS LE VOY A LLAMAR A LA FUNCIONA PARA QUE LO PONGA EN EL ARREGLO, not jajajaj
                //AgregarListaMina(pos);
            }
            this.CambiarCoordenadas();
            for (int i = 0; i < this.TotalMinas; i++)
            {
                Console.Write("MINA {0}:  ", i + 1);
                for (int j = 0; j < 2; j++)
                {

                    Console.Write("{0}, ", minasss[i, j]); //j es x e i es y
                }
                Console.WriteLine(" ");
            }

        }

        public void AgregarListaMina(int pos)
        {
            minass.Add(pos);
        }

        public void CambiarCoordenadas() //se puede mejorar mucho más
        {
            for (int k = 0; k < minass.Count; k++)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < this.Width; j++) //this.height oir wide
                    {
                        //j es x e i es y
                        ////x/////
                        double op = minass[k] / this.Height; //Mejorar esto
                        if (op <= 1)
                            minasss[j, 0] = 3; 
                        if (op > 1 && op <= 2)
                            minasss[j, 0] = 4;
                        if (op > 2 && op <= 3)
                            minasss[j, 0] = 5;
                        if (op > 3 && op <= 4)
                            minasss[j, 0] = 6;
                        if (op > 4 && op <= 5)
                            minasss[j, 0] = 7;
                        if (op > 5 && op <= 6)
                            minasss[j, 0] = 8;

                        if (minass[k] == 0 || minass[k] == 7 || minass[k] == 14 || minass[k] == 21 || minass[k] == 28 || minass[k] == 35)
                            minasss[j, 1] = 3;
                        if (minass[k] == 1 || minass[k] == 8 || minass[k] == 15 || minass[k] == 22 || minass[k] == 29 || minass[k] == 36)
                            minasss[j, 1] = 4;
                        if (minass[k] == 2 || minass[k] == 9 || minass[k] == 16 || minass[k] == 23 || minass[k] == 30 || minass[k] == 37)
                            minasss[j, 1] = 5;
                        if (minass[k] == 3 || minass[k] == 10 || minass[k] == 17 || minass[k] == 24 || minass[k] == 31 || minass[k] == 38)
                            minasss[j, 1] = 6;
                        if (minass[k] == 4 || minass[k] == 11 || minass[k] == 18 || minass[k] == 25 || minass[k] == 32 || minass[k] == 39)
                            minasss[j, 1] = 7;
                        if (minass[k] == 5 || minass[k] == 12 || minass[k] == 19 || minass[k] == 26 || minass[k] == 33 || minass[k] == 40)
                            minasss[j, 1] = 8;
                        if (minass[k] == 6 || minass[k] == 13 || minass[k] == 20 || minass[k] == 27 || minass[k] == 34 || minass[k] == 41)
                            minasss[j, 1] = 9;
                    }
                }
            }


        }


        //public void BUSCAAR(string coordenada)
        //{
        //    switch (coordenada)
        //    {
        //        case "A1":
        //            this.lugar = 0;
        //            break;
        //        case "A2":
        //            this.lugar = 1;
        //            break;
        //        case "A3":
        //            this.lugar = 2;
        //            break;
        //        case "A4":
        //            this.lugar = 3;
        //            break;
        //        case "A5":
        //            this.lugar = 4;
        //            break;
        //        case "A6":
        //            this.lugar = 5;
        //            break;
        //        case "A7":
        //            this.lugar = 6;
        //            break;
        //        case "B1":
        //            this.lugar = 7;
        //            break;
        //        case "B2":
        //            this.lugar = 8;
        //            break;
        //        case "B3":
        //            this.lugar = 9;
        //            break;
        //        case "B4":
        //            this.lugar = 10;
        //            break;
        //        case "B5":
        //            this.lugar = 11;
        //            break;
        //        case "B6":
        //            this.lugar = 12;
        //            break;
        //        case "B7":
        //            this.lugar = 13;
        //            break;
        //        case "C1":
        //            this.lugar = 14;
        //            break;
        //        case "C2":
        //            this.lugar = 15;
        //            break;
        //        case "C":
        //            this.lugar = 16;
        //            break;
        //        case "C4":
        //            this.lugar = 17;
        //            break;
        //        case "C5":
        //            this.lugar = 18;
        //            break;
        //        case "C6":
        //            this.lugar = 19;
        //            break;
        //        case "C7":
        //            this.lugar = 20;
        //            break;
        //        case "D1":
        //            this.lugar = 21;
        //            break;
        //        case "D2":
        //            this.lugar = 22;
        //            break;
        //        case "D3":
        //            this.lugar = 23;
        //            break;
        //        case "D4":
        //            this.lugar = 24;
        //            break;
        //        case "D5":
        //            this.lugar = 25;
        //            break;
        //        case "D6":
        //            this.lugar = 26;
        //            break;
        //        case "D7":
        //            this.lugar = 27;
        //            break;
        //        case "E1":
        //            this.lugar = 28;
        //            break;
        //        case "E2":
        //            this.lugar = 29;
        //            break;
        //        case "E3":
        //            this.lugar = 30;
        //            break;
        //        case "E4":
        //            this.lugar = 31;
        //            break;
        //        case "E5":
        //            this.lugar = 32;
        //            break;
        //        case "E6":
        //            this.lugar = 33;
        //            break;
        //        case "E7":
        //            this.lugar = 34;
        //            break;
        //        case "F1":
        //            this.lugar = 35;
        //            break;
        //        case "F2":
        //            this.lugar = 36;
        //            break;
        //        case "F3":
        //            this.lugar = 37;
        //            break;
        //        case "F4":
        //            this.lugar = 38;
        //            break;
        //        case "F5":
        //            this.lugar = 39;
        //            break;
        //        case "F6":
        //            this.lugar = 40;
        //            break;
        //        case "F7":
        //            this.lugar = 41;
        //            break;
        //        default:
        //            break;
        //    }

        //    List<CellNode> list = new List<CellNode>();
        //    for (int i = 0; i < this.Width; i++)
        //    {
        //        for (int j = 0; j < this.Height; j++)
        //        {
        //            list.Add(this.celdas[i, j]);
        //        }
        //    }

        //    for (int i = 0; i < minas.Count; i++)
        //    {
        //        if (this.lugar == minas[i])
        //        {
        //            Console.WriteLine("PERDISTE");
        //        }
        //        if (this.lugar != minas[i])
        //        {
        //            list[this.lugar].cell.GetStatus();
        //        }
        //    }


        //}



        //public void GenerateMinesTarea()
        //{
        //    Random random = new Random();
        //    int[] temporal = { 0, 0 };
        //    for (int i = 0; i < this.TotalMinas; i++)
        //    {
        //        int x = random.Next(0, this.Width);
        //        int y = random.Next(0, this.Height);
        //        int[] aleatorio = { x, y };
        //        if (temporal == aleatorio)
        //        {
        //            //this.TotalMinas += 1;
        //            //GenerateMinesTarea();
        //            x = random.Next(0, i+1);
        //            y = random.Next(0, this.Height-i);
        //            aleatorio[0] = x; aleatorio[1] = y;
        //            this.celdas[x, y].cell = new Mina();
        //        }
        //        else
        //        {
        //            this.celdas[x, y].cell = new Mina();
        //        }
        //        temporal = aleatorio;
        //    }
        //}

    }
}