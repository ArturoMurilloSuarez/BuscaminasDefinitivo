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
       // private Celda.Status estado1;


        public Mina()
        {
            this.estado = Celda.Status.HIDDEN;
          //  this.estado1 = Celda.Status.SHOWN;////Para el principio
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
            throw new Exception("Una accion para que detecte que ya acabo el juego");
        }

        public void RightClick()
        {

        }
        public Celda.Status GetStatus()
        {
            return this.estado;
        }
        /*public Celda.Status GetStatus1()
        {
            return this.estado1;
        }*/

    }
}