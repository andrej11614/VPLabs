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
        static readonly int TIMER_INTERVAL = 150;
        static readonly int WORLD_WIDTH = 15;
        static readonly int WORLD_HEIGHT = 10;
        Image foodImage;
        bool[][] foodWorld;
        List<Obstacle> obstacles;
        public int NUMBER_OBSTACLES;
        int MAX_POINTS;
        public bool isGameOver { get {
                return pacman.Points == MAX_POINTS;
            } }

        public Form1()
        {
            InitializeComponent();
            foodImage = Properties.Resources.food;
            //foodImage.Width = Pacman.RADIUS * 2;
            pbpoints.Minimum = 0;
            pbpoints.Maximum = 126;
            DoubleBuffered = true;
            NUMBER_OBSTACLES = 8;
            MAX_POINTS = 126;
            newGame();
        }
        private bool CheckValidObstacle(Obstacle obstacle) {
            foreach (Obstacle o in obstacles) {
                if (Math.Abs(obstacle.X - o.X) <= 3 && Math.Abs(obstacle.Y - o.Y) <= 1)
                    return false;
               /* if ((o.X == obstacle.X || o.X == obstacle.X + 1 || o.X == obstacle.X + 2||o.X==obstacle.X+3) && o.Y == obstacle.Y) {
                    return false;
                }*/   
            }
            if (obstacle.Y == pacman.posY && (obstacle.X == pacman.posX || obstacle.X == pacman.posX + 1 || obstacle.X == pacman.posX + 2))
            {
                return false;
            }
            return true;
        }

        void newGame() {
            pacman = new Pacman();
            //Thread.Sleep(3000);
            this.Width = Pacman.RADIUS * 2 * (WORLD_WIDTH + 1);
            this.Height = Pacman.RADIUS * 2 * (WORLD_HEIGHT + 1)+70;

            foodWorld = new bool[WORLD_HEIGHT][];
            for (int i = 0; i < WORLD_HEIGHT; i++)
            {
                foodWorld[i] = new bool[WORLD_WIDTH];
                for (int j = 0; j < WORLD_WIDTH; j++)
                {
                    foodWorld[i][j] = true;
                }
            }
            obstacles = new List<Obstacle>(NUMBER_OBSTACLES);
            for (int i = 0; i < 8; i++)
            {
                Obstacle obs = new Obstacle();
                while (!CheckValidObstacle(obs))
                    obs.GeneratePosition();
                obstacles.Add(obs);
                //obstacles.Add(new Obstacle());
            }
            //foodWorld[pacman.posX][pacman.posY] = false;
            pbpoints.Value = 0;
            
            timer = new Timer();
            timer.Interval = TIMER_INTERVAL;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            //pacman.Move(0,0);
            Invalidate();
        }
        void endGame() {
            timer.Dispose();
            //obstacles.Clear();
            if (MessageBox.Show("U win.Another game?", "New Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                newGame();
            }
            else {
                this.Close();
            }
        }
        void timer_Tick(object sender, EventArgs e) {
            pacman.Move(WORLD_WIDTH,WORLD_HEIGHT,obstacles);
            for (int i = 0; i < WORLD_HEIGHT; i++)
            {
                for (int j = 0; j < WORLD_WIDTH; j++)
                {
                    if (pacman.posX == i && pacman.posY == j && foodWorld[i][j]) {
                        foodWorld[i][j] = false;
                        pacman.addPoint();
                        tbpoeni.Text = pacman.Points.ToString();
                        pbpoints.Value++;
                    }
                }
            }
            Invalidate();
            if (isGameOver) endGame();
        }
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
                        g.DrawImageUnscaled(foodImage, j * Pacman.RADIUS * 2 + (Pacman.RADIUS * 2 - foodImage.Height) / 2, i * Pacman.RADIUS * 2 + (Pacman.RADIUS * 2 - foodImage.Width) / 2);
                        //g.DrawImage(foodImage,i,j);
                    }
                }
            }
            foreach (Obstacle o in obstacles) {
                o.Draw(g);
            }
            pacman.Draw(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                pacman.ChangeDirection(Pacman.DIRECTION.UP);
            }
            else if (e.KeyCode == Keys.Down) {
                pacman.ChangeDirection(Pacman.DIRECTION.DOWN);
            }
            else if (e.KeyCode == Keys.Right)
            {
                pacman.ChangeDirection(Pacman.DIRECTION.RIGHT);
            }
            else if (e.KeyCode == Keys.Left)
            {
                pacman.ChangeDirection(Pacman.DIRECTION.LEFT);
            }
            Invalidate();
        }
    }
}
