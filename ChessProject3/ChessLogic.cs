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
        public ChessLogic(ref Board b)
        {
           board = b;
        }
        public void MovePiece(uint oldX, uint oldY, uint newX, uint newY)
        {
            uint current = board.getTile(oldX, oldY);
            uint target  = board.getTile(newX, newY);

            if (canMove(current, target))// ex can move white horse over black queen?
            {
                board.setTile(newX, newY, (ePiece)current);
                board.setTile(oldX, oldY, ePiece.none);
            }
        }
        bool canMove(uint current, uint target)
        {
            if (isCheck() || doesPieceTakeAllyPiece(current,target)) return false;
            Horse horse1 = new Horse();
            horse1.getValidMoveList(3, 2);

            return true;
        }
        bool isCheck()
        {
            return false;
        }
        bool doesPieceTakeAllyPiece(uint target, uint piece)
        {
            if ((target < 7 && piece < 7) ||
                (target > 7 && piece > 7))
                return true;
            return false;
        }

    }
}
