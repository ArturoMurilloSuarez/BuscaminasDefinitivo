using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaminasDefinitivo
{
    class Game<T> where T : ICell, new()
    {
        protected int TotalMinas;

        protected int FlagCounter;
        protected int MineCounter;

        protected int Width;
        protected int Height;
        public CellNode[,] celdas; //arreglo sin iniciar tamaño, ojo.

        public List<int> minaspos = new List<int>();

        public bool gameover = false;
        public bool wingame = false;

        public Game(int Widht, int Height, int minas)
        {
            this.Width = Widht;
            this.Height = Height;
            this.TotalMinas = minas;
            this.FlagCounter = minas;
            this.MineCounter = minas;

            this.celdas = new CellNode[Widht, Height]; //matriz que contiene nuestras celdas y nuestras minas CON ESTA TRABAJAR LAS COORDENADAS
            for (uint i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    this.celdas[i, j] = new CellNode(new T()); //llama al constructor de NodeCell, pasandole newT
                } //crea objetos tipo CellNode
            }

            this.GenerateMines();

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
                this.minaspos.Add(pos); //No puedo trabajar con esa lista porque su numeracion cambia con cada iteracion
            }
        }

        public void Accion(int x, int y)
        {
            if (this.celdas[x, y].cell is Mina )
            {
                for (uint i = 0; i < this.Width; i++) 
                {
                    for (uint j = 0; j < this.Height; j++) //POner en leftclick
                    {
                        celdas[i, j].cell.Endgame();
                    }
                }
                gameover = true;
                //this.celdas[x, y].cell.LeftClick();
            }
            if (this.celdas[x, y].cell is Celda)
            {
                this.celdas[x, y].cell.LeftClick(); //Falta programar eso
            }          
        }

        public void Accion2(int x, int y)
        {
            if (this.celdas[x, y].cell is Mina)
            {
                this.celdas[x, y].cell.RightClick();
                this.MineCounter = this.MineCounter - 1 ;
                if (this.MineCounter == 0)
                {
                    wingame = true;
                    for (uint i = 0; i < this.Width; i++)
                    {
                        for (uint j = 0; j < this.Height; j++) //POner en leftclick
                        {
                            celdas[i, j].cell.Endgame();
                        }
                    }
                    
                }

            }
            if (this.celdas[x, y].cell is Celda)
            {
                this.celdas[x, y].cell.RightClick();
            }
        }





    }
}