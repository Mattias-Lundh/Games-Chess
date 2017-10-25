using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Game
    {
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
                Place(piece, piece.Address);
            }
        }

        private void Place(ChessPiece piece, string address)
        {
            Board.Square[address].Piece = piece;
            Board.Square[address].Panel.Controls.Add(piece.Graphic);
            piece.Address = address;
        }

    }
}
