using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChessProject3
{
    public enum ePiece : int
    {
        pawnW = 1,
        rookW = 2,
        bishopW = 3,
        horseW = 4,
        kingW = 5,
        queenW = 6,

        pawnB = 7,
        rookB = 8,
        bishopB = 9,
        horseB = 10,
        kingB = 11,
        queenB = 12,

        none = 0
    }


    public class TupleList<T1, T2> : List<Tuple<T1, T2>>
    {
    
    }

    public abstract class iPiece
    {
        protected bool dynamicMoveSet = false;
        protected bool staticMoveSet = false;
        ePiece id = ePiece.none;
        public bool isSameAs(ePiece piece)
        {
            return (int)id % 6 == (int)piece % 6;
        }
        public ePiece getId() => id;
        protected void setId(ePiece id) => this.id = id;
        protected List<Tuple<int,int>> moves { get; set; }
        protected abstract void init();
        public List<Tuple<int,int>> getUnfilteredMoves(int pieceX, int pieceY)
        {
            List<Tuple<int,int>> list = new List<Tuple<int,int>>();
            if (staticMoveSet)
            {
                List<Tuple<int,int>> staticMoves = filterStaticBounds(pieceX, pieceY, getStaticMoveList());
                list.AddRange(staticMoves);
            }
            if(dynamicMoveSet)
            {
                List<Tuple<int,int>> dynamicMoves = getDynamicMoveList(pieceX, pieceY);
                list.AddRange(dynamicMoves);
            }
            return list;
        }
        List<Tuple<int,int>> filterStaticBounds(int pieceX, int pieceY, List<Tuple<int,int>>mv)
        {
            List<Tuple<int,int>> ret = new List<Tuple<int,int>>();
            for (int i = 0; i < mv.Count; i++)   //THIS IS NOT COPIED
            {
                int offsetX = mv[i].Item1;
                int offsetY = mv[i].Item2;

                int destX = pieceX + offsetX;
                int destY = pieceY + offsetY;

                if (destX < 8 && destY < 8 &&
                 destX >= 0 && destY >= 0)
                {

                    Tuple<int, int> move = Tuple.Create(destX, destY);
                    ret.Add(move);
                }

            }
            return ret;
        }
        protected abstract List<Tuple<int,int>> getDynamicMoveList(int pieceX, int pieceY, bool firstMove = true);
        public List<Tuple<int,int>> getStaticMoveList() => moves;

       

    }
}
