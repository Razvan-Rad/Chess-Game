using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
    class Pawn : iPiece
    {

        protected override void initMoveSet()
        {
            moves = new TupleList<int, int>
                {
                {0,1}
                };
        }
        public Pawn(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.pawnB);
            else this.setId(ePiece.pawnW);
            initMoveSet();
        }

    }
}
