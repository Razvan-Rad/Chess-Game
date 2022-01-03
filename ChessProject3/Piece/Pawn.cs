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
        protected override List<Tuple<int, int>> getDynamicMoveList(int pieceX, int pieceY, bool resetMove = true)
        {
            List<Tuple<int, int>> newMoves;
            if (this.getId() == ePiece.pawnB)
            {
                newMoves = new List<Tuple<int, int>> { Tuple.Create(pieceX, pieceY + 1) };
                if (firstMove)
                {
                    newMoves.Add(Tuple.Create(pieceX, pieceY + 2));
                }
            }
            else
            {
                newMoves = new List<Tuple<int, int>> { Tuple.Create(pieceX, pieceY - 1) };
                if (firstMove)
                {
                    newMoves.Add(Tuple.Create(pieceX, pieceY - 2));
                }

            }
            moves = newMoves;

            if (resetMove)
            {
                firstMove = false;
            }

            return newMoves;
        }
        public Pawn(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.pawnB);
            else this.setId(ePiece.pawnW);
            init();
        }

    }
}
