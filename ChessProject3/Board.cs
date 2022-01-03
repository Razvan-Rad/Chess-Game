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
        iPiece[] pieceMap = new iPiece[13];
        void initPieceList()
        {
            bool black = true;
            pieceMap[1] = new Pawn();
            pieceMap[2] = new Rook();
            pieceMap[3] = new Bishop();
            pieceMap[4] = new Horse();
            pieceMap[5] = new King();
            pieceMap[6] = new Queen();

            pieceMap[7] = new Pawn(black);
            pieceMap[8] = new Rook(black);
            pieceMap[9] = new Bishop(black);
            pieceMap[10] = new Horse(black);
            pieceMap[11] = new King(black);
            pieceMap[12] = new Queen(black);
        }
        public Board(int x, int y)
        {
            tile = new iPiece[x, y];
            initPieceList();
        }
        
        public ePiece ePiecegetTile(int x, int y)
        {
            return tile[x, y].getId();
        }
        public void setTile(int x, int y, iPiece val)
        {
            tile[x,y] = val;
        }
        public void moveTile(int oldX, int oldY, int newX, int newY)
        {
            tile[newX, newY] = tile[oldX, oldY];
            tile[oldX, oldY] = null;    

        }
        public void moveTileSpecial(int oldX, int oldY, int newX, int newY)
        {
            tile[newX, newY] = tile[oldX, oldY];
            tile[oldX, oldY] = null;

        }
        public void setTile(int x, int y, ePiece val)
        {
            tile[x, y] = pieceMap[(int)val];
        }
        public ref iPiece getTile(int x, int y)
        {
            return ref tile[x, y];
        }
      
    }
}
