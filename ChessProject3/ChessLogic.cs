using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChessProject3
{
    class ChessLogic
    {
        Board board;
        bool running = true;
        public int round = 0;
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

            if (canMove(oldX, oldY, newX, newY))
            {
                board.moveTile(oldX, oldY, newX, newY);
                return true;
            }
            return false;
        }
        bool anythingInTheWayBishop(int oldX, int oldY, int newX, int newY)
        {
            int iterX = (oldX < newX) ? oldX : newX;
            int finalX = (oldX > newX) ? oldX : newX;
            int iterY = (oldY < newY) ? oldY : newY;
            int finalY = (oldY > newY) ? oldY : newY;
            for (int i = iterX + 1, j = iterY + 1; i < finalX && j < finalY; i++, j++)
            {
                if (board.getTile(i, j) != null)
                {
                    return true;
                }
            }
            return false;
        }
        bool anythingInTheWayRook(int oldX, int oldY, int newX, int newY)
        {
            if (oldX == newX)
            {
                int iterStart = oldY;
                int iterEnd = newY;
                if (newY < oldY)
                {
                    iterStart = newY;
                    iterEnd = oldY;
                }

                for (int i = iterStart + 1; i < iterEnd; i++)
                {
                    if (board.getTile(oldX, i) != null)
                    {
                        return true;
                    }
                }
            }
            else if (oldY == newY)
            {
                int iterStart = oldX;
                int iterEnd = newX;
                if (newX < oldX)
                {
                    iterStart = newX;
                    iterEnd = oldX;
                }
                for (int i = iterStart + 1; i < iterEnd; i++)
                {
                    if (board.getTile(i, oldY) != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        void filterAnythingInTheWay(int oldX, int oldY, ref List<Tuple<int,int>> list)
        {
            List<Tuple<int,int>> toRemove = new List<Tuple<int,int>>();
            iPiece current = board.getTile(oldX, oldY);
            foreach (Tuple<int, int> element in list)
            {
                int newX = element.Item1;
                int newY = element.Item2;
                if (current.isSameAs(ePiece.rookW) && anythingInTheWayRook(oldX, oldY, newX, newY))
                {
                    toRemove.Add(element);
                }
                else if (current.isSameAs(ePiece.bishopW) && anythingInTheWayBishop(oldX, oldY, newX, newY))
                {
                    toRemove.Add(element);
                }
                else if (
                    current.isSameAs(ePiece.queenW) &&
                    anythingInTheWayRook(oldX, oldY, newX, newY) ||
                    anythingInTheWayBishop(oldX, oldY, newX, newY))
                {
                    toRemove.Add(element);
                }
            }

            list = list.Except(toRemove).ToList();
        }

        public List<Tuple<int,int>> getValidMoves(int x, int y, int dx, int dy, bool enableFilters = false)
        {
            List<Tuple<int,int>> ret;

            iPiece current = board.getTile(x, y);
            iPiece target = board.getTile(dx, dy);

            ret = current.getUnfilteredMoves(x, y);
            if (enableFilters)
            {
                //moves are within bounds now
                if (target != null)
                {
                    filterPieceTakeAllyPiece(current,ref ret);
                }
               filterAnythingInTheWay(x, y,ref ret);
                //// after move, is there check?
                //if (isCheck()) ret = false;

            }
            return ret;
        }

        bool canMove(int oldX, int oldY, int newX, int newY)
        {
            iPiece current = board.getTile(oldX, oldY);
            iPiece target = board.getTile(newX, newY);
            bool ret = false;
            List<Tuple<int,int>> moveset = getValidMoves(oldX, oldY, newX, newY);
            if (moveset != null)
            {
                filterReachableSquares(oldX, oldY, newX, newY, moveset);
                if(moveset.Count > 0)
                {
                    ret = true;
                }
            }
            return ret;
        }
        bool filterReachableSquares(int oldX, int oldY, int newX, int newY, List<Tuple<int,int>> moveset)
        {
            foreach (Tuple<int, int> element in moveset)
            {
                if (element.Item1 == newX && element.Item2 == newY) return false;
            }
            return true;
        }
        bool isCheck()
        {
            return false;
        }
        public static List<Tuple<int,int>> getDynamicBishopMoves(int pieceX, int pieceY)
        {
            List<Tuple<int,int>> list = new List<Tuple<int,int>>() { };
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
        public static List<Tuple<int,int>> getDynamicRookMoves(int pieceX, int pieceY)
        {
            List<Tuple<int,int>> list = new List<Tuple<int,int>>() { };
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
            for (int i = pieceY; i < 8; i++)
            {
                list.Add(Tuple.Create(pieceX, i));
            }
            for (int i = pieceY; i >= 0; i--)
            {
                list.Add(Tuple.Create(pieceX, i));
            }
            return list;
        }
        void filterPieceTakeAllyPiece(iPiece current, ref List<Tuple<int,int>> list)
        {
            List<Tuple<int,int>> toRemove = new List<Tuple<int,int>>();
            foreach (Tuple<int, int> element in list)
            {
                iPiece target = board.getTile(element.Item1, element.Item2);
                if (target != null)
                {
                    if (pieceTakeAllyPiece(current, target))
                    {
                        toRemove.Add(element);
                    }
                }
            }
         list =  list.Except(toRemove).ToList();
        }
        bool pieceTakeAllyPiece(iPiece current, iPiece target)
        {
            bool color = (int)current.getId() > 6;
            bool color2 = (int)target.getId() > 6;
            return !(color ^ color2);
        }

    }
}
