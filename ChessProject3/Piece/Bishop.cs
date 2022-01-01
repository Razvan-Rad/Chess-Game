using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
    public class Bishop : iPiece
    {
        protected override void init()
        {
            dynamicMoveSet = true;
        }
        protected override TupleList<int, int> getDynamicMovesList(int pieceX, int pieceY)
        {
            moves = null;
            TupleList<int, int> newMoves = new TupleList<int, int> { };

            newMoves.AddRange(ChessLogic.getDynamicBishopMoves(pieceX, pieceY));
            moves = newMoves;
            return newMoves;

        }
        public Bishop(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.bishopB);
            else this.setId(ePiece.bishopW);
            init();
        }


    }
}