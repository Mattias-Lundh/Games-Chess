using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{    
    class Game
    {
        public static ChessPiece SelectedPiece { get; set; }
        public static List<string> HighLightList
        {
            get
            {
                return Movement.GetAvaliable(SelectedPiece);
            }
        }
        private Board Board { get; set; }
        public Game(Board board)
        {
            Board = board;
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
            }

            foreach (KeyValuePair<string, BoardSquare> key in Board.Square)
            {
                BoardSquare square = Board.Square[key.ToString().Substring(1, 2)];
                if (square.Piece != null)
                {
                    square.Piece.Graphic.MouseDown += Events.PieceMouseDownEvent;
                    square.Piece.Graphic.Click += Events.PieceClickEvent;
                }                
            }
            
        }
    }
}
