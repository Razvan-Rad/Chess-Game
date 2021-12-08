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
        Panel p;
        Board b;

        Color black = Color.FromArgb(255, 240, 217, 181);
        Color white = Color.FromArgb(255, 181, 136, 99);

        public PanelPainter(ref Panel target, ref Board board)
        {
            this.p = target;
            this.b = board;
            updateAll();

        }
        void drawPiece(int x, int y)
        {
            Graphics g = Graphics.FromImage(p.BackgroundImage);
            //g.CompositingMode = CompositingMode.SourceOver;

            iPiece currentPiece = b.getTile(x, y);
            g.DrawImage(sprites[currentPiece.getId()], new Point(x * 61, y * 61));

        }
        void updateBg(int size)
        {
            Bitmap bm = new Bitmap(800, 800);
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
        void updateAll()
        {
            int squareSize = 60;
            updateBg(squareSize);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(b.getTile(i,j) != null)
                    {
                        drawPiece(i, j);
                    }
                }
            }
        }
        public void draw()
        {
            updateAll();
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
            {ePiece.kingW, Resource.WhiteKing},
            {ePiece.pawnW , Resource.WhitePawn},
            {ePiece.queenW , Resource.WhiteQueen },

        };
    }
}
