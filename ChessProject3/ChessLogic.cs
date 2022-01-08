using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChessProject3
{
    struct Move
    {
        public Move(int x, int y, int dx, int dy)
        {
            this.x = x;
            this.y = y;
            this.dx = dx;
            this.dy = dy;
        }
        public int x;
        public int y;
        public int dx;
        public int dy;
    }
    class ChessLogic
    {
        Board board;
        bool running = true;
        public int round = 0;
        bool whiteRound() => round % 2 == 0;
        public bool isRunning() => running;

        public List<Move> pastMoves = new List<Move>();
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
            if (whiteRound() && isWhiteOnTile(x, y))
            {
                return true;
            }
            if (!whiteRound() && isBlackOnTile(x, y))
            {
                return true;
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
            bool black = true;
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(i);
                board.getTile(i, 1) = new Pawn(true);
                board.getTile(i, 6) = new Pawn();
            }
            board.getTile(0, 0) = new Rook(black);
            board.getTile(7, 0) = new Rook(black);
            board.getTile(1, 3) = new Horse(black);
            board.getTile(6, 3) = new Horse(black);
            board.getTile(2, 3) = new Bishop(black);
            board.getTile(5, 3) = new Bishop(black);
            board.getTile(3, 0) = new King(black);
            board.getTile(4, 3) = new Queen(black);


            board.getTile(0, 7) = new Rook();
            board.getTile(7, 7) = new Rook();


            board.getTile(1, 7) = new Horse();
            board.getTile(6, 7) = new Horse();

            board.getTile(2, 7) = new Bishop();
            board.getTile(5, 7) = new Bishop();

            board.getTile(3, 7) = new King();
            board.getTile(4, 3) = new Queen();
        }
        public List<Tuple<int, int>> getAllSpecialMoves(int x, int y)
        {// parse -> filter -> get
            var specialMoveset = board.getTile(x, y).parseSpecialMoveList(x, y);
            return filterSpecial(x, y, specialMoveset);
        }
        public List<Tuple<int, int>> getAllMoves(int x, int y) //EXCEPT SPECIAL
        {
            var moveset = getAllNormalMoves(x, y);
            var specialMoveset = getAllSpecialMoves(x, y);

            if (specialMoveset != null)
            {
                moveset.AddRange(specialMoveset);
            }
            return moveset;
        }

        public bool movePiece(int x, int y, int newX, int newY)
        {
            List<Tuple<int, int>> normal = getAllNormalMoves(x, y);
            List<Tuple<int, int>> special = getAllSpecialMoves(x, y);
            var target = Tuple.Create(newX, newY);
            var targetPiece = board.getTile(x, y);

            if (normal.Contains(target))
            {
                board.tile[x, y].specialMoveSet = false;
                board.moveTile(x, y, newX, newY);

                return true;
            }

            if (special.Contains(target))
            {
                board.tile[x, y].specialMoveSet = false;
                board.moveTile(x, y, newX, newY);
                if (targetPiece.isSameAs(ePiece.kingW))
                {
                    //newX-1 = right hand side move
                    int dx = x < newX ? newX - 1 : newX + 1;
                    int sx = dx == newX - 1 ? 7 : 0;
                    var targetRook = board.getTile(sx, y);


                    if (targetRook != null)
                    {
                        if (targetRook.isSameAs(ePiece.rookW) && targetRook.specialMoveSet)
                        {
                            board.moveTile(sx, y, dx, newY);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        bool anythingInTheWayBishop(int oldX, int oldY, int newX, int newY)
        {
            var startX = oldX < newX ? oldX : newX;
            var finishX = oldX > newX ? oldX : newX;

            var startY = oldY;

            int iterMultiplier;
            if (startX == newX)
            {
                startY = newY;
                iterMultiplier = newY < oldY ? -1 : 1;
            }
            for(;startX !=)
            //if (board.getTile(i, j) != null)
            //{
            //return true;
            //}

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
        List<Tuple<int, int>> filterAnythingInTheWay(int x, int y, List<Tuple<int, int>> list)
        {
            List<Tuple<int, int>> toRemove = new List<Tuple<int, int>>();
            iPiece current = board.getTile(x, y);
            foreach (Tuple<int, int> element in list)
            {
                int newX = element.Item1;
                int newY = element.Item2;

                if (current.isSameAs(ePiece.rookW) && anythingInTheWayRook(x, y, newX, newY))
                {
                    toRemove.Add(element);
                }

                else if (current.isSameAs(ePiece.bishopW) && anythingInTheWayBishop(x, y, newX, newY))
                {
                    toRemove.Add(element);
                }

                else if (current.isSameAs(ePiece.queenW) &&
                    anythingInTheWayRook(x, y, newX, newY) ||
                    anythingInTheWayBishop(x, y, newX, newY))
                {
                    toRemove.Add(element);
                }
                else if (current.getId() == ePiece.pawnW)
                {
                    if (anythingInTheWayRook(x, y, newX, newY - 1))
                    {
                        toRemove.Add(element);
                    }
                }

                else if (current.getId() == ePiece.pawnB)
                {
                    if (anythingInTheWayRook(x, y, newX, newY + 1))
                    {
                        toRemove.Add(element);
                    }
                }
            }

            return list.Except(toRemove).ToList();
        }
        List<Tuple<int, int>> filterSpecial(int x, int y, List<Tuple<int, int>> list)
        {
            List<Tuple<int, int>> moveset = new List<Tuple<int, int>>();
            if (list != null)
            {
                var current = board.getTile(x, y);
                //COPY PASTED, CARE
                List<Tuple<int, int>> toRemove = new List<Tuple<int, int>>();
                if (current.isSameAs(ePiece.pawnW))
                {
                    foreach (Tuple<int, int> piece in list)
                    {
                        iPiece target = board.getTile(piece.Item1, piece.Item2);

                        //2 move
                        if (target == null)
                        {
                        }
                        else
                        {
                            toRemove.Add(piece);
                        }
                    }
                }
                moveset = list.Except(toRemove).ToList();
                moveset = filterPieceTakeAllyPiece(x, y, moveset);
                moveset = filterAnythingInTheWay(x, y, moveset);
            }

            return moveset;

        }
        bool filterEnPassant(int x, int y, int dx, int dy)
        {
            iPiece current = board.getTile(x, y);
            Move mv = new Move(x, y, dx, dy);
            if (pastMoves.Count > 0)
            {
                Move lastMove = pastMoves.Last();
                iPiece target = board.getTile(lastMove.dx, lastMove.dy);

                if (target != null)
                {

                    if (current.getId() == ePiece.pawnW &&
                        target.getId() == ePiece.pawnB)
                    {
                        if (lastMove.y == 1 && lastMove.dy == 3) // if target moved 2 down
                        {
                            if (mv.x == lastMove.dx + 1 || mv.x == lastMove.dx - 1)
                            {
                                board.tile[lastMove.dx, lastMove.y] = null;
                                return true;
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }

            return false;
        }
        List<Tuple<int, int>> filterDynamic(int x, int y, List<Tuple<int, int>> list)
        {
            iPiece current = board.getTile(x, y);
            List<Tuple<int, int>> toRemove = new List<Tuple<int, int>>();
            if (current.isSameAs(ePiece.pawnW))
            {
                foreach (Tuple<int, int> piece in list)
                {
                    iPiece target = board.getTile(piece.Item1, piece.Item2);

                    if (filterEnPassant(x, y, piece.Item1, piece.Item2))
                    { continue; }

                    if (target == null ||
                            pieceTakeAllyPiece(current, target))
                    {
                        toRemove.Add(piece);
                    }
                }
            }


            return list.Except(toRemove).ToList();
        }

        public List<Tuple<int, int>> getAllNormalMoves(int x, int y)
        {
            List<Tuple<int, int>> moveset = new List<Tuple<int, int>>();
            List<Tuple<int, int>> movesetDynamic;
            List<Tuple<int, int>> movesetStatic;

            iPiece current = board.getTile(x, y);

            // filter static
            movesetStatic = current.getBoundedStatic(x, y);
            if (movesetStatic != null)
            {
                moveset.AddRange(movesetStatic);
            }

            // filter dynamic
            movesetDynamic = current.getBoundedDynamic(x, y);
            if (movesetDynamic != null)
            {
                movesetDynamic = filterDynamic(x, y, movesetDynamic);
                if (movesetDynamic != null)
                {
                    moveset.AddRange(movesetDynamic);
                }
            }
            moveset = filterPieceTakeAllyPiece(x, y, moveset);
            moveset = filterAnythingInTheWay(x, y, moveset);

            //// after move, is there check?
            //if (isCheck()) ret = false;
            return moveset;
        }
        bool isCheck()
        {
            return false;
        }
        public static List<Tuple<int, int>> getDynamicBishopMoves(int pieceX, int pieceY)
        {
            List<Tuple<int, int>> list = new List<Tuple<int, int>>() { };
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
        public static List<Tuple<int, int>> getDynamicRookMoves(int pieceX, int pieceY)
        {
            List<Tuple<int, int>> list = new List<Tuple<int, int>>() { };
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
        List<Tuple<int, int>> filterPieceTakeAllyPiece(int x, int y, List<Tuple<int, int>> list)
        {
            var current = board.getTile(x, y);
            List<Tuple<int, int>> toRemove = new List<Tuple<int, int>>();
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
            return list.Except(toRemove).ToList();
        }
        bool pieceTakeAllyPiece(iPiece current, iPiece target)
        {
            return !((int)current.getId() > 6 ^ (int)target.getId() > 6);
        }

    }
}
