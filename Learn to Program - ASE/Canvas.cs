using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Learn_to_Program___ASE
{
    class Canvas
    {
        //Graphics and pen initial data
        public Graphics g;
        public static Pen P1;
        public static int xPos = 0; // x position of pen
        public static int yPos = 0; // y position of pen
        public static int toX = 0; //what x position is changing to
        public static int toY = 0; //what y position is changing to
        public static int sizes = 0; //int used for square
        public static int sizec = 0; //int used for circle
        public static int sizerx = 0; //int used for rectangle x
        public static int sizery = 0; //int used for rectangle y    
        public static string colour = "black";
        //public void Clear(System.Drawing.Color White);

        public Canvas(Graphics g)
        {
            this.g = g;
            //xPos = yPos = 0;
            P1 = new Pen(Color.Black, 1); //sets initial pen to black and 1 pixel wide size

        }

        //public void Clear(Color White);

        //draw a line from current point
        public void DrawLine(int toX, int toY)
        {
            g.DrawLine(P1, xPos, yPos, toX, toY); //draw line
            xPos = toX;
            yPos = toY; //updates the pen position to where drawn to or end of line

        }

        //draw square at current point
        public void DrawSquare(int sizes)
        {
            //yPos = xPos;
            g.DrawRectangle(P1, xPos - sizes / 2, yPos - sizes / 2, sizes, sizes); //draw a square
        }

        //draw rectangle at current point
        public void DrawRect(int sizerx, int sizery)
        {
            g.DrawRectangle(P1, xPos - sizerx / 2, yPos - sizery / 2, sizerx, sizery); //draw a rectangle
        }


        public void DrawCircle(int sizec)
        {
            g.DrawEllipse(P1, xPos - sizec / 2, yPos - sizec / 2, sizec, sizec); //draw a circle
        }

        public void Clear(int sizes)
        {
            SolidBrush solidBrush = new SolidBrush(
            Color.FromArgb(255, 255, 255, 255));
            g.FillRectangle(solidBrush, 0, 0, 1000, 1000);
        }



    }
}
