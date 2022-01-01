using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
    class King : iPiece
    {
        protected override void init()
        {
            moves = new TupleList<int, int>
                {
                {0,1},
                {1,0},
                {1,1},
                {1,-1},
                {0,-1},
                {-1,0},
                {-1,1},
                {-1,-1},
                {-1,0}
                };
        }
        protected override TupleList<int,int> getDynamicMovesList(int pieceX, int pieceY)
        {
            throw new NotImplementedException();
        }
        public King(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.kingB);
            else this.setId(ePiece.kingW);
            init();
        }
    }
}
