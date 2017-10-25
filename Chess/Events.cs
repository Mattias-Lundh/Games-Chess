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
        public static PictureBox PieceGraphic = new PictureBox { };
        public static ChessPiece SelectedPiece { get; set; }
        public static BoardSquare Square = new BoardSquare { };
        private static Timer mousedownTimer = new Timer { };

        public static void PieceMouseDownEvent(object sender, MouseEventArgs e)
        {
            mousedownTimer.Start();
            mousedownTimer.Disposed += PieceMoveAttempt;
            PieceGraphic = (PictureBox)sender;
            PieceGraphic.MouseMove += MouseMoveWithPiece;
            foreach(ChessPiece piece in ChessPiece.Set)
            {
                if (piece.Graphic.Equals(PieceGraphic))
                {
                    SelectedPiece = piece;
                }

            }
            Square = Board.Square[SelectedPiece.Address];
            HighlightMoves();                       
        }

        private static void HighlightMoves()
        {
            foreach (string address in Movement.GetAvaliable(SelectedPiece))
            {
                Board.Square[address].Panel.BackColor = Color.MediumBlue;
            }
        }

        private static void UnHighlightMoves()
        {
            foreach (string address in Movement.GetAvaliable(SelectedPiece))
            {
                Board.Square[address].Panel.BackColor = Board.Square[address].FillColor;
            }
        }

        private static void MouseMoveWithPiece(object sender, MouseEventArgs e)
        {
            PieceGraphic.Location = new Point(e.X, e.Y);   
        }

        private static void PieceMoveAttempt(object sender, EventArgs e)
        {
            PieceGraphic.MouseMove -= MouseMoveWithPiece;
            Panel panel = (Panel)sender;
            if (panel.BackColor == Color.MediumBlue)
            {

                Movement.Place(SelectedPiece, "A1");
            }
            else
            {
                Movement.Place(SelectedPiece, SelectedPiece.Address);
            }

        }

        public static void PieceClickEvent(object sender, EventArgs e)
        {

        }

        public static void SquareMouseUpEvent(object sender, MouseEventArgs e)
        {
            //Square = (Panel)sender;
            mousedownTimer.Dispose();
        }
    }
}
