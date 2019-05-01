using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        Timer timer;
        //public static Graphics g;
        Pacman pacman;
        static readonly int TIMER_INTERVAL = 250;
        static readonly int WORLD_WIDTH = 15;
        static readonly int WORLD_HEIGHT = 10;
        Image foodImage;
        bool[][] foodWorld;
        public Form1()
        {
            InitializeComponent();
            foodImage = Properties.Resources.pear;
            //foodImage.Width = Pacman.RADIUS * 2;
            
            DoubleBuffered = true;
            newGame();
        }

        void newGame() {
            pacman = new Pacman();
            //Thread.Sleep(3000);
            this.Width = Pacman.RADIUS * 2 * (WORLD_WIDTH + 1);
            this.Height = Pacman.RADIUS * 2 * (WORLD_HEIGHT + 1);

            foodWorld = new bool[WORLD_WIDTH][];
            for (int i = 0; i < WORLD_WIDTH; i++)
            {
                foodWorld[i] = new bool[WORLD_HEIGHT];
                for (int j = 0; j < WORLD_HEIGHT; j++)
                {
                    foodWorld[i][j] = true;
                }
            }
            
            timer = new Timer();
            timer.Interval = TIMER_INTERVAL;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            //pacman.Move(0,0);
            Invalidate();
        }

        void timer_Tick(object sender, EventArgs e) {
            for (int i = 0; i < WORLD_WIDTH; i++)
            {
                for (int j = 0; j < WORLD_HEIGHT; j++)
                {
                    foodWorld[pacman.posX][pacman.posY] = false;
                }
            }
            pacman.Move(WORLD_WIDTH,WORLD_HEIGHT);
            Invalidate();
        }

        /*private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            // Graphics g = canvas.CreateGraphics();
            //pacman.Draw(g);
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            for (int i = 0; i < foodWorld.Length; i++)
            {
                for (int j = 0; j < foodWorld[i].Length; j++)
                {
                    if (foodWorld[i][j]) {
                        g.DrawImageUnscaled(foodImage,i,j);
                        //g.DrawImage(foodImage,i,j);
                    }
                }
            }
            pacman.Draw(g);
        }*/
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            for (int i = 0; i < foodWorld.Length; i++)
            {
                for (int j = 0; j < foodWorld[i].Length; j++)
                {
                    if (foodWorld[i][j])
                    {
                        g.DrawImageUnscaled(foodImage, i,j);
                        //g.DrawImage(foodImage,i,j);
                    }
                }
            }
            pacman.Draw(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
