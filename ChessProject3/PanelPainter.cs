using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ChessProject3
{

    class PanelPainter
    {
        public static Dictionary<ePiece, Image> sprites = new Dictionary<ePiece, Image>()
        {
            {ePiece.rookB , Resource.BlackRook },
            {ePiece.bishopB , Resource.BlackBishop },
            {ePiece.horseB, Resource.BlackKnight},
            {ePiece.kingB, Resource.BlackKing},
            {ePiece.pawnB , Resource.BlackPawn},
            {ePiece.queenB , Resource.BlackBishop},
             
            {ePiece.rookW , Resource.WhiteRook},
            {ePiece.bishopW , Resource.WhiteBishop},
            {ePiece.horseW, Resource.WhiteKnight},
            {ePiece.kingW, Resource.WhiteKing},
            {ePiece.pawnW , Resource.WhitePawn},
            {ePiece.queenW , Resource.WhiteQueen },

        };
        public PanelPainter(Panel p)
        {

        }
    }
}
