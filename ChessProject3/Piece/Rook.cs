using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
   public class Rook : iPiece
    {
        protected override void initMoveSet()
        {
            moves = new TupleList<int, int>
                {   // Right hand side
                    {1,2},
                    {1,-2},
                    {2,1 },
                    {2,-1 },
                    // Left hand side
                    {-1,2 },
                    {-1,-2 },
                    {-2,1 },
                    {-2,-1 }

                };
        }
        void init()
        {
            initMoveSet();
        }
        public Rook(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.rookB);
            else this.setId(ePiece.rookW);
            init();
        }


    }
}