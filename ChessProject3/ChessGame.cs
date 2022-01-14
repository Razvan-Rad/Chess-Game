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
        public void clickTile(int x, int y)
        {
            if(Form1.data!=null)
            {
                int coord1 =Form1.data[0] - 48;
                int coord2 = Form1.data[1] - 48;
                int coord3 = Form1.data[2] - 48;
                int coord4 = Form1.data[3] -48;
                game.movePieceRetea(coord1, coord2, coord3, coord4);
                Form1.data = null;
                game.round++;
                Move mv = new Move(selected.X, selected.Y, x, y);
                selected = new Point(x, y);
                game.pastMoves.Add(mv);
                game.updatePromotion();
            }


            if (!alreadySelectedASquare) // Select first piece
            {
                if (game.squareSelectionSuccess(x, y))
                {
                    selected = new Point(x, y);
                    //Drawing range
                    alreadySelectedASquare = true;
                    painter.draw(true);
                }
            }
            else // Select 2nd piece
            {

                //MOVE SAFEGUARD
                if (Form1.server)
                {
                    if (game.round % 2 == 1)
                    {
                        alreadySelectedASquare = false;
                        return;
                    }
                }
                else if (Form1.client)
                {
                    if (game.round % 2 == 0)
                    {
                        alreadySelectedASquare = false;
                        return;


                    };
                }


                if (!isSamePiece(x, y) && game.movePiece(selected.X, selected.Y, x, y)) //move confirmed
                {
                    Form1.sendData(selected.X, selected.Y, x, y);

                    //post move
                    game.round++;
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
