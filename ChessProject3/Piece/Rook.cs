using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
    public class Rook : iPiece
    {
        protected override void init()
        {
            dynamicMoveSet = true;
        }

        protected override TupleList<int, int> getDynamicMoveList(int pieceX, int pieceY, bool firstMove = true)
        {
            moves = null;
            TupleList<int, int> newMoves = new TupleList<int, int> { };

            newMoves.AddRange(ChessLogic.getDynamicRookMoves(pieceX, pieceY));

            moves = newMoves;
            return newMoves;
        }
        public Rook(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.rookB);
            else this.setId(ePiece.rookW);
            init();
        }


    }
}