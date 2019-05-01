using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Pacman
{
    class Pacman
    {
        public enum DIRECTION{
            LEFT,UP,RIGHT,DOWN
        }
        
        public static Brush brush=
            new SolidBrush(Color.Yellow);

        public int posX { get; set; }
        public int posY { get; set; }
        public const int RADIUS= 20;
        public float moveSpeed { get; set; }
        public bool isMouthOpen { get; set; }
        public DIRECTION direction;

        public Pacman() {

            moveSpeed = RADIUS;
            posX = 7;
            posY = 5;
            direction = DIRECTION.RIGHT;
            isMouthOpen = false;
        }

        public void Draw(Graphics g) {
            if (isMouthOpen)
            {
                g.FillPie(brush, posX, posY, RADIUS * 2, RADIUS * 2, 45, 270);
            }
            else {
                g.FillPie(brush, posX, posY, RADIUS*2, RADIUS*2, 5,350);
            }
        }
        public void ChangeDirection(DIRECTION direction)
        {
            this.direction = direction;
            isMouthOpen = !isMouthOpen;
        }
        public void Move(int x, int y) {
            //posX += 30;
            //Graphics g = Form1.g;
            //Draw(g);

        }
    }
}
