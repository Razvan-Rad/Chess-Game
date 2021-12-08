﻿using System;
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
        
        public void setTile(int x, int y, iPiece val)
        {
            tile[x,y] = val;
        }
        public void setTile(int x, int y, ePiece val)
        {
            tile[x, y] = pieceMap[(int)val];
        }
        public iPiece getTile(int x, int y)
        {
            return tile[x, y];
        }
      
    }
}
