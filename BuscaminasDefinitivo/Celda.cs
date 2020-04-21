using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaminasDefinitivo
{
    class Celda : ICell
    {
        public enum Status //al principio
        {
            HIDDEN,
            SHOWN,
            FLAG,
        }

        private int posX;
        private int posY;
        private int valor;
        private Status estado;

        public Celda()
        {
            this.estado = Status.HIDDEN; //Para el principio
        }

        public int GetValue()
        {
            return this.valor;
        }

        public bool IsHidden()
        {
            throw new NotImplementedException();
        }

        public void LeftClick()
        {
            this.estado = Status.SHOWN;
  
        }

        public void RightClick()
        {
            this.estado = Status.FLAG;
        }

        public Status GetStatus()
        {
            return this.estado;
        }

        public void Endgame()
        {
            this.estado = Celda.Status.SHOWN;
        }

    }
}