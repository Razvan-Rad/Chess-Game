﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessProject3
{
    class ChessLogic
    {
        Board board;
        bool running = true;
        int round = 0;
        bool whiteRound() => round % 2 == 0;
        public bool isRunning() => running;

        public ChessLogic(Board b)
        {
            board = b;
            initPiecesDefault();
        }
        bool isTileEmpty(int x, int y)
        {
            return board.getTile(x, y) == null;
        }
        bool isWhiteOnTile(int x, int y) => !isTileEmpty(x, y) && ((int)board.ePiecegetTile(x, y) < 7);

        bool isBlackOnTile(int x, int y) => !isTileEmpty(x, y) && ((int)board.ePiecegetTile(x, y) > 6);
        public bool squareSelectionSuccess(int x, int y)
        {
            if (whiteRound())
            {
                if (isWhiteOnTile(x, y))
                {
                    return true;
                }
            }
            else
            {
                if (isBlackOnTile(x, y))
                {
                    return true;
                }

            }
            return false;
        }
        public void nextRound()
        {
            if (round % 2 == 0)
            {

            }
            else
            {

            }
            round++;

        }
        void initPiecesDefault()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(i);
                board.setTile(i, 1, ePiece.pawnB);
                board.setTile(i, 6, ePiece.pawnW);
            }

            board.setTile(0, 0, ePiece.rookB);
            board.setTile(7, 0, ePiece.rookB);

            board.setTile(0, 7, ePiece.rookW);
            board.setTile(7, 7, ePiece.rookW);

            board.setTile(1, 0, ePiece.horseB);
            board.setTile(6, 0, ePiece.horseB);

            board.setTile(1, 7, ePiece.horseW);
            board.setTile(6, 7, ePiece.horseW);

            board.setTile(2, 0, ePiece.bishopB);
            board.setTile(5, 0, ePiece.bishopB);

            board.setTile(2, 7, ePiece.bishopW);
            board.setTile(5, 7, ePiece.bishopW);

            board.setTile(3, 0, ePiece.kingB);
            board.setTile(4, 0, ePiece.queenB);

            board.setTile(3, 7, ePiece.kingW);
            board.setTile(4, 3, ePiece.queenW);
        }
        public bool movePiece(int oldX, int oldY, int newX, int newY)
        {
            iPiece current = board.getTile(oldX, oldY);
            iPiece target = board.getTile(newX, newY);

            if (canMove(current, target, oldX, oldY, newX, newY))
            {
                board.setTile(oldX, oldY, ePiece.none);
                board.setTile(newX, newY, current);
            }
            else
            {
                return false;

            }
            return true;

        }
        bool canMove(iPiece current, iPiece target, int oldX, int oldY, int newX, int newY)
        {
            bool ret = true;
            if (target != null)
            {
                if (pieceTakeAllyPiece(current, target)) ret = false;
            }
            if (squareUnreachable(current, oldX, oldY, newX, newY)) ret = false;
            if (isCheck()) ret = false;

            return ret;
        }
        bool squareUnreachable(iPiece current, int oldX, int oldY, int newX, int newY)
        {
            foreach (Tuple<int, int> element in current.getValidMoveList((int)oldX, (int)oldY))
            {
                if (element.Item1 == newX && element.Item2 == newY) return false;
            }
            return true;
        }
        bool isCheck()
        {
            return false;
        }
        public static TupleList<int,int> getDynamicBishopMoves(int pieceX,int pieceY)
        {
            TupleList<int, int> list = new TupleList<int, int>(){ };
            // Top Left to bottom right diagonal
            for (int i = pieceX, j = pieceY; i < 8 && j < 8; i++, j++)
            {
                list.Add(Tuple.Create(i, j));
            }
            for (int i = pieceX, j = pieceY; i >= 0 && j >= 0; i--, j--)
            {
                list.Add(Tuple.Create(i, j));
            }
            // Bottom left to top right diagonal
            for (int i = pieceX, j = pieceY; i >= 0 && j < 8; i--, j++)
            {
                list.Add(Tuple.Create(i, j));
            }
            for (int i = pieceX, j = pieceY; i < 8 && j >= 0; i++, j--)
            {
                list.Add(Tuple.Create(i, j));
            }
            return list;
        }
        public static TupleList<int,int> getDynamicRookMoves(int pieceX,int pieceY)
        {
            TupleList<int, int> list = new TupleList<int, int>() { };
            //rook left to right
            for (int i = pieceX; i < 8; i++)
            {
                list.Add(Tuple.Create(i, pieceY));
            }
            for (int i = pieceX; i >= 0; i--)
            {
                list.Add(Tuple.Create(i, pieceY));
            }
            //rook top to bottom
            for(int i = pieceY; i < 8;i++)
            {
                list.Add(Tuple.Create(pieceX,i));
            }
            for(int i = pieceY;i >=0;i--)
            {
                list.Add(Tuple.Create(pieceX,i)); 
            }
            return list;
        }
        bool pieceTakeAllyPiece(iPiece current, iPiece target)
        {
            bool color = (int)current.getId() > 6;
            bool color2 = (int)target.getId() > 6;
            return color && color;
        }

    }
}
