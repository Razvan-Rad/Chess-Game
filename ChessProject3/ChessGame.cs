using System;
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
        PanelPainter painter;
        ChessLogic game;
       public ChessGame(Panel p, int maxX, int maxY)
        {
            board = new Board(maxX, maxY);
            game = new ChessLogic(board);
            painter = new PanelPainter(ref p,ref board);
        }
        public void Run()
        {
            game.nextRound();
        }
    }
}
