using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    class BoardSquare
    {
        public Panel Panel { get; set; }
        public string Address { get; set; }
        public ChessPiece Piece { get; set; }

        public BoardSquare()
        {           

        }
    }
}
