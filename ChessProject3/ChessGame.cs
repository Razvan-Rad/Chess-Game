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
        ChessLogic logic;
       public ChessGame(Panel p, uint maxX, uint maxY)
        {
            board = new Board(maxX, maxY);
            logic = new ChessLogic(ref board);
            painter = new PanelPainter(p);
            logic.MovePiece(2, 3, 4, 5);
        }
    }
}
