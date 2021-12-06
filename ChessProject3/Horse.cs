using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject3
{
    class Horse : Piece
    {
        protected override void initMoveSet()
        {
            moves = new TupleList<int, int>
                {   // Right hand side
                    {1,2},
                    {1,-2},
                    {2,1 },
                    {2,-1 },
                    // Left hand side
                    {-1,2 },
                    {-1,-2 },
                    {-2,1 },
                    {-2,-1 }

                };
        }
        public Horse()
        {
            initMoveSet();
        }

        public override List<Tuple<int, int>> getValidMoveList(int horseX, int horseY)
        {
            List<Tuple<int, int>> list = new List<Tuple<int, int>>();

            for (int i = 0; i < moves.Capacity; i++)
            {
                int offsetX = moves[i].Item1;
                int offsetY = moves[i].Item2;

                int destX = horseX + offsetX;
                int destY = horseY + offsetY;

                if (destX < 8 && destY < 8 &&
                 destX >= 0 && destY >= 0)
                {

                    Tuple<int, int> move = new Tuple<int, int>(destX, destY);
                    list.Add(move);
                }

            }
            return list;
        }
    }
}