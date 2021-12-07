using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessProject3
{


    public class Board
    {
        iPiece[,] tile;
        iPiece[] pieceList = new iPiece[13];
        void initPieceList()
        {
            bool black = true;
            pieceList[1] = new Pawn();
            pieceList[2] = new Rook();
            pieceList[3] = new Bishop();
            pieceList[4] = new Horse();
            pieceList[5] = new King();
            pieceList[6] = new Queen();

            pieceList[7] = new Pawn(black);
            pieceList[8] = new Rook(black);
            pieceList[9] = new Bishop(black);
            pieceList[10] = new Horse(black);
            pieceList[11] = new King(black);
            pieceList[12] = new Queen(black);
        }
        public Board(int x, int y)
        {
            tile = new iPiece[x, y];
            initPieceList();
            initPiecesDefault();
        }
        
        public void setTile(int x, int y, iPiece val)
        {
            tile[x,y] = val;
        }
        public void setTile(int x, int y, ePiece val)
        {
            tile[x, y] = pieceList[(int)val];
        }
        public iPiece getTile(int x, int y)
        {
            return tile[x, y];
        }
        void initPiecesDefault()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(i);
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
