using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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
        void sendData(int x, int y, int dx, int dy)
        {

        }
        public void clickTile(int x, int y)
        {

            if (!alreadySelectedASquare) //Select first piece
            {
                if (game.squareSelectionSuccess(x, y))
                {
                    selected = new Point(x, y);
                    //Drawing range
                    alreadySelectedASquare = true;
                    painter.paintRange(game.getAllMoves(x, y));
                }
            }
            else //select 2nd piece
            {

                //MOVE SAFEGUARD
                if (Form1.server)
                {
                    if (game.round % 2 == 1)
                    {
                        alreadySelectedASquare = false;
                        painter.draw(true);

                        return;
                    }
                }
                if (Form1.client)
                {
                    if (game.round % 2 == 0)
                    {
                        alreadySelectedASquare = false;
                        painter.draw(true);

                        return;


                    };
                }


                if (!isSamePiece(x, y) && game.movePiece(selected.X, selected.Y, x, y)) //move confirmed
                {



                    //post move
                    game.round++;
                    sendData(selected.X, selected.Y, x, y);
                    Move mv = new Move(selected.X, selected.Y, x, y);
                    selected = new Point(x, y);
                    game.pastMoves.Add(mv);
                    game.updatePromotion();
                }
                alreadySelectedASquare = false;
                painter.draw(true);


            }

        }
    }
}
