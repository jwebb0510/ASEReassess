using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learn_to_Program___ASE
{
    public partial class Form1 : Form
    {
        public static int screenx = 914;
        public static int screeny = 975;
        public static int positionx;
        public static int positiony;
        public static int positionshape;
        MemoryStream userInput = new MemoryStream();

        Canvas xPos;
        Canvas yPos;
        Canvas toY;
        Canvas toX;
        Canvas g;

        Bitmap OutputBitmap = new Bitmap(screenx, screeny);
        Canvas MyCanvas;


        public Form1()
        {
            InitializeComponent();
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
            MyCanvas.Clear(Canvas.sizec);
            Refresh();//refresh display
        }





        private void commandline_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (TextBoxBase)sender;
            string Command = commandline.Text.Trim().ToLower();
            string[] Commandsplit = Command.Split(' ', ',');
            if (e.KeyCode == Keys.Enter)
            {

                Console.WriteLine("ENTER PRESSED");

                if (Commandsplit[0].Equals("moveto") == true || Commandsplit[0].Equals("move") == true)
                {
                    if (!Int32.TryParse(Commandsplit[1], out positionx)) ; //translate string to int
                    if (!Int32.TryParse(Commandsplit[2], out positiony)) ;

                    Canvas.xPos = positionx;
                    Canvas.yPos = positiony;

                    Console.WriteLine("COMMAND - PEN MOVED");

                }

                else if (Commandsplit[0].Equals("drawto") == true || Commandsplit[0].Equals("draw") == true)
                {
                    if (!Int32.TryParse(Commandsplit[1], out positionx)) ; //translate string to int
                    if (!Int32.TryParse(Commandsplit[2], out positiony)) ;

                    Canvas.toX = positionx;
                    Canvas.toY = positiony;
                    MyCanvas.DrawLine(Canvas.toX, Canvas.toY);
                    Refresh();//refresh display
                    Console.WriteLine("COMMAND - LINE DRAWN");

                }

                else if (Commandsplit[0].Equals("square") == true)
                {
                    if (!Int32.TryParse(Commandsplit[1], out positionshape)) ; //translate string to int

                    Canvas.sizes = positionshape;
                    MyCanvas.DrawSquare(Canvas.sizes);
                    Refresh();//refresh display
                    Console.WriteLine("COMMAND - SQUARE DRAWN");


                }
                else if (Commandsplit[0].Equals("rectangle") == true || Commandsplit[0].Equals("rect") == true) //what happens if draw rectangle command is used
                {
                    if (!Int32.TryParse(Commandsplit[1], out positionx)) ; //translate string to int
                    if (!Int32.TryParse(Commandsplit[2], out positiony)) ;

                    Canvas.sizerx = positionx;
                    Canvas.sizery = positiony;
                    MyCanvas.DrawRect(Canvas.sizerx, Canvas.sizery);
                    Refresh();//refresh display
                    Console.WriteLine("COMMAND - RECTANGLE DRAWN");
                }
                else if (Commandsplit[0].Equals("circle") == true)
                {
                    if (!Int32.TryParse(Commandsplit[1], out positionx)) ;

                    Canvas.sizec = positionx;
                    MyCanvas.DrawCircle(Canvas.sizec);
                    Refresh();//refresh display
                    Console.WriteLine("COMMAND - CIRCLE DRAWN");
                }
                
                

                commandline.Text = ""; //clears text from command line
                Console.WriteLine("CONSOLE CLEARED");
                Refresh();//refresh display
            }
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void run_button(object sender, EventArgs e)
        {
            MyCanvas.Clear(Canvas.sizec);
            Refresh();//refresh display

            int lineno = 0;
            int loopline = 0;
            int loop = 0;
            string commandinit = commandbox.Text.Trim().ToLower();
            string[] lines = commandinit.Split('\n');
            errorBox.Text = "";

           
            for (lineno = 0; lineno < lines.Length; lineno++)
            {

                string[] command = lines[lineno].Split(' ', ',');
                int param = command.Length;

                if (command[0].Equals("moveto") == true)
                {

                    if (!Int32.TryParse(command[1], out positionx)) ; //translate string to int                    
                    if (!Int32.TryParse(command[2], out positiony)) ;

                    Canvas.xPos = positionx;
                    Canvas.yPos = positiony;
                    Console.WriteLine("COMMAND - PEN MOVED");

                }


                else if (command[0].Equals("drawto") == true || command[0].Equals("draw") == true)
                {
                    if (!Int32.TryParse(command[1], out positionx)) ; //translate string to int
                    if (!Int32.TryParse(command[2], out positiony)) ;

                    Canvas.toX = positionx;
                    Canvas.toY = positiony;
                    MyCanvas.DrawLine(Canvas.toX, Canvas.toY);
                    Refresh();//refresh display
                    Console.WriteLine("COMMAND - LINE DRAWN");

                }
                else if (command[0].Equals("circle") == true)
                {
                    if (!Int32.TryParse(command[1], out positionx)) ;

                    Canvas.sizec = positionx;
                    MyCanvas.DrawCircle(Canvas.sizec);
                    Refresh();//refresh display
                    Console.WriteLine("COMMAND - CIRCLE DRAWN");
                }

                else if (command[0].Equals("square") == true)
                {
                    
                    long number1 = 0;
                    bool canConvert = long.TryParse(command[1], out number1);
                    if (canConvert == true) 
                    {
                        if (!Int32.TryParse(command[1], out positionshape)) ; //translate string to int

                        Canvas.sizes = positionshape;
                        MyCanvas.DrawSquare(Canvas.sizes);
                        Refresh();//refresh display
                        Console.WriteLine("COMMAND - SQUARE DRAWN");
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(errorBox.Text))
                        { errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Incorrect Parameters"); }
                        else
                        { errorBox.Text = "Line " + (lineno + 1) + " - Incorrect Parameters"; }
                    }

                }

                else if (command[0].Equals("rectangle") == true) //what happens if draw rectangle command is used
                {
                    if (!Int32.TryParse(command[1], out positionx)) ; //translate string to int
                    if (!Int32.TryParse(command[2], out positiony)) ;

                    Canvas.sizerx = positionx;
                    Canvas.sizery = positiony;
                    MyCanvas.DrawRect(Canvas.sizerx, Canvas.sizery);
                    Refresh();//refresh display
                    Console.WriteLine("COMMAND - RECTANGLE DRAWN");

                }

                else if (command[0].Equals("colour") == true) //changes colour of the pen
                {
                    if (command[1].Equals("red") == true)
                    {
                        Canvas.P1.Color = System.Drawing.Color.Red;
                        Console.WriteLine("COMMAND - RED PEN");
                    }
                    else if (command[1].Equals("blue") == true)
                    {
                        Canvas.P1.Color = System.Drawing.Color.Blue;
                        Console.WriteLine("COMMAND - BLUE PEN");
                    }
                    else if (command[1].Equals("black") == true)
                    {
                        Canvas.P1.Color = System.Drawing.Color.Black;
                        Console.WriteLine("COMMAND - BLACK PEN");
                    }
                    else if (command[1].Equals("green") == true)
                    {
                        Canvas.P1.Color = System.Drawing.Color.Green;
                        Console.WriteLine("COMMAND - GREEN PEN");
                    }
                    else if (command[1].Equals("yellow") == true)
                    {
                        Canvas.P1.Color = System.Drawing.Color.Yellow;
                        Console.WriteLine("COMMAND - YELLOW PEN");
                    }
                    else if (command[1].Equals(null) == true)
                    {
                        if (!string.IsNullOrWhiteSpace(errorBox.Text))
                        {
                            errorBox.AppendText("\r\n" + "Pen Colour not Defined on line " + (lineno + 1));
                        }
                        else
                        {
                            errorBox.Text = "Pen Colour not Defined on line " + (lineno + 1);
                        }

                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(errorBox.Text))
                        {
                            errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Invalid Pen Colour");
                        }
                        else
                        {
                            errorBox.Text = "Line " + (lineno + 1) + " - Invalid Pen Colour";
                        }

                    }


                }
                else if (command[0].Equals("loop") == true)
                {
                    loopline = lineno;
                    loop++;
                    lineno++;
                }

                else if (command[0].Equals("end") == true)
                {
                    if (loop == 1)
                    {
                        lineno = loopline;
                    }
                    else
                        loop = 0;
                        lineno++;
                        
                }

                else
                {
                    Console.WriteLine("While loop broken");

                    if (!string.IsNullOrWhiteSpace(errorBox.Text))
                    {
                        errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Invalid Command");
                    }
                    else
                    {
                        errorBox.Text = "Line " + (lineno + 1) + " - Invalid Command";
                    }

                    //break;
                }

            }


        }

        private void displaywindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //get graphics context to display
            g.DrawImageUnscaled(OutputBitmap, 0, 0); //put the bitmap into the form
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            


        }

        private void SaveFileDialogSample()
        {
            InitializeComponent();
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            


        }



        private void codeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            
        }

        private void imageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void commandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void syntaxbtn_Click(object sender, EventArgs e)
        {
                 
        }
    }
}
