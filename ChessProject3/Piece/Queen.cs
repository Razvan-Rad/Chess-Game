using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
    class Queen : iPiece
    {
        protected override void initMoveSet()
        {
            moves = new TupleList<int, int>
                {
                {0,1}
                };
        }
        public Queen(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.queenB);
            else this.setId(ePiece.queenW);
            initMoveSet();
        }
    }
}
