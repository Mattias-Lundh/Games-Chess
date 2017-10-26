using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    class Events
    {
        public static void PieceMouseDownEvent(object sender, MouseEventArgs e)
        {            
            if (Game.SelectedPiece != null) { UnHighlightSquares(); }
            PictureBox picturebox = (PictureBox)sender;
            Game.SelectedPiece = ChessPiece.Find[picturebox];
            HighlightSquares();
        }

        public static void PieceClickEvent(object sender, EventArgs e)
        {
            if (Game.SelectedPiece != null) { UnHighlightSquares(); }
            PictureBox picturebox = (PictureBox)sender;
            Game.SelectedPiece = ChessPiece.Find[picturebox];
            HighlightSquares();
        }

        public static void SquareMouseUpEvent(object sender, MouseEventArgs e)
        {
           
        }

        private static void HighlightSquares()
        {
            foreach (string address in Game.HighLightList)
            {
                Board.Square[address].Panel.BackColor = Color.MediumBlue;
            }

        }
        private static void UnHighlightSquares()
        {
            foreach (string address in Game.HighLightList)
            {
                Board.Square[address].Panel.BackColor = Board.Square[address].FillColor;
            }
        }
    }
}
