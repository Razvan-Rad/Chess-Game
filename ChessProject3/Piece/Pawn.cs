using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
    class Pawn : iPiece
    {
        bool firstMove = true;
        protected override void init()
        {
            if (this.getId() == ePiece.pawnB)
            {
                moves = new TupleList<int, int>
                {
                {0,1},
                };

            }
            else
            {
                moves = new TupleList<int, int>
                {
                {0,-1}
                };

            }
        }
        protected override TupleList<int,int> getDynamicMovesList(int pieceX, int pieceY)
        {
            throw new NotImplementedException();
        }
        public Pawn(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.pawnB);
            else this.setId(ePiece.pawnW);
            init();
        }

    }
}
