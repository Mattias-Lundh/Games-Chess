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
    class ChessPiece
    {
        public enum Team { Black, White }
        public enum Piece { Pawn, Rook, Knight, Bishop, Queen, King }

        public static List<ChessPiece> Set { get; set; } = new List<ChessPiece> { };
        private PictureBox graphic;
        public PictureBox Graphic
        {
            get
            {
                graphic.ImageLocation = ImagePath;
                return graphic;
            }
            set { graphic = value; }
        }
        public Team Player { get; set; }
        public Piece Type { get; set; }
        private string ImagePath
        {
            get
            {
                if (Player == Team.Black)
                {
                    if (Type == Piece.Rook)
                    {
                        return @"C:\Users\Mattias\Desktop\C#\Project\Chess\Images\Chess pieces\RookBlack.png";
                    }
                    if (Type == Piece.Knight)
                    {
                        return @"C:\Users\Mattias\Desktop\C#\Project\Chess\Images\Chess pieces\KnightBlack.png";
                    }
                    if (Type == Piece.Bishop)
                    {
                        return @"C:\Users\Mattias\Desktop\C#\Project\Chess\Images\Chess pieces\BishopBlack.png";
                    }
                    if (Type == Piece.Queen)
                    {
                        return @"C:\Users\Mattias\Desktop\C#\Project\Chess\Images\Chess pieces\QueenBlack.png";
                    }
                    if (Type == Piece.King)
                    {
                        return @"C:\Users\Mattias\Desktop\C#\Project\Chess\Images\Chess pieces\KingBlack.png";
                    }
                    if (Type == Piece.Pawn)
                    {
                        return @"C:\Users\Mattias\Desktop\C#\Project\Chess\Images\Chess pieces\PawnBlack.png";
                    }
                }
                else
                {
                    if (Type == Piece.Rook)
                    {
                        return @"C:\Users\Mattias\Desktop\C#\Project\Chess\Images\Chess pieces\RookWhite.png";
                    }
                    if (Type == Piece.Knight)
                    {
                        return @"C:\Users\Mattias\Desktop\C#\Project\Chess\Images\Chess pieces\KnightWhite.png";
                    }
                    if (Type == Piece.Bishop)
                    {
                        return @"C:\Users\Mattias\Desktop\C#\Project\Chess\Images\Chess pieces\BishopWhite.png";
                    }
                    if (Type == Piece.Queen)
                    {
                        return @"C:\Users\Mattias\Desktop\C#\Project\Chess\Images\Chess pieces\QueenWhite.png";
                    }
                    if (Type == Piece.King)
                    {
                        return @"C:\Users\Mattias\Desktop\C#\Project\Chess\Images\Chess pieces\KingWhite.png";
                    }
                    if (Type == Piece.Pawn)
                    {
                        return @"C:\Users\Mattias\Desktop\C#\Project\Chess\Images\Chess pieces\PawnWhite.png";
                    }
                }
                return "somthing went wrong";
            }
        }

        ChessPiece()
        {

        }

        public static void CreateSet()
        {
            Set.AddRange(new List<ChessPiece>
            {
                new ChessPiece{Player = Team.Black,Type = Piece.Rook, Address = "A8"},
                new ChessPiece{Player = Team.Black,Type = Piece.Knight, Address = "B8"},
                new ChessPiece{Player = Team.Black,Type = Piece.Bishop, Address = "C8"},
                new ChessPiece{Player = Team.Black,Type = Piece.Queen, Address = "D8"},
                new ChessPiece{Player = Team.Black,Type = Piece.King, Address = "E8"},
                new ChessPiece{Player = Team.Black,Type = Piece.Bishop, Address = "F8"},
                new ChessPiece{Player = Team.Black,Type = Piece.Knight, Address = "G8"},
                new ChessPiece{Player = Team.Black,Type = Piece.Rook, Address = "H8"},
                new ChessPiece{Player = Team.Black,Type = Piece.Pawn, Address = "A7"},
                new ChessPiece{Player = Team.Black,Type = Piece.Pawn, Address = "B7"},
                new ChessPiece{Player = Team.Black,Type = Piece.Pawn, Address = "C7"},
                new ChessPiece{Player = Team.Black,Type = Piece.Pawn, Address = "D7"},
                new ChessPiece{Player = Team.Black,Type = Piece.Pawn, Address = "E7"},
                new ChessPiece{Player = Team.Black,Type = Piece.Pawn, Address = "F7"},
                new ChessPiece{Player = Team.Black,Type = Piece.Pawn, Address = "G7"},
                new ChessPiece{Player = Team.Black,Type = Piece.Pawn, Address = "H7"},
                new ChessPiece{Player = Team.White,Type = Piece.Rook, Address = "A1"},
                new ChessPiece{Player = Team.White,Type = Piece.Knight, Address = "B1"},
                new ChessPiece{Player = Team.White,Type = Piece.Bishop, Address = "C1"},
                new ChessPiece{Player = Team.White,Type = Piece.Queen, Address = "D1"},
                new ChessPiece{Player = Team.White,Type = Piece.King, Address = "E1"},
                new ChessPiece{Player = Team.White,Type = Piece.Bishop, Address = "F1"},
                new ChessPiece{Player = Team.White,Type = Piece.Knight, Address = "G1"},
                new ChessPiece{Player = Team.White,Type = Piece.Rook, Address = "H1"},
                new ChessPiece{Player = Team.White,Type = Piece.Pawn, Address = "A2"},
                new ChessPiece{Player = Team.White,Type = Piece.Pawn, Address = "B2"},
                new ChessPiece{Player = Team.White,Type = Piece.Pawn, Address = "C2"},
                new ChessPiece{Player = Team.White,Type = Piece.Pawn, Address = "D2"},
                new ChessPiece{Player = Team.White,Type = Piece.Pawn, Address = "E2"},
                new ChessPiece{Player = Team.White,Type = Piece.Pawn, Address = "F2"},
                new ChessPiece{Player = Team.White,Type = Piece.Pawn, Address = "G2"},
                new ChessPiece{Player = Team.White,Type = Piece.Pawn, Address = "H2"}
            });
            foreach(ChessPiece piece in Set)
            {
                piece.Graphic = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
            }
        }
        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value == "captured" || (
                    value.Length == 2 &&
                    Regex.IsMatch(value[0].ToString(), "[ABCDEFGH]") &&
                    Regex.IsMatch(value[1].ToString(), "[1-8]")))
                {
                    address = value;
                }

            }
        }
    }
}
