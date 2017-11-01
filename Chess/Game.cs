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
        public static bool Pause = false;
        public static ChessPiece SelectedPiece { get; set; }
        public static ChessPiece.Team Player { get; set; }
        private Board Board { get; set; }
        public static TableLayoutPanel MainPanel { get; set; }
        public static TableLayoutPanel PromoteMenu { get; set; }
        public static List<string> HighLightList
        {
            get
            {
                return Movement.GetAvaliable(SelectedPiece);
            }
        }
        public static FlowLayoutPanel CapturedPieces { get; set; }

        public Game(Board board, TableLayoutPanel mainPanel)
        {
            Board = board;
            MainPanel = mainPanel;
            Player = ChessPiece.Team.White;
            PromoteMenu = GeneratePromoteMenu();
            MainPanel.Controls.Add(PromoteMenu, 2, 2);
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

        public static void CreateCapturedPiece(PictureBox p)
        {
            PictureBox image = new PictureBox
            {
                Size = new Size(Board.Square["A1"].Panel.Width / 2, Board.Square["A1"].Panel.Height / 2),

                BackColor = Color.Transparent,
                ImageLocation = p.ImageLocation,
                SizeMode = PictureBoxSizeMode.StretchImage

            };

            CapturedPieces.Controls.Add(image);
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

        private static TableLayoutPanel GeneratePromoteMenu()
        {
            TableLayoutPanel result = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 2,
                Dock = DockStyle.Fill,
            };

            result.Controls.Add(new PictureBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Name = "Rook"
            });
            result.Controls.Add(new PictureBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Name = "Queen"
            });
            result.Controls.Add(new PictureBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Name = "Knight"
            });
            result.Controls.Add(new PictureBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Name = "Bishop"
            });
            result.Visible = false;
            foreach(Control c in result.Controls)
            {
                c.Click += EventHandler.PieceSelectEvent;
            }
            return result;
        }
    }
}
