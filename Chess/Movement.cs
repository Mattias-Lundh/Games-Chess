using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Movement
    {
        private static string EnPassant { get; set; } = "A1"; //remove test data '= "A1"'
        private static List<string> DiagonalNE(string origin)
        {
            string address = origin;
            List<string> result = new List<string> { };
            while (Address.SquareExcisits(address, 1, 1))
            {
                address = Address.ModifyAddress(address, 1, 1);
                result.Add(address);
            }
            return result;
        }
        private static List<string> DiagonalNW(string origin)
        {
            string address = origin;
            List<string> result = new List<string> { };
            while (Address.SquareExcisits(address, -1, 1))
            {
                address = Address.ModifyAddress(address, -1, 1);
                result.Add(address);
            }
            return result;
        }
        private static List<string> DiagonalSE(string origin)
        {
            string address = origin;
            List<string> result = new List<string> { };
            while (Address.SquareExcisits(address, 1, -1))
            {
                address = Address.ModifyAddress(address, 1, -1);
                result.Add(address);
            }
            return result;
        }
        private static List<string> DiagonalSW(string origin)
        {
            string address = origin;
            List<string> result = new List<string> { };
            while (Address.SquareExcisits(address, -1, -1))
            {
                address = Address.ModifyAddress(address, -1, -1);
                result.Add(address);
            }
            return result;
        }
        private static List<string> DiagonalMoves(ChessPiece piece)
        {
            List<string> result = new List<string> { };
            bool diagonalBlocked = false;
            foreach (string address in DiagonalNE(piece.Address))
            {
                if (Board.Square[piece.Address].Piece == null && !diagonalBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }

                }
                else if (piece.Player != Board.Square[piece.Address].Piece.Player && !diagonalBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                    diagonalBlocked = true;
                }
                else if (piece.Player == Board.Square[piece.Address].Piece.Player && !diagonalBlocked)
                {
                    diagonalBlocked = true;
                }
            }
            diagonalBlocked = false;
            foreach (string address in DiagonalNW(piece.Address))
            {
                if (Board.Square[piece.Address].Piece == null && !diagonalBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                }
                else if (piece.Player != Board.Square[piece.Address].Piece.Player && !diagonalBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                    diagonalBlocked = true;
                }
                else if (piece.Player == Board.Square[piece.Address].Piece.Player && !diagonalBlocked)
                {
                    diagonalBlocked = true;
                }
            }
            diagonalBlocked = false;
            foreach (string address in DiagonalSE(piece.Address))
            {
                if (Board.Square[piece.Address].Piece == null && !diagonalBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                }
                else if (piece.Player != Board.Square[piece.Address].Piece.Player && !diagonalBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                    diagonalBlocked = true;
                }
                else if (piece.Player == Board.Square[piece.Address].Piece.Player && !diagonalBlocked)
                {
                    diagonalBlocked = true;
                }
            }
            diagonalBlocked = false;
            foreach (string address in DiagonalSW(piece.Address))
            {
                if (Board.Square[piece.Address].Piece == null && !diagonalBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                }
                else if (piece.Player != Board.Square[piece.Address].Piece.Player && !diagonalBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                    diagonalBlocked = true;
                }
                else if (piece.Player == Board.Square[piece.Address].Piece.Player && !diagonalBlocked)
                {
                    diagonalBlocked = true;
                }
            }
            return result;
        }
        private static List<string> StraightN(string origin)
        {
            string address = origin;
            List<string> result = new List<string> { };
            while (Address.SquareExcisits(address, 0, 1))
            {
                address = Address.ModifyAddress(address, 0, 1);
                result.Add(address);
            }
            return result;
        }
        private static List<string> StraightE(string origin)
        {
            string address = origin;
            List<string> result = new List<string> { };
            while (Address.SquareExcisits(address, 1, 0))
            {
                address = Address.ModifyAddress(address, 1, 0);
                result.Add(address);
            }
            return result;
        }
        private static List<string> StraightS(string origin)
        {
            string address = origin;
            List<string> result = new List<string> { };
            while (Address.SquareExcisits(address, 0, -1))
            {
                address = Address.ModifyAddress(address, 0, -1);
                result.Add(address);
            }
            return result;
        }
        private static List<string> StraightW(string origin)
        {
            string address = origin;
            List<string> result = new List<string> { };
            while (Address.SquareExcisits(address, -1, 0))
            {
                address = Address.ModifyAddress(address, -1, 0);
                result.Add(address);
            }
            return result;
        }
        private static List<string> StraightMoves(ChessPiece piece)
        {
            List<string> result = new List<string> { };
            bool straightBlocked = false;
            foreach (string address in StraightN(piece.Address))
            {
                if (Board.Square[piece.Address].Piece == null && !straightBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                }
                else if (piece.Player != Board.Square[piece.Address].Piece.Player && !straightBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                    straightBlocked = true;
                }
                else if (piece.Player == Board.Square[piece.Address].Piece.Player && !straightBlocked)
                {
                    straightBlocked = true;
                }
            }
            straightBlocked = false;
            foreach (string address in StraightE(piece.Address))
            {
                if (Board.Square[piece.Address].Piece == null && !straightBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                }
                else if (piece.Player != Board.Square[piece.Address].Piece.Player && !straightBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                    straightBlocked = true;
                }
                else if (piece.Player == Board.Square[piece.Address].Piece.Player && !straightBlocked)
                {
                    straightBlocked = true;
                }
            }
            straightBlocked = false;
            foreach (string address in StraightS(piece.Address))
            {
                if (Board.Square[piece.Address].Piece == null && !straightBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                }
                else if (piece.Player != Board.Square[piece.Address].Piece.Player && !straightBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                    straightBlocked = true;
                }
                else if (piece.Player == Board.Square[piece.Address].Piece.Player && !straightBlocked)
                {
                    straightBlocked = true;
                }
            }
            straightBlocked = false;
            foreach (string address in StraightW(piece.Address))
            {
                if (Board.Square[piece.Address].Piece == null && !straightBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                }
                else if (piece.Player != Board.Square[piece.Address].Piece.Player && !straightBlocked)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                    straightBlocked = true;
                }
                else if (piece.Player == Board.Square[piece.Address].Piece.Player && !straightBlocked)
                {
                    straightBlocked = true;
                }
            }


            return result;
        }
        private static List<string> Horse(string origin)
        {
            List<string> result = new List<string> { };
            if (Address.SquareExcisits(origin, 1, 2)) { result.Add(Address.ModifyAddress(origin, 1, 2)); }
            if (Address.SquareExcisits(origin, 2, 1)) { result.Add(Address.ModifyAddress(origin, 2, 1)); }
            if (Address.SquareExcisits(origin, -1, 2)) { result.Add(Address.ModifyAddress(origin, -1, 2)); }
            if (Address.SquareExcisits(origin, -2, 1)) { result.Add(Address.ModifyAddress(origin, -2, 1)); }
            if (Address.SquareExcisits(origin, 1, -2)) { result.Add(Address.ModifyAddress(origin, 1, -2)); }
            if (Address.SquareExcisits(origin, 2, -1)) { result.Add(Address.ModifyAddress(origin, 2, -1)); }
            if (Address.SquareExcisits(origin, -1, -2)) { result.Add(Address.ModifyAddress(origin, -1, -2)); }
            if (Address.SquareExcisits(origin, -2, -1)) { result.Add(Address.ModifyAddress(origin, -2, -1)); }

            return result;
        }
        private static List<string> HorseMoves(ChessPiece piece)
        {
            List<string> result = new List<string> { };
            foreach (string address in Horse(piece.Address))
            {
                if (Board.Square[address].Piece == null || Board.Square[address].Piece.Player != piece.Player)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }

                }
            }
            return result;
        }
        private static List<string> Pawn(ChessPiece piece)
        {
            List<string> result = new List<string> { };

            string testLocation = Address.ModifyAddress(piece.Address, -1, 1);
            if (piece.Player == ChessPiece.Team.White)
            {
                if (Address.SquareExcisits(piece.Address, -1, 1))
                {
                    if (Board.Square[testLocation].Piece != null &&
                        Board.Square[testLocation].Piece.Player != piece.Player)
                    {
                        result.Add(testLocation);
                    }
                }
                testLocation = Address.ModifyAddress(piece.Address, 0, 1);
                if (Address.SquareExcisits(piece.Address, 0, 1) && Board.Square[Address.ModifyAddress(piece.Address, 0, 1)].Piece == null)
                {
                    result.Add(testLocation);
                }
                testLocation = Address.ModifyAddress(piece.Address, 1, 1);
                if (Address.SquareExcisits(piece.Address, 1, 1))
                {
                    if (Board.Square[testLocation].Piece != null &&
                        Board.Square[testLocation].Piece.Player != piece.Player)
                    {
                        result.Add(testLocation);
                    }
                }
                if (int.Parse(piece.Address[1].ToString()) == 2 && Board.Square[Address.ModifyAddress(piece.Address, 0, 1)].Piece == null)
                {
                    result.Add(Address.ModifyAddress(piece.Address, 0, 2));
                }
            }
            else
            {
                testLocation = Address.ModifyAddress(piece.Address, -1, -1);
                if (Address.SquareExcisits(piece.Address, -1, -1))
                {
                    if (Board.Square[testLocation].Piece != null &&
                        Board.Square[testLocation].Piece.Player != piece.Player)
                    {
                        result.Add(testLocation);
                    }
                }
                testLocation = Address.ModifyAddress(piece.Address, 0, -1);
                if (Address.SquareExcisits(piece.Address, 0, -1) && Board.Square[Address.ModifyAddress(piece.Address, 0, -1)].Piece == null)
                {
                    result.Add(testLocation);
                }
                testLocation = Address.ModifyAddress(piece.Address, 1, -1);
                if (Address.SquareExcisits(piece.Address, 1, -1))
                {
                    if (Board.Square[testLocation].Piece != null &&
                Board.Square[testLocation].Piece.Player != piece.Player)
                    {
                        result.Add(testLocation);
                    }
                }
                if (int.Parse(piece.Address[1].ToString()) == 7 && Board.Square[Address.ModifyAddress(piece.Address, 0, -1)].Piece == null)
                {
                    result.Add(Address.ModifyAddress(piece.Address, 0, -2));
                }

            }
            return result;
        }
        private static List<string> PawnMoves(ChessPiece piece)
        {
            List<string> result = new List<string> { };
            foreach (string address in Pawn(piece))
            {
                if (Board.Square[address].Piece == null ||
                    Board.Square[address].Piece.Player != piece.Player ||
                    address == EnPassant)
                {
                    if (!KingThreatened(piece, address))
                    {
                        result.Add(address);
                    }
                }
            }
            return result;
        }
        private static List<string> King(string origin)
        {
            List<string> result = new List<string> { };

            if (Address.SquareExcisits(origin, 0, 1))
            {
                result.Add(Address.ModifyAddress(origin, 0, 1));
            }
            if (Address.SquareExcisits(origin, 0, -1))
            {
                result.Add(Address.ModifyAddress(origin, 0, -1));
            }
            if (Address.SquareExcisits(origin, 1, 1))
            {
                result.Add(Address.ModifyAddress(origin, 1, 1));
            }
            if (Address.SquareExcisits(origin, 1, 0))
            {
                result.Add(Address.ModifyAddress(origin, 1, 0));
            }
            if (Address.SquareExcisits(origin, 1, -1))
            {
                result.Add(Address.ModifyAddress(origin, 1, -1));
            }
            if (Address.SquareExcisits(origin, -1, -1))
            {
                result.Add(Address.ModifyAddress(origin, -1, -1));
            }
            if (Address.SquareExcisits(origin, -1, 0))
            {
                result.Add(Address.ModifyAddress(origin, -1, 0));
            }
            if (Address.SquareExcisits(origin, -1, 1))
            {
                result.Add(Address.ModifyAddress(origin, -1, 1));
            }

            return result;
        }
        private static List<string> KingMoves(ChessPiece piece)
        {
            List<string> result = new List<string> { };

            foreach (string address in King(piece.Address))
            {
                if (Board.Square[address].Piece == null || Board.Square[address].Piece.Player != piece.Player)
                {
                    if (!IsThreat(piece.Player, address, piece.Address, address))
                    {
                        result.Add(address);
                    }
                }                
            }
            return result;
        }

        private static bool DiagonlaThreat(ChessPiece.Team player, string target, string from, string to)
        {
            bool diagonalBlocked = false;
            foreach (string address in DiagonalNE(target))
            {
                if (!diagonalBlocked && Board.Square[address].Piece != null && address != from && address != to)
                {
                    if (player != Board.Square[address].Piece.Player)
                    {
                        if (address == DiagonalNE(target)[0])
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.King ||
                                (player == ChessPiece.Team.White && Board.Square[address].Piece.Type == ChessPiece.Piece.Pawn))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    diagonalBlocked = true;
                }
                else if (address == to)
                {
                    if (player != Board.Square[from].Piece.Player)
                    {
                        if (address == DiagonalNE(target)[0])
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.King ||
                                (player == ChessPiece.Team.White && Board.Square[from].Piece.Type == ChessPiece.Piece.Pawn))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    diagonalBlocked = true;
                }
            }
            diagonalBlocked = false;
            foreach (string address in DiagonalNW(target))
            {
                if (!diagonalBlocked && Board.Square[address].Piece != null && address != from && address != to)
                {
                    if (player != Board.Square[address].Piece.Player)
                    {
                        if (address == DiagonalNW(target)[0])
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.King ||
                                (player == ChessPiece.Team.White && Board.Square[address].Piece.Type == ChessPiece.Piece.Pawn))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    diagonalBlocked = true;
                }
                else if (address == to)
                {
                    if (player != Board.Square[from].Piece.Player)
                    {
                        if (address == DiagonalNW(target)[0])
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.King ||
                                (player == ChessPiece.Team.White && Board.Square[from].Piece.Type == ChessPiece.Piece.Pawn))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    diagonalBlocked = true;
                }
            }
            diagonalBlocked = false;
            foreach (string address in DiagonalSE(target))
            {
                if (!diagonalBlocked && Board.Square[address].Piece != null && address != from && address != to)
                {
                    if (player != Board.Square[address].Piece.Player)
                    {
                        if (address == DiagonalSE(target)[0])
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen ||
                                (player == ChessPiece.Team.Black && Board.Square[address].Piece.Type == ChessPiece.Piece.Pawn))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    diagonalBlocked = true;
                }
                else if (address == to)
                {
                    if (player != Board.Square[from].Piece.Player)
                    {
                        if (address == DiagonalSE(target)[0])
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen ||
                                (player == ChessPiece.Team.Black && Board.Square[from].Piece.Type == ChessPiece.Piece.Pawn))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    diagonalBlocked = true;
                }
            }
            diagonalBlocked = false;
            foreach (string address in DiagonalSW(target))
            {
                if (!diagonalBlocked && Board.Square[address].Piece != null && address != from && address != to)
                {
                    if (player != Board.Square[address].Piece.Player)
                    {
                        if (address == DiagonalSW(target)[0])
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen ||
                                (player == ChessPiece.Team.Black && Board.Square[address].Piece.Type == ChessPiece.Piece.Pawn))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    diagonalBlocked = true;
                }
                else if (address == to)
                {
                    if (player != Board.Square[from].Piece.Player)
                    {
                        if (address == DiagonalSW(target)[0])
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen ||
                                (player == ChessPiece.Team.Black && Board.Square[from].Piece.Type == ChessPiece.Piece.Pawn))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Bishop ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    diagonalBlocked = true;
                }
            }
            return false;
        }
        private static bool StraightThreat(ChessPiece.Team player, string target, string from, string to)
        {
            bool straigthBlocked = false;
            foreach (string address in StraightN(target))
            {
                if (!straigthBlocked && Board.Square[address].Piece != null && address != from && address != to)
                {
                    if (player != Board.Square[address].Piece.Player)
                    {
                        if (address == StraightN(target)[0])
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.King)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    straigthBlocked = true;
                }
                else if (address == to)
                {
                    if (player != Board.Square[from].Piece.Player)
                    {
                        if (address == StraightN(target)[0])
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.King)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    straigthBlocked = true;
                }
            }
            straigthBlocked = false;

            foreach (string address in StraightE(target))
            {
                if (!straigthBlocked && Board.Square[address].Piece != null && address != from && address != to)
                {
                    if (player != Board.Square[address].Piece.Player)
                    {
                        if (address == StraightE(target)[0])
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.King)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    straigthBlocked = true;
                }
                else if (address == to)
                {
                    if (player != Board.Square[from].Piece.Player)
                    {
                        if (address == StraightE(target)[0])
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.King)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    straigthBlocked = true;
                }
            }
            straigthBlocked = false;

            foreach (string address in StraightS(target))
            {
                if (!straigthBlocked && Board.Square[address].Piece != null && address != from && address != to)
                {
                    if (player != Board.Square[address].Piece.Player)
                    {
                        if (address == StraightS(target)[0])
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.King)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    straigthBlocked = true;
                }
                else if (address == to)
                {
                    if (player != Board.Square[from].Piece.Player)
                    {
                        if (address == StraightS(target)[0])
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.King)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    straigthBlocked = true;
                }
            }
            straigthBlocked = false;

            foreach (string address in StraightW(target))
            {
                if (!straigthBlocked && Board.Square[address].Piece != null && address != from && address != to)
                {
                    if (player != Board.Square[address].Piece.Player)
                    {
                        if (address == StraightW(target)[0])
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.King)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[address].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[address].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    straigthBlocked = true;
                }
                else if (address == to)
                {
                    if (player != Board.Square[from].Piece.Player)
                    {
                        if (address == StraightW(target)[0])
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.King)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Board.Square[from].Piece.Type == ChessPiece.Piece.Rook ||
                                Board.Square[from].Piece.Type == ChessPiece.Piece.Queen)
                            {
                                return true;
                            }
                        }
                    }
                    straigthBlocked = true;
                }
            }
            straigthBlocked = false;
            return false;
        }
        private static bool HorseThreat(ChessPiece.Team player, string target, string from, string to)
        {
            foreach (string address in Horse(target))
            {
                if (Board.Square[address].Piece != null &&
                    Board.Square[address].Piece.Type == ChessPiece.Piece.Knight &&
                    Board.Square[address].Piece.Player != player)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool IsThreat(ChessPiece.Team player, string target, string from, string to)
        {
            if (DiagonlaThreat(player, target, from, to) ||
                StraightThreat(player, target, from, to) ||
                HorseThreat(player, target, from, to))
            {
                return true;
            }
            return false;
        }
        private static bool KingThreatened(ChessPiece piece, string move)
        {
            if ((IsThreat(piece.Player, ChessPiece.Set[4].Address, piece.Address, move) && piece.Player == ChessPiece.Team.Black) ||
                (IsThreat(piece.Player, ChessPiece.Set[20].Address, piece.Address, move) && piece.Player == ChessPiece.Team.White))
            {
                return true;
            }
            return false;
        }
        public static List<string> GetAvaliable(ChessPiece piece)
        {
            List<string> result = new List<string> { };
            switch (piece.Type)
            {
                case ChessPiece.Piece.Bishop:
                    foreach (string address in DiagonalMoves(piece))
                    {
                        result.Add(address);
                    }
                    break;
                case ChessPiece.Piece.Rook:
                    foreach (string address in StraightMoves(piece))
                    {
                        result.Add(address);
                    }
                    break;
                case ChessPiece.Piece.Knight:
                    foreach (string address in HorseMoves(piece))
                    {
                        result.Add(address);
                    }
                    break;
                case ChessPiece.Piece.Queen:
                    foreach (string address in DiagonalMoves(piece))
                    {
                        result.Add(address);
                    }
                    foreach (string address in StraightMoves(piece))
                    {
                        result.Add(address);
                    }
                    break;
                case ChessPiece.Piece.Pawn:
                    foreach (string address in PawnMoves(piece))
                    {
                        result.Add(address);
                    }
                    break;
                case ChessPiece.Piece.King:
                    foreach (string address in KingMoves(piece))
                    {
                        result.Add(address);
                    }
                    break;
            }
            return result;
        }
        public static void Place(ChessPiece piece, string address)
        {
            Board.Square[address].Piece = piece;
            Board.Square[address].Panel.Controls.Add(piece.Graphic);
            piece.Address = address;
        }
        public static void Remove(string address)
        {
            if (Board.Square[address].Piece != null)
            {                
                Board.Square[address].Panel.Controls.Clear();
                Board.Square[address].Piece = null;
            }
        }

        public static void Action(ChessPiece piece, string toSquare)
        {
            Remove(toSquare);
            Remove(Game.SelectedPiece.Address);
            Place(Game.SelectedPiece, toSquare);
        }

    }
}
