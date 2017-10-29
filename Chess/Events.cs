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
            if (Game.SelectedPiece != null && Game.SelectedPiece.Player == Game.Player) { UnHighlightSquares(); }
            PictureBox picturebox = (PictureBox)sender;
            Game.SelectedPiece = ChessPiece.Find[picturebox];
            if (Game.Player == Game.SelectedPiece.Player)
            {
                FollowMouse(Game.SelectedPiece);
                HighlightSquares();
            }
        }
        
        public static void PieceClickEvent(object sender, EventArgs e)
        {
            if (Game.SelectedPiece != null && Game.SelectedPiece.Player == Game.Player) { UnHighlightSquares(); }
            PictureBox picturebox = (PictureBox)sender;
            Game.SelectedPiece = ChessPiece.Find[picturebox];
            if (Game.Player == Game.SelectedPiece.Player)
            {
                HighlightSquares();
            }
        }        

        public static void SquareMouseUpEvent(object sender, MouseEventArgs e)
        {

        }

        private static void FollowMouse(ChessPiece piece)
        {
            piece.Graphic.Visible = false;
            PictureBox graphic = new PictureBox
            {
                ImageLocation = piece.Graphic.ImageLocation,
            };
        }

        private static void HighlightSquares()
        {
            foreach (string address in Game.HighLightList)
            {
                Board.Square[address].Panel.BackColor = Color.GreenYellow;
            }
            Board.Square[Game.SelectedPiece.Address].Panel.BackColor = Color.ForestGreen;

        }
        private static void UnHighlightSquares()
        {
            foreach (string address in Game.HighLightList)
            {
                Board.Square[address].Panel.BackColor = Board.Square[address].FillColor;
            }
            Board.Square[Game.SelectedPiece.Address].Panel.BackColor = Board.Square[Game.SelectedPiece.Address].FillColor;
        }
    }
}
