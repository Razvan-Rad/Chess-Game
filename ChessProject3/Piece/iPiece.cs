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
        public bool dynamicMoveSet = false;
        public bool staticMoveSet = false;
        protected bool specialMoveSet = false;
        public void setSpecialMove(bool set)
        {
            specialMoveSet = set;
        }
        ePiece id = ePiece.none;
        public bool isSameAs(ePiece piece)
        {
            return (int)id % 6 == (int)piece % 6;
        }
        public ePiece getId() => id;
        protected void setId(ePiece id) => this.id = id;
        protected List<Tuple<int,int>> moves { get; set; }
        protected abstract void init();
        public List<Tuple<int, int>> getUnfilteredStatic(int pieceX, int pieceY)
        {
            if (staticMoveSet)
            {
                return filterBounds(pieceX,pieceY,staticToDynamic(pieceX, pieceY, getStaticMoveList()));
            }
            return null;
        }
        public List<Tuple<int, int>> getUnfilteredDynamic(int pieceX, int pieceY)
        {
            if (dynamicMoveSet)
            {
                return filterBounds(pieceX,pieceY,getDynamicMoveList(pieceX, pieceY));
            }
            return null;
        }
        List<Tuple<int, int>> filterBounds(int pieceX, int pieceY, List<Tuple<int, int>> mv)
        {
            List<Tuple<int, int>> ret = new List<Tuple<int, int>>();
            foreach (var move in mv)
            {
                var destX = move.Item1;
                var destY = move.Item2;

                if (destX < 8 && destY < 8 &&
                 destX >= 0 && destY >= 0)
                {
                    ret.Add(move);
                }
            }
            return ret;
        }

        List<Tuple<int, int>> staticToDynamic(int pieceX, int pieceY, List<Tuple<int, int>> mv)
        {
            List<Tuple<int, int>> ret = new List<Tuple<int, int>>();
            foreach (var move in mv)
            {
                int offsetX = move.Item1;
                int offsetY = move.Item2;

                int destX = pieceX + offsetX;
                int destY = pieceY + offsetY;
                
                ret.Add(Tuple.Create(destX, destY));
            }
            return ret;
        }
       
        protected abstract List<Tuple<int, int>> getDynamicMoveList(int pieceX, int pieceY, bool firstMove = true);
        public abstract List<Tuple<int, int>> getSpecialMoveList(int pieceX, int pieceY, bool firstMove = true);
        public List<Tuple<int,int>> getStaticMoveList() => moves;

       

    }
}
