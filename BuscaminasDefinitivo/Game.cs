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


        public Game(int Widht, int Height, int minas)
        {
            this.Width = Widht;
            this.Height = Height;
            this.TotalMinas = minas;

            this.celdas = new CellNode[Widht, Height];
            for (uint i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    this.celdas[i, j] = new CellNode(new T()); //llama al constructor de NodeCell, pasandole newT
                } //crea objetos tipo CellNode
            }

            //this.GenerateMines();
            this.GenerateMinesTarea();
        }

        public void GenerateMines()
        {
            Random random = new Random();
            List<CellNode> list = new List<CellNode>(); //Guarda todas las posiciones celdas que ya se generaron en una lista
            for (uint i = 0; i < this.Width; i++) //Aqui solo las va agregando
            {
                for (uint j = 0; j < this.Height; j++)
                {
                    list.Add(this.celdas[i,j]);
                }
            } //YA tiene una lista del tamaño de la cantidad de posiciones que hay
            int pos;
            for (uint i = 0; i < this.TotalMinas; i++)
            {
                pos = random.Next(0, list.Count); //Genera un numero aleatorio teniendo limite el tamaño de la lista
                list[pos].cell = new Mina(); //en esa posicion crea/pone una mina
                list.RemoveAt(pos); //quita esa posicion de la lista para que no se vuelva a elegir
            }
        }

        public void GenerateMinesTarea()
        {
            Random random = new Random();
            int[] temporal = { 0, 0 };
            for (int i = 0; i < this.TotalMinas; i++)
            {
                int x = random.Next(0, this.Width);
                int y = random.Next(0, this.Height);
                int[] aleatorio = { x, y };
                if (temporal == aleatorio)
                {
                    //this.TotalMinas += 1;
                    //GenerateMinesTarea();
                    x = random.Next(0, i+1);
                    y = random.Next(0, this.Height-i);
                    aleatorio[0] = x; aleatorio[1] = y;
                    this.celdas[x, y].cell = new Mina();
                }
                else
                {
                    this.celdas[x, y].cell = new Mina();
                }
                temporal = aleatorio;
            }
        }

    }
}