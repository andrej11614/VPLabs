using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman
{
    public class Obstacle
    {
        //public int Width { get; set; }
        //public int Height { get; set; }
        public Color color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        Image foodImage;
        Pen pen;
        static Random rnd=new Random();


        public Obstacle()
        {
            //Width = width;
            //Height = height;
            color = Color.Red;
            foodImage = Properties.Resources.food;
            pen = new Pen(color,3);

            //X = rnd.Next(8);
            //X += 7;
            //Y = rnd.Next(15);
            //Y += 3;
        }
        public void GeneratePosition() {
            //Random rand = new Random();
            
            X = rnd.Next(8);
            Y = rnd.Next(15);
        }

        public void Draw(Graphics g) {
            g.DrawRectangle(pen, new Rectangle(new Point(Y * Pacman.RADIUS * 2 + ((Pacman.RADIUS * 2 - foodImage.Height) / 2), X * Pacman.RADIUS * 2 + ((Pacman.RADIUS * 2 - foodImage.Width) / 2)), new Size(foodImage.Width*4, foodImage.Height*15)));
        }

    }
}
