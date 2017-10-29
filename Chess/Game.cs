using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Chess
{
    class Game
    {
        public static ChessPiece SelectedPiece { get; set; }
        public static ChessPiece.Team Player { get; set; }
        private Board Board { get; set; }
        public static List<string> HighLightList
        {
            get
            {
                return Movement.GetAvaliable(SelectedPiece);
            }
        }
        public static FlowLayoutPanel CapturedPieces { get; set; }

        public Game(Board board)
        {
            Board = board;
            Player = ChessPiece.Team.White;
            CapturedPieces = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0)
            };
        }

        public static void TogglePlayer()
        {
            if (Player == ChessPiece.Team.White)
            {
                Player = ChessPiece.Team.Black;
            }
            else
            {
                Player = ChessPiece.Team.White;
            }
        }
        public void StartGame()
        {
            SetBoard();
        }

        private void SetBoard()
        {
            ChessPiece.Set.Clear();
            ChessPiece.CreateSet();
            foreach (ChessPiece piece in ChessPiece.Set)
            {
                Movement.Place(piece, piece.Address);
                ChessPiece.Find.Add(piece.Graphic, piece);
                piece.Graphic.MouseEnter += EventHandler.SquareMouseEnterEvent;
            }

            foreach (KeyValuePair<string, BoardSquare> key in Board.Square)
            {
                BoardSquare square = Board.Square[key.ToString().Substring(1, 2)];
                if (square.Piece != null)
                {
                    square.Piece.Graphic.MouseDown += EventHandler.PieceMouseDownEvent;
                    square.Piece.Graphic.Click += EventHandler.PieceClickEvent;
                    square.Piece.Graphic.MouseUp += EventHandler.PieceMouseUpEvent;
                    square.Piece.Graphic.MouseMove += EventHandler.BoardMouseMoveEvent;
                    square.Piece.Graphic.MouseHover += EventHandler.SquareMouseEnterEvent;

                }
            }

        }
    }
}
