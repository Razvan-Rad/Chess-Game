using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessProject3
{
    public partial class Form1 : Form
    {
        ChessGame game;
        public Form1()
        {
            InitializeComponent();
            game = new ChessGame(panel1, 8, 8);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point point = panel1.PointToClient(Cursor.Position);
            int x = point.X / 60;
            int y = point.Y / 60;
            game.clickTile(x, y);
            
            //MessageBox.Show("x: " + x.ToString(), y.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
