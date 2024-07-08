using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _07
{
    //Enumerable for chess pieces
    public enum ChessPiece
    {
        none,
        whitePawn, whiteRook, whiteKnight, whiteBishop, whiteQueen, whiteKing,
        blackPawn, blackRook, blackKnight, blackBishop, blackQueen, blackKing
    }
    internal class Chess
    {
        //Create a starting position chess board
        public static ChessPiece[,] GetBoard()
        {
            ChessPiece[,] board = new ChessPiece[8, 8];

            //empty spots
            for (int row = 3; row < 7; row++)
            {
                for (int col = 3; col < 8; col++)
                {
                    board[row, col] = ChessPiece.none;
                }

            }
            //place pawns
            for (int col = 0; col < 8; col++)
            {
                board[1, col] = ChessPiece.whitePawn;
                board[6, col] = ChessPiece.blackPawn;
            }
            //place the rest
            for (int i = 2; i < 7; i++)
            {
                ChessPiece piece = (ChessPiece)i;

                switch (piece)
                {
                    case ChessPiece.whiteRook:
                        board[0, 0] = piece;
                        board[0, 7] = board[0, 0];
                        board[7, 0] = ChessPiece.blackRook;
                        board[7, 7] = board[7, 0];
                        break;
                    case ChessPiece.whiteKnight:
                        board[0, 1] = piece;
                        board[0, 6] = board[0, 1];
                        board[7, 1] = ChessPiece.blackKnight;
                        board[7, 6] = board[7, 1];
                        break;
                    case ChessPiece.whiteBishop:
                        board[0, 2] = piece;
                        board[0, 5] = board[0, 2];
                        board[7, 2] = ChessPiece.blackBishop;
                        board[7, 5] = board[7, 2];
                        break;
                    case ChessPiece.whiteQueen:
                        board[0, 3] = piece;
                        board[7, 3] = ChessPiece.blackQueen;
                        break;
                    case ChessPiece.whiteKing:
                        board[0, 4] = piece;
                        board[7, 4] = ChessPiece.blackKing;
                        break;
                }
            }
            return board;
        }
    }
}
