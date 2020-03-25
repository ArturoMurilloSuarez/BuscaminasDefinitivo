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

        private int valor;
        private int posX;
        private int posY;
        private Status estado;

        public Celda()
        {
            this.estado = Status.SHOWN; ////Para el principio
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
            throw new NotImplementedException();
        }

        public void RightClick()
        {
            throw new NotImplementedException();
        }

        public Status GetStatus()
        {
            return this.estado;
        }

    }
}