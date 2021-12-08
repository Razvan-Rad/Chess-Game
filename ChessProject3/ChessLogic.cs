using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
    class ChessLogic
    {
         Board board;
        bool running = true;
        int round = 0;
        public bool isRunning() => running;
        public ChessLogic(Board b)
        {
            board = b;
            initPiecesDefault();
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
                board.setTile(i, 1, ePiece.pawnW);
                board.setTile(i, 6, ePiece.pawnB);
            }

            board.setTile(0, 0, ePiece.rookW);
            board.setTile(7, 0, ePiece.rookW);

            board.setTile(0, 7, ePiece.rookB);
            board.setTile(7, 7, ePiece.rookB);

            board.setTile(1, 0, ePiece.horseW);
            board.setTile(6, 0, ePiece.horseW);

            board.setTile(1, 7, ePiece.horseB);
            board.setTile(6, 7, ePiece.horseB);

            board.setTile(2, 0, ePiece.bishopW);
            board.setTile(5, 0, ePiece.bishopW);

            board.setTile(2, 7, ePiece.bishopB);
            board.setTile(5, 7, ePiece.bishopB);

            board.setTile(3, 0, ePiece.kingW);
            board.setTile(4, 0, ePiece.queenW);

            board.setTile(3, 7, ePiece.kingB);
            board.setTile(4, 7, ePiece.queenB);
        }
        public void movePiece(int oldX, int oldY, int newX, int newY)
        {
            iPiece current = board.getTile(oldX, oldY);
            iPiece target  = board.getTile(newX, newY);
             
            if (canMove(current, target, oldX, oldY, newX , newY))
            {
                board.setTile(oldX, oldY, ePiece.none);
                board.setTile(newX, newY, current);
            }
        }
        bool canMove(iPiece current, iPiece target, int oldX, int oldY, int newX, int newY)
        {
            if (target == null) target =new Pawn();
            if (isCheck()) return false;
            if (pieceTakeAllyPiece(current, target)) return false;
            if (squareUnreachable(current, oldX, oldY, newX, newY)) return false;
            

            return true;
        }
        bool squareUnreachable(iPiece current, int oldX, int oldY, int newX, int newY)
        {
            foreach (Tuple<int, int> element in current.getValidMoveList((int)oldX, (int)oldY))
            {
                if(element.Item1 == newX && element.Item2 == newY) return false;
            }
            return true;
        }
        bool isCheck()
        {
            return false;
        }
        bool pieceTakeAllyPiece(iPiece current, iPiece target)
        {
            bool color = (int)current.getId() > 6;
            bool color2 = (int)target.getId() > 6;
            return color && color;
        }

    }
}
