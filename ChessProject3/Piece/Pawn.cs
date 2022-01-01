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
            dynamicMoveSet = true;
        }
        protected override TupleList<int, int> getDynamicMovesList(int pieceX, int pieceY)
        {
            TupleList<int, int> list;
            if (this.getId() == ePiece.pawnB)
            {

                list = new TupleList<int, int> { { pieceX, pieceY+1 } };
                if (firstMove)
                {
                    list.Add(pieceX, pieceY+2);
                }

            }
            else
            {
                list = new TupleList<int, int> { { pieceX, pieceY -1 } };
                if (firstMove)
                {
                    list.Add(pieceX, pieceY-2);
                }

            }
            firstMove = false;
            return list;
        }
        public Pawn(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.pawnB);
            else this.setId(ePiece.pawnW);
            init();
        }

    }
}
