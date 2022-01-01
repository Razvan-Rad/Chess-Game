using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ChessProject3
{

    class PanelPainter
    {
        int squareSize;
        Panel p;
        Board b;
        Color black = Color.FromArgb(255, 240, 217, 181);
        Color white = Color.FromArgb(255, 181, 136, 99);

        Bitmap bm;
        public PanelPainter(ref Panel target, ref Board board, int squareSize)
        {
            this.p = target;
            this.b = board;
            this.squareSize = squareSize;
            bm = new Bitmap(squareSize * 12, squareSize * 12);
            refreshBg(squareSize);
        }
        public void paintRange(List<Tuple<int, int>> list)
        {
            draw();
            using (Graphics g = Graphics.FromImage(p.BackgroundImage))
            using (SolidBrush pinkBrush = new SolidBrush(Color.FromArgb(129, Color.Pink)))
                for (int i = 0; i < list.Count; i++)
                {
                    g.FillRectangle(pinkBrush, list[i].Item1 * 60, list[i].Item2 * 60, 60, 60);
                }
            update();
        }
        void drawPiece(int x, int y)
        {
            Graphics g = Graphics.FromImage(p.BackgroundImage);
            g.CompositingMode = CompositingMode.SourceOver;

            iPiece currentPiece = b.getTile(x, y);
            g.DrawImage(sprites[currentPiece.getId()], new Point(x * 61, y * 61));

        }
        void refreshBg(int size = 60)
        {
            using (Graphics g = Graphics.FromImage(bm))
            using (SolidBrush blackBrush = new SolidBrush(black))
            using (SolidBrush whiteBrush = new SolidBrush(white))
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if ((j % 2 == 0 && i % 2 == 0) || (j % 2 != 0 && i % 2 != 0))
                            g.FillRectangle(blackBrush, i * size, j * size, size, size);
                        else if ((j % 2 == 0 && i % 2 != 0) || (j % 2 != 0 && i % 2 == 0))
                            g.FillRectangle(whiteBrush, i * size, j * size, size, size);
                    }
                }
                p.BackgroundImage = bm;
            }
        }
        public void draw(bool bg = false)
        {
            if(bg)refreshBg(60);
            drawAllPieces();
            update();
        }
        public void update()
        {
            p.Refresh();
        }
        public void drawAllPieces()
        {

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (b.getTile(i, j) != null)
                    {
                        drawPiece(i, j);
                    }
                }
            }
        }

        public static Dictionary<ePiece, Image> sprites = new Dictionary<ePiece, Image>()
        {
            {ePiece.rookB , Resource.BlackRook },
            {ePiece.bishopB , Resource.BlackBishop},
            {ePiece.horseB, Resource.BlackKnight},
            {ePiece.kingB, Resource.BlackKing},
            {ePiece.pawnB , Resource.BlackPawn},
            {ePiece.queenB , Resource.BlackQueen},

            {ePiece.rookW , Resource.WhiteRook},
            {ePiece.bishopW , Resource.WhiteBishop},
            {ePiece.horseW, Resource.WhiteKnight},
            {ePiece.kingW, Resource.WhiteQueen},
            {ePiece.pawnW , Resource.WhitePawn},
            {ePiece.queenW , Resource.WhiteKing },

        };
    }
}
