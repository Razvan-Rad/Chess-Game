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
            dynamicMoveSet = true;
        }
        protected override List<Tuple<int,int>> getDynamicMoveList(int pieceX, int pieceY, bool firstMove = true)
        {
            moves = null;
            List<Tuple<int,int>> newMoves = new List<Tuple<int,int>> { };

            newMoves.AddRange(ChessLogic.getDynamicBishopMoves(pieceX, pieceY));
            moves = newMoves;
            return newMoves;

        }
        public Bishop(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.bishopB);
            else this.setId(ePiece.bishopW);
            init();
        }

        public override List<Tuple<int, int>> getSpecialMoveList(int pieceX, int pieceY, bool firstMove = true)
        {
            if(specialMoveSet)
            {

                throw new NotImplementedException();

            }
            return null;
        }
    }
}