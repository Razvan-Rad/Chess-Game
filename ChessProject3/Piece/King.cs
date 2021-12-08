using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
    class King : iPiece
    {
        protected override void initMoveSet()
        {
            moves = new TupleList<int, int>
                {
                {0,1},
                {1,0},
                {1,1},
                {0,-1},
                {-1,0},
                {-1,1},
                {1,-1},
                {-1,-1}
                };
        }
        public King(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.kingB);
            else this.setId(ePiece.kingW);
            initMoveSet();
        }
    }
}
