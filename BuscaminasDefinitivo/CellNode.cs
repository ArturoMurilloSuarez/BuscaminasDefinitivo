using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaminasDefinitivo
{
    class CellNode
    {
        public ICell cell;
        public CellNode(ICell pCell)
        {
            this.cell = pCell;
        }
    }
}
