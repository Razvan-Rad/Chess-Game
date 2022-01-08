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
            staticMoveSet = true;

            moves = new List<Tuple<int, int>>
                {   // Right hand side
                    Tuple.Create(1,2),
                    Tuple.Create(1,-2),
                    Tuple.Create(2,1 ),
                    Tuple.Create(2,-1 ),
                    // Left hand side
                    Tuple.Create(-1,2 ),
                    Tuple.Create(-1,-2 ),
                    Tuple.Create(-2,1 ),
                    Tuple.Create(-2,-1 )

                };
        }
        public Horse(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.horseB);
            else this.setId(ePiece.horseW);
            init();
        }
        protected override List<Tuple<int,int>> parseDynamicMoveList(int pieceX, int pieceY, bool firstMove = true)
        {
            throw new NotImplementedException();
        }
        public override List<Tuple<int, int>> parseSpecialMoveList(int pieceX, int pieceY, bool firstMove = true)
        {
            if (specialMoveSet)
            {
                throw new NotImplementedException();
            }
            return null;
        }

    }
}