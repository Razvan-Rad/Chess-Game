using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ChessProject3
{
    public partial class Form1 : Form
    {


        public static string data = null;
        public static string toSend = null;
        public static string received = null;
        public static bool server = false;
        public static bool client = false;
        static Socket handler; 
        static Socket sender;
        Socket listener;
        public static void sendData(int x, int y, int dx, int dy)
        {
            var moves = new byte[] { (byte)(x+48), (byte)(y + 48), (byte)(dx + 48), (byte)(dy + 48 )};
            if (server)
            {
                handler.Send(moves);
            }
            if (client)
            {
                sender.Send(moves);
            }
        }
        public void StartServer()
        {
            IPAddress ipAddress = IPAddress.Parse(textBox1.Text);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, Int32.Parse(textBox2.Text));
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);

                listener.Listen(10);
                handler = listener.Accept();

                byte[] bytes = null;

                while (true)
                {
                    bytes = new byte[4];
                    int bytesRec = handler.Receive(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                }   
        }
        /// <summary>
        ///////
        ///
        /// 
        /// 
        /// 
        /// 
        /// </summary>

        public void StartClient()
        {

            try
            {
                IPAddress ipAddress = IPAddress.Parse(textBox1.Text);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 23);

                // Create a TCP/IP  socket.
                 sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    // Connect to Remote EndPoint
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());
                    while(true)
                    {

                        // Receive the response from the remote device.
                        byte[] bytes = new byte[4];
                        int bytesRec = sender.Receive(bytes);
                       data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        // Move ready
                    }
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        ///////
        ///
        /// 
        /// 
        /// 
        /// 
        /// </summary>

        ChessGame game;
        public Form1()
        {
            InitializeComponent();
            game = new ChessGame(panel1, 8, 8);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point point = panel1.PointToClient(Cursor.Position);
            int x = point.X / 60;
            int y = point.Y / 60;
            if ((x < 8 && y < 8) && (x >= 0 && y >= 0))
            {
                game.clickTile(x, y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (server || client) return;

            client = true;
            Thread thread = new Thread(new ThreadStart(StartClient));
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (server || client) return;

            server = true;
            Thread thread = new Thread(new ThreadStart(StartServer));
            thread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}