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
        public ChessLogic(ref Board b)
        {
           board = b;
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
