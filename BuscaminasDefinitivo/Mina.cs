using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaminasDefinitivo
{
    class Mina : ICell
    {
        private int posX;
        private int posY;
        private Celda.Status estado;




        public Mina()
        {
            this.estado = Celda.Status.SHOWN; ////Para el principio
        }

        public int GetValue()
        {
            return 0;
        }

        public bool IsHidden()
        {
            return false;
        }

        public void LeftClick()
        {
        }

        public void RightClick()
        {

        }
        public Celda.Status GetStatus()
        {
            return this.estado;
        }

    }
}