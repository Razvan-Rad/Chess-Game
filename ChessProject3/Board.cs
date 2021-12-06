using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ChessProject3
{

    class Board
    {
        uint[,] tile;
        public Board(uint x, uint y)
        {
            tile = new uint[x, y];
            initPiecesDefault();
        }
        
        public void setTile(uint x, uint y, ePiece val = 0)
        {
                tile[x,y] = (uint)val;
        }
        public uint getTile(uint x, uint y)
        {
            return tile[x, y];
        }
        void initPiecesDefault()
        {
            for (uint i = 0; i < 8; i++)
            {
                setTile(i, 1, ePiece.pawnW);
                setTile(i, 6, ePiece.pawnW);
            }

            setTile(0, 0, ePiece.rookW);
            setTile(7, 0, ePiece.rookW);

            setTile(0, 7, ePiece.rookB);
            setTile(7, 7, ePiece.rookB);

            setTile(1, 0, ePiece.horseW);
            setTile(6, 0, ePiece.horseW);

            setTile(1, 7, ePiece.horseB);
            setTile(6, 7, ePiece.horseB);

            setTile(2, 0, ePiece.bishopW);
            setTile(5, 0, ePiece.bishopW);

            setTile(2, 7, ePiece.bishopB);
            setTile(5, 7, ePiece.bishopB);

            setTile(3, 0, ePiece.kingW);
            setTile(4, 0, ePiece.queenW);

            setTile(3, 7, ePiece.kingB);
            setTile(4, 7, ePiece.queenB);
        }
    }
}
