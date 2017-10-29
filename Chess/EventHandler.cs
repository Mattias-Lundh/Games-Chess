using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    class EventHandler
    {
        private static Point MouseLocation { get; set; }
        public static PictureBox MouseCursor { get; set; }
        private static BoardSquare TargetSquare { get; set; }
        private static Timer MouseisDown { get; set; }
        private static bool AttemptedMove { get; set; }

        public static void PieceMouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
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

        private static void FollowMouse(ChessPiece piece)
        {
            MouseisDown = new Timer();
            MouseisDown.Start();
            MouseisDown.Tick += MovingWhileLeftHold;
            MouseisDown.Disposed += UnfollowMouse;
            MouseCursor.ImageLocation = piece.Graphic.ImageLocation;
            MouseCursor.Visible = true;
            MouseCursor.Size = Board.Square[piece.Address].Panel.Size;
        }

        private static void MovingWhileLeftHold(object sender, EventArgs e)
        {
            MouseCursor.Location = MouseLocation;
        }

        internal static void BoardMouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (sender.GetType().ToString() == "System.Windows.Forms.Panel")
            {
                Panel p = (Panel)sender;
                TargetSquare = BoardSquare.Find[p];
                MouseLocation = new Point(e.Location.X + p.Location.X, e.Location.Y + p.Location.Y);
            }
            if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                PictureBox pb = (PictureBox)sender;
                if (ChessPiece.Find[pb].Address != "captured")
                {
                    TargetSquare = Board.Square[ChessPiece.Find[pb].Address];
                    Panel p = Board.Square[ChessPiece.Find[pb].Address].Panel;
                    MouseLocation = new Point(e.Location.X + p.Location.X - MouseCursor.Size.Width / 2, e.Location.Y + p.Location.Y - MouseCursor.Size.Height / 2);
                }
            }
        }

        private static void UnfollowMouse(object sender, EventArgs e)
        {
            MouseCursor.Visible = false;
            UnHighlightSquares();
        }

        private static void HighlightSquares()
        {
            foreach (string address in Game.HighLightList)
            {
                Board.Square[address].Panel.BackColor = Color.GreenYellow;
            }
            Board.Square[Game.SelectedPiece.Address].Panel.BackColor = Color.ForestGreen;

        }

        internal static void PieceMouseUpEvent(object sender, MouseEventArgs e)
        {
            MouseisDown.Dispose();
            AttemptedMove = true;
        }

        private static void UnHighlightSquares()
        {
            foreach (string address in Game.HighLightList)
            {
                Board.Square[address].Panel.BackColor = Board.Square[address].FillColor;
            }
            Board.Square[Game.SelectedPiece.Address].Panel.BackColor = Board.Square[Game.SelectedPiece.Address].FillColor;
        }

        internal static void SquareMouseEnterEvent(object sender, EventArgs e)
        {
            if (sender.GetType().ToString() == "System.Windows.Forms.Panel")
            {
                Panel p = (Panel)sender;
                TargetSquare = BoardSquare.Find[p];
            }
            if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                PictureBox pb = (PictureBox)sender;
                TargetSquare = Board.Square[ChessPiece.Find[pb].Address];
            }
            if (AttemptedMove)
            {
                Move();
                AttemptedMove = false;
            }
        }

        private static void Move()
        {
            foreach (string address in Movement.GetAvaliable(Game.SelectedPiece))
            {
                if (TargetSquare.Address == address)
                {                    
                    Movement.Action(Game.SelectedPiece, TargetSquare.Address);
                }
            }
        }
    }
}
