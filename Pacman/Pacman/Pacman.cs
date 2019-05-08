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
        public enum ANGLE {
            RIGHT_ANGLE = 45, LEFT_ANGLE =225, UP_ANGLE=315, DOWN_ANGLE=135 
        }
        
        public static Brush brush=
            new SolidBrush(Color.DarkOrange);

        public int posX { get; set; }
        public int posY { get; set; }
        public const int RADIUS= 20;
        public float moveSpeed { get; set; }
        public bool isMouthOpen { get; set; }
        public DIRECTION direction;
        Image foodImage;
        public int Points { get; private set; }
        public static readonly int maxPoints = 126;
        ANGLE startAngle;

        public Pacman() {

            moveSpeed = RADIUS;
            posX = 5;
            posY = 7;
            direction = DIRECTION.RIGHT;
            isMouthOpen = false;
            foodImage = Properties.Resources.food;
            startAngle = ANGLE.RIGHT_ANGLE;
        }

        public void Draw(Graphics g) {
            if (isMouthOpen)
            {
                //g.FillPie(brush, posX, posY, RADIUS * 2, RADIUS * 2, 45, 270);
                g.FillPie(brush, new Rectangle(posY * Pacman.RADIUS * 2 + (Pacman.RADIUS * 2 - foodImage.Height) / 2, posX * Pacman.RADIUS * 2 + (Pacman.RADIUS * 2 - foodImage.Width) / 2, RADIUS * 2, RADIUS * 2), (int)startAngle, 270);
            }
            else {
                g.FillEllipse(brush, new Rectangle(posY * Pacman.RADIUS * 2 + (Pacman.RADIUS * 2 - foodImage.Height) / 2, posX * Pacman.RADIUS * 2 + (Pacman.RADIUS * 2 - foodImage.Width) / 2, RADIUS * 2, RADIUS * 2));
            }
        }
        public void ChangeDirection(DIRECTION direction)
        {
            this.direction = direction;
            setAngle(direction);
            //isMouthOpen = !isMouthOpen;
        }
        public void setAngle(DIRECTION direction) {
            if (direction == DIRECTION.RIGHT) {
                startAngle = ANGLE.RIGHT_ANGLE;
            }
            if (direction == DIRECTION.LEFT) {
                startAngle = ANGLE.LEFT_ANGLE;
            }
            if (direction == DIRECTION.UP) {
                startAngle = ANGLE.UP_ANGLE;
            }
            if (direction == DIRECTION.DOWN)
            {
                startAngle = ANGLE.DOWN_ANGLE;
            }
        }
        public void Move(int width, int height,List<Obstacle>obstacles) {
            if (InRange(obstacles,width,height) == false) {
                if (direction == DIRECTION.RIGHT)
                {
                    posY += 1;
                }
                if (direction == DIRECTION.UP)
                {
                    posX -= 1;
                }
                if (direction == DIRECTION.DOWN)
                {
                    posX += 1;
                }
                if (direction == DIRECTION.LEFT)
                {
                    posY -= 1;
                }
            }

            CheckOutOfBounds(width,height);
            isMouthOpen = !isMouthOpen;
        }
        private bool InRange(List<Obstacle> obstacles, int Width, int Height) {
            foreach (Obstacle o in obstacles) {
                if ((this.posY - 1 == o.Y||(this.posY==0&&o.Y==Width-1)) && (this.posX == o.X || this.posX == o.X + 1 || this.posX == o.X + 2) && direction == DIRECTION.LEFT)  {
                    return true;
                }
                if ((this.posY + 1 == o.Y || (this.posY == Width - 1 && o.Y == 0)) && (this.posX == o.X || this.posX == o.X + 1 || this.posX == o.X + 2) && direction == DIRECTION.RIGHT) 
                {
                    return true;
                }
                if (this.posY == o.Y && (this.posX - 3 == o.X || this.posX == 0 && o.X == Height - 3) && direction == DIRECTION.UP) 
                {
                    return true;
                }                        
                if (this.posY == o.Y && (this.posX + 1 == o.X || this.posX==Height-1&&o.X==0) && direction == DIRECTION.DOWN) 
                {
                    return true;
                }
            }
            return false; //default
        }

        public void CheckOutOfBounds(int Width, int Height) {
            if (posX < 0) {
                posX = Height - 1;
            }
            if (posX > Height - 1) {
                posX = 0;
            }
            if (posY < 0) {
                posY = Width - 1;
            }
            if (posY > Width - 1) {
                posY = 0;
            }
        }
        public void addPoint() {
            this.Points++;
        }
    }
}
