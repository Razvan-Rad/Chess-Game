using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
    class Queen : iPiece
    {
        protected override void init()
        {
            dynamicMoveSet = true;
        }

        protected override TupleList<int, int> getDynamicMoveList(int pieceX, int pieceY, bool firstMove = true)
        {
            moves = null;
            TupleList<int, int> newMoves = new TupleList<int, int> { };

            newMoves.AddRange(ChessLogic.getDynamicBishopMoves(pieceX, pieceY));
            newMoves.AddRange(ChessLogic.getDynamicRookMoves(pieceX, pieceY));

            moves = newMoves;
            return newMoves;
        }
        public Queen(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.queenB);
            else this.setId(ePiece.queenW);
            init();
        }
    }
}
