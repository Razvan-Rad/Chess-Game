using System.Drawing;
using System.Windows.Forms;
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
            if (alreadySelectedASquare) //Select where to move to
            {
                if (!isSamePiece(x, y) && game.movePiece(selectedPiece.X, selectedPiece.Y, x, y))
                {
                    game.round++;
                }
                alreadySelectedASquare = false;
                selectedPiece = new Point(x, y);
                painter.draw(true);
            }
            else //Select first piece
            {
                if (game.squareSelectionSuccess(x, y))
                {
                    selectedPiece = new Point(x, y);
                    //Drawing range
                    alreadySelectedASquare = true;
                    painter.paintRange(game.getAllMoves(x, y));
                }
            }

        }
    }
}
