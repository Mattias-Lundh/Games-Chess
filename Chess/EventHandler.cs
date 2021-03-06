﻿using System;
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
        public static PictureBox MouseCursor { get; set; }
        private static Point MouseLocation { get; set; }
        private static BoardSquare TargetSquare { get; set; }
        private static Timer MouseisDown { get; set; }
        private static bool AttemptedMove { get; set; }
        private static Timer SloppyBugFix { get; set; }

        internal static void WindowSizeChangedEvent(object sender, EventArgs e)
        {
            foreach (Control c in Game.CapturedPieces.Controls)
            {
                PictureBox image = (PictureBox)c;
                image.Size = new Size(Board.Square["A1"].Panel.Width / 2, Board.Square["A1"].Panel.Height / 2);
            }
        }

        public static void PieceMouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !Game.Pause)
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
            if (!Game.Pause)
            {
                if (Game.SelectedPiece != null && Game.SelectedPiece.Player == Game.Player) { UnHighlightSquares(); }
                PictureBox picturebox = (PictureBox)sender;
                Game.SelectedPiece = ChessPiece.Find[picturebox];
                if (Game.Player == Game.SelectedPiece.Player)
                {
                    HighlightSquares();
                }
            }
        }

        private static void FollowMouse(ChessPiece piece)
        {
            MouseisDown = new Timer();
            MouseisDown.Start();
            MouseisDown.Tick += MovingWhileLeftHold;
            MouseisDown.Disposed += UnfollowMouse;
            MouseCursor.ImageLocation = piece.Graphic.ImageLocation;
            MouseCursor.Location = MouseLocation;
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
            if (!Game.Pause)
            {
                if (Game.SelectedPiece.Player == Game.Player)
                {
                    MouseisDown.Dispose();
                    AttemptedMove = true;
                    SloppyBugFix = new Timer();
                    SloppyBugFix.Tick += Fix;
                    SloppyBugFix.Interval = 5;
                    SloppyBugFix.Start();
                }
            }
        }

        private static void Fix(object sender, EventArgs e)
        {
            AttemptedMove = false;
            SloppyBugFix.Dispose();
        }

        internal static void PieceSelectEvent(object sender, EventArgs e)
        {
            if (Game.Pause)
            {
                PictureBox selected = (PictureBox)sender;
                switch (selected.Name)
                {
                    case "Rook":
                        Game.SelectedPiece.Type = ChessPiece.Piece.Rook;
                        if (Game.SelectedPiece.Player == ChessPiece.Team.Black)
                        {
                            Game.SelectedPiece.Graphic.ImageLocation = @"Graphics\RookBlack.png";
                        }
                        else
                        {
                            Game.SelectedPiece.Graphic.ImageLocation = @"Graphics\RookWhite.png";
                        }

                        break;
                    case "Queen":
                        Game.SelectedPiece.Type = ChessPiece.Piece.Queen;
                        if (Game.SelectedPiece.Player == ChessPiece.Team.Black)
                        {
                            Game.SelectedPiece.Graphic.ImageLocation = @"Graphics\QueenBlack.png";
                        }
                        else
                        {
                            Game.SelectedPiece.Graphic.ImageLocation = @"Graphics\QueenWhite.png";
                        }
                        break;
                    case "Knight":
                        Game.SelectedPiece.Type = ChessPiece.Piece.Knight;
                        if (Game.SelectedPiece.Player == ChessPiece.Team.Black)
                        {
                            Game.SelectedPiece.Graphic.ImageLocation = @"Graphics\KnightBlack.png";

                        }
                        else
                        {
                            Game.SelectedPiece.Graphic.ImageLocation = @"Graphics\KnightWhite.png";
                        }
                        break;
                    case "Bishop":
                        Game.SelectedPiece.Type = ChessPiece.Piece.Bishop;
                        if (Game.SelectedPiece.Player == ChessPiece.Team.Black)
                        {
                            Game.SelectedPiece.Graphic.ImageLocation = @"Graphics\BishopBlack.png";

                        }
                        else
                        {
                            Game.SelectedPiece.Graphic.ImageLocation = @"Graphics\BishopWhite.png";
                        }
                        break;
                }
                Game.Pause = false;
                Game.PromoteMenu.Visible = false;
            }
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
                AttemptedMove = false;
                Move();
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
