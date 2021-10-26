using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {



        bool a, d;
        Timer timer;
        Snake snake1;
        PictureBox player1;
        List<PictureBox> player1tail;

        //novy
        bool f, j;
        Timer timer2;
        Snake2 snake2;
        PictureBox player2;
        List<PictureBox> player1tail2;
        private Point startPoint1;
        private Point startPoint2;

        public Form1()
        {

            
          

            InitializeComponent();
            timer = new Timer();
            timer.Interval = 40;
            timer.Tick += Timer_Tick;
            snake1 = new Snake();
            snake1.Speed = 5;
            player1tail = new List<PictureBox>();
            player1 = snake1.GetHead(Color.Blue, 10);
            this.Controls.Add(player1);

            snake2 = new Snake2();
            snake2.Speed = 5;
            player1tail2 = new List<PictureBox>();
            player2 = snake2.GetHead(Color.Red, 10);
            this.Controls.Add(player2);

            timer.Start();
        }

        private void CenterMenu()
        {
            panel1.Top = 0;
            panel1.Left = ClientSize.Width / 2 - panel1.Width / 2;
            startPoint1 = new Point();
            startPoint2 = new Point();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (a)
            {
                snake1.TurnLeft();
            }
            else if (d)
            {
                snake1.TurnRight();
            }

            if (f)
            {
                snake2.TurnLeft();
            }
            else if (j)
            {
                snake2.TurnRight();
            }

            player1tail.Add(player1);
            snake1.Forward();
            player1 = snake1.GetHead(Color.Blue, 10);
            this.Controls.Add(player1);


            player1tail2.Add(player2);
            snake2.Forward();
            player2 = snake2.GetHead(Color.Red, 10);
            this.Controls.Add(player2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
            if (timer.Enabled)
            {
                button1.BackgroundImage = Properties.Resources.pause;
            }
            else
            {
                button1.BackgroundImage = Properties.Resources.play;
            }
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            CenterMenu();
        }

       
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                a = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                d = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                f = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                j = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                a = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                d = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                f = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                j = true;
            }

        }
    }
}
