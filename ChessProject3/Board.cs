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
       public iPiece[,] tile;
        iPiece[] pieceMap = new iPiece[13];
 
        public Board(int x, int y)
        {
            tile = new iPiece[x, y];
        }
        
        public ePiece ePiecegetTile(int x, int y)
        {
            return tile[x, y].getId();
        }
        public void moveTile(int oldX, int oldY, int newX, int newY)
        {
            tile[newX, newY] = tile[oldX, oldY];
            tile[oldX, oldY] = null;    
        }
        public ref iPiece getTile(int x, int y)
        {
            return ref tile[x, y];
        }
      
    }
}
