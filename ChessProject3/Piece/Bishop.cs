using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
   public class Bishop : iPiece
    {
        protected override void init()
        {
            moves = new TupleList<int, int>
                {  
                };
        }
        protected override TupleList<int,int> getDynamicMovesList(int pieceX, int pieceY)
        {
            throw new NotImplementedException();
        }
        public Bishop(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.bishopB);
            else this.setId(ePiece.bishopW);
            init();
        }


    }
}