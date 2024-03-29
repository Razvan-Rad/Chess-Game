﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
    class Queen : iPiece
    {
        protected override void init()
        {
            dynamicMoveSet = true;
        }

        protected override List<Tuple<int,int>> parseDynamicMoveList(int pieceX, int pieceY, bool firstMove = true)
        {
            moves = null;
            List<Tuple<int,int>> newMoves = new List<Tuple<int,int>> { };

            newMoves.AddRange(ChessLogic.getDynamicBishopMoves(pieceX, pieceY));
            newMoves.AddRange(ChessLogic.getDynamicRookMoves(pieceX, pieceY));

            return newMoves;
        }
        public Queen(bool isBlack = false)
        {
            if (isBlack) this.setId(ePiece.queenB);
            else this.setId(ePiece.queenW);
            init();
        }
        public override List<Tuple<int, int>> parseSpecialMoveList(int pieceX, int pieceY, bool firstMove = true)
        {
            if(specialMoveSet)
            {
                throw new NotImplementedException();


            }
            return null;
        }
    }
}
