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
            staticMoveSet = true;
            specialMoveSet = true;
            moves = new List<Tuple<int, int>>
                {
                Tuple.Create(0,1),
                Tuple.Create(1,0),
                Tuple.Create(1,1),
                Tuple.Create(1,-1),
                Tuple.Create(0,-1),
                Tuple.Create(-1,0),
                Tuple.Create(-1,1),
                Tuple.Create(-1,-1),
                Tuple.Create(-1,0)
                };
        }
        protected override List<Tuple<int, int>> parseDynamicMoveList(int pieceX, int pieceY, bool firstMove = true)
        {
            throw new NotImplementedException();
        }
        public King(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.kingB);
            else this.setId(ePiece.kingW);
            init();
        }
        public override List<Tuple<int, int>> parseSpecialMoveList(int pieceX, int pieceY, bool firstMove = true)
        {
            if (specialMoveSet)
            {
                List<Tuple<int, int>> newMoves = new List<Tuple<int, int>>();

                newMoves.Add(Tuple.Create(pieceX + 2, pieceY));
                newMoves.Add(Tuple.Create(pieceX - 2, pieceY));

                return newMoves;

            }
            return null;
        }
    }
}
