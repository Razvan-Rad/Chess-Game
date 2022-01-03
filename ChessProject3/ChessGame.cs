﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace ChessProject3
{
    public class ChessGame
    {
        Board board;
        bool alreadySelectedASquare = false;
        Point selectedPiece;
        PanelPainter painter;
        ChessLogic game;
        public ChessGame(Panel p, int maxX, int maxY)
        {
            //vars
            board = new Board(maxX, maxY);
            int squareSize = 60;

            //obj
            game = new ChessLogic(board);
            painter = new PanelPainter(ref p, ref board, squareSize);

            //non-necessary init
            painter.drawAllPieces();

            //post init

        }
        bool isSamePiece(int x, int y)
        {
            return x == selectedPiece.X && y == selectedPiece.Y;
        }
        public void clickTile(int x, int y)
        {
            //1
            if (alreadySelectedASquare) //Select where to move to
            {
                if (!isSamePiece(x, y))
                {
                   game.movePiece(selectedPiece.X, selectedPiece.Y, x, y);
                   game.round++;
                }
                selectedPiece = new Point(x, y);
                alreadySelectedASquare = false;
                painter.draw(true);
            }
            else //Select first piece
            {
                if (game.squareSelectionSuccess(x, y))
                {
                    selectedPiece = new Point(x, y);
                    //Drawing range
                    var moves = game.getAllMoves(selectedPiece.X, selectedPiece.Y);
                    alreadySelectedASquare = true;
                    painter.paintRange(moves);
                }
            }
        }
    }
}
