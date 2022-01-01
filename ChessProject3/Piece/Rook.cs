using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
    public class Rook : iPiece
    {
        protected override void init()
        {
            moves = new TupleList<int, int>
            {

            };
        }
        protected override TupleList<int, int> getDynamicMovesList(int pieceX, int pieceY)
        {
            throw new NotImplementedException();
        }
        public Rook(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.rookB);
            else this.setId(ePiece.rookW);
            init();
        }


    }
}