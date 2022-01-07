using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
namespace ChessProject3
{
    public class ChessGame
    {
        Board board;
        bool alreadySelectedASquare = false;
        Point selected;
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
            return x == selected.X && y == selected.Y;
        }

        List<move> pastMoves = new List<move>();
        public void clickTile(int x, int y)
        {
            if (alreadySelectedASquare) //Select where to move to
            {
                if (!isSamePiece(x, y) && game.movePiece(selected.X, selected.Y, x, y))
                {
                    move mv = new move(x, y, selected.X, selected.Y);
                    pastMoves.Add(mv);
                    game.round++;
                }
                alreadySelectedASquare = false;
                selected = new Point(x, y);
                painter.draw(true);
            }
            else //Select first piece
            {
                if (game.squareSelectionSuccess(x, y))
                {
                    selected = new Point(x, y);
                    //Drawing range
                    alreadySelectedASquare = true;
                    painter.paintRange(game.getAllMoves(x, y));
                }
            }

        }
    }
}
