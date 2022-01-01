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
        public void merge(List<Tuple<T1,T2>> list)
        {

            foreach(Tuple<T1,T2> iter in list)
            {
                Add(iter); 
            }
        }
        public void Add(T1 item, T2 item2)
        {
            Add(Tuple.Create(item, item2));
        }
    }

    public abstract class iPiece
    {
       protected bool dynamicMoveSet = false;
        ePiece id = ePiece.none;
        public ePiece getId() => id;
        protected void setId(ePiece id) => this.id = id;
        protected TupleList<int, int> moves { get; set; }
        protected abstract void init();
        void resetCustomMoves()
        {
            moves = null;
        }
        protected abstract TupleList<int,int> getDynamicMovesList(int pieceX, int pieceY);
        public List<Tuple<int, int>> getValidMoveList(int pieceX, int pieceY)
        {

            //check for dynamic
            if (dynamicMoveSet)
            {
                return getDynamicMovesList(pieceX, pieceY);
            }
            //check for hard coded
            else
            {
                List<Tuple<int, int>> list = new List<Tuple<int, int>>();

                for (int i = 0; i < moves.Count; i++)
                {
                    int offsetX = moves[i].Item1;
                    int offsetY = moves[i].Item2;

                    int destX = pieceX + offsetX;
                    int destY = pieceY + offsetY;

                    if (destX < 8 && destY < 8 &&
                     destX >= 0 && destY >= 0)
                    {

                        Tuple<int, int> move = Tuple.Create(destX, destY);
                        list.Add(move);
                    }

                }

                return list;

            }
        }

    }
}
