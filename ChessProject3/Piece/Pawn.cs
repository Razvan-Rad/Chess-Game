using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
    class Pawn : iPiece
    {
        protected override void init()
        {
            dynamicMoveSet = true;
            staticMoveSet = true;
            this.setSpecialMove(true);

            moves = new List<Tuple<int, int>>();
            if (this.getId() == ePiece.pawnB)
            {
                moves.Add(Tuple.Create(0, 1));
            }
            else
            {
                moves.Add(Tuple.Create(0, -1));
            }
        }
        protected override List<Tuple<int, int>> getDynamicMoveList(int pieceX, int pieceY, bool resetMove = true)
        {
            List<Tuple<int, int>> newMoves;
            if (this.getId() == ePiece.pawnB)
            {
                newMoves = new List<Tuple<int, int>> {
                    
                    Tuple.Create(pieceX +1, pieceY + 1),
                    Tuple.Create(pieceX -1, pieceY + 1)

                };
            }
            else
            {
                newMoves = new List<Tuple<int, int>> {
                    Tuple.Create(pieceX +1, pieceY - 1),
                    Tuple.Create(pieceX -1, pieceY - 1)

                };
            }

            return newMoves;
        }

        public override List<Tuple<int, int>> getSpecialMoveList(int pieceX, int pieceY, bool resetMove = true)
        {
            List<Tuple<int, int>> newMoves = new List<Tuple<int, int>>();

            if (this.getId() == ePiece.pawnB)
            {

                newMoves.Add(Tuple.Create(pieceX, pieceY + 2));
            }
            else
            {
                newMoves.Add(Tuple.Create(pieceX, pieceY - 2));

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
