using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
   public class Horse : iPiece
    {
        protected override void init()
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
        public Horse(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.horseB);
            else this.setId(ePiece.horseW);
            init();
        }
        protected override TupleList<int,int> getDynamicMoveList(int pieceX, int pieceY, bool firstMove = true)
        {
            throw new NotImplementedException();
        }

    }
}