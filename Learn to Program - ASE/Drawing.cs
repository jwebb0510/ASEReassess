using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learn_to_Program___ASE
{
    class Drawing
    {
        public static int screenx = 1400;
        public static int screeny = 1000;
        public static int positionx;
        public static int positiony;
        public static int positionshape;

        Canvas xPos;
        Canvas yPos;
        Canvas toY;
        Canvas toX;
        Canvas g;

        System.Drawing.Bitmap OutputBitmap = new Bitmap(screenx, screeny);
        Canvas MyCanvas;

    }
}

       
