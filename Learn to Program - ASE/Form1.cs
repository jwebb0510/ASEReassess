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
                else if (Commandsplit[0].Equals("colour") == true || Commandsplit[0].Equals("col") == true || Commandsplit[0].Equals("color") == true) //changes colour of the pen
                {
                    if (Commandsplit[1].Equals("red") == true || Commandsplit[1].Equals("r") == true)
                    {
                        Canvas.P1.Color = System.Drawing.Color.Red;
                        Console.WriteLine("COMMAND - RED PEN");
                    }
                    else if (Commandsplit[1].Equals("blue") == true || Commandsplit[1].Equals("blu") == true)
                    {
                        Canvas.P1.Color = System.Drawing.Color.Blue;
                        Console.WriteLine("COMMAND - BLUE PEN");
                    }
                    else if (Commandsplit[1].Equals("black") == true || Commandsplit[1].Equals("bla") == true)
                    {
                        Canvas.P1.Color = System.Drawing.Color.Black;
                        Console.WriteLine("COMMAND - BLACK PEN");
                    }
                    else if (Commandsplit[1].Equals("green") == true || Commandsplit[1].Equals("g") == true)
                    {
                        Canvas.P1.Color = System.Drawing.Color.Green;
                        Console.WriteLine("COMMAND - GREEN PEN");
                    }
                    else if (Commandsplit[1].Equals("yellow") == true || Commandsplit[1].Equals("yel") == true || Commandsplit[1].Equals("y") == true)
                    {
                        Canvas.P1.Color = System.Drawing.Color.Yellow;
                        Console.WriteLine("COMMAND - YELLOW PEN");
                    }
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
            int whileint = 0;
            char whilecmd = '+';
            int whileval = 0;
            string inputcmd = "empty";
            string inputval = "empty";
            int inputvalparsed = 0;
            string commandinit = commandbox.Text.Trim().ToLower();
            string[] lines = commandinit.Split('\n');
            errorBox.Text = "";


           
            for (lineno = 0; lineno < lines.Length; lineno++)
            {

                string[] command = lines[lineno].Split(' ', ',');
                int param = command.Length;

                if (command[0].Equals("moveto") == true)
                {
                    if (param != 3)
                    {
                        if (!string.IsNullOrWhiteSpace(errorBox.Text))
                        { errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Incorrect Parameters for moveTo command"); }
                        else
                        { errorBox.Text = "Line " + (lineno + 1) + " - Incorrect Parameters for moveTo command"; }
                    }
                    else
                    {
                        if (!Int32.TryParse(command[1], out positionx)) ; //translate string to int                    
                        if (!Int32.TryParse(command[2], out positiony)) ;

                        Canvas.xPos = positionx;
                        Canvas.yPos = positiony;
                        Console.WriteLine("COMMAND - PEN MOVED");
                    }
                }


                else if (command[0].Equals("drawto") == true || command[0].Equals("draw") == true)
                {
                    if (param != 3)
                    {
                        if (!string.IsNullOrWhiteSpace(errorBox.Text))
                        { errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Incorrect Parameters for drawTo command"); }
                        else
                        { errorBox.Text = "Line " + (lineno + 1) + " - Incorrect Parameters for drawTo command"; }
                    }
                    else
                    {
                        if (!Int32.TryParse(command[1], out positionx)) ; //translate string to int
                        if (!Int32.TryParse(command[2], out positiony)) ;

                        Canvas.toX = positionx;
                        Canvas.toY = positiony;
                        MyCanvas.DrawLine(Canvas.toX, Canvas.toY);
                        Refresh();//refresh display
                        Console.WriteLine("COMMAND - LINE DRAWN");
                    }
                }
                else if (command[0].Equals("circle") == true)
                {
                    if (param != 2)
                    {
                        if (!string.IsNullOrWhiteSpace(errorBox.Text))
                        { errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Incorrect Parameters for circle command"); }
                        else
                        { errorBox.Text = "Line " + (lineno + 1) + " - Incorrect Parameters for circle command"; }
                    }
                    else
                    {
                        if (command[1].Equals(inputcmd) == true)
                        {
                            //if (!Int32.TryParse(inputval, out positionshape)) ;
                            positionshape = inputvalparsed;
                            Canvas.sizes = positionshape;
                            MyCanvas.DrawCircle(Canvas.sizes);
                            Refresh();//refresh display
                            Console.WriteLine("COMMAND - CIRCLE DRAWN");
                            errorBox.AppendText("\r\n" + "circle");
                        }
                        else
                        {
                            long number1 = 0;
                            bool canConvert = long.TryParse(command[1], out number1);
                            if (canConvert == true)
                            {
                                if (!Int32.TryParse(command[1], out positionshape)) ; //translate string to int

                                Canvas.sizes = positionshape;
                                MyCanvas.DrawCircle(Canvas.sizes);
                                Refresh();//refresh display
                                Console.WriteLine("COMMAND - CIRCLE DRAWN");
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(errorBox.Text))
                                { errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Incorrect Parameters for Circle"); }
                                else
                                { errorBox.Text = "Line " + (lineno + 1) + " - Incorrect Parameters for Circle"; }
                            }
                        }
                    }
                }

                else if (command[0].Equals("square") == true)
                {
                    if (param != 2)
                    {
                        if (!string.IsNullOrWhiteSpace(errorBox.Text))
                        { errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Incorrect Parameters for square command"); }
                        else
                        { errorBox.Text = "Line " + (lineno + 1) + " - Incorrect Parameters for square command"; }
                    }
                    else
                    {
                        long number1 = 0;
                        bool canConvert = long.TryParse(command[1], out number1);
                        if (command[1].Equals(inputcmd) == true)
                        {
                            //if (!Int32.TryParse(inputval, out positionshape)) ;
                            positionshape = inputvalparsed;
                            Canvas.sizes = positionshape;
                            MyCanvas.DrawSquare(Canvas.sizes);
                            Refresh();//refresh display
                            Console.WriteLine("COMMAND - CIRCLE DRAWN");
                        }
                        else
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
                            { errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Incorrect Parameters for Square"); }
                            else
                            { errorBox.Text = "Line " + (lineno + 1) + " - Incorrect Parameters for Square"; }
                        }
                    }
                }

                else if (command[0].Equals("rectangle") == true || command[0].Equals("rect") == true) //what happens if draw rectangle command is used
                {
                    if (param != 3)
                    {
                        if (!string.IsNullOrWhiteSpace(errorBox.Text))
                        { errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Incorrect Parameters for rectangle command"); }
                        else
                        { errorBox.Text = "Line " + (lineno + 1) + " - Incorrect Parameters for rectangle command"; }
                    }
                    else
                    {
                        if (command[1].Equals(inputcmd) == true)
                        {
                            command[1] = inputval;
                        }
                        if (command[2].Equals(inputcmd) == true)
                        {
                            command[2] = inputval;
                        }


                        if (!Int32.TryParse(command[1], out positionx)) ; //translate string to int
                        if (!Int32.TryParse(command[2], out positiony)) ;

                        Canvas.sizerx = positionx;
                        Canvas.sizery = positiony;
                        MyCanvas.DrawRect(Canvas.sizerx, Canvas.sizery);
                        Refresh();//refresh display
                        Console.WriteLine("COMMAND - RECTANGLE DRAWN");
                    }
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
                else if (command[0].Equals("while") == true)
                {
                    loopline = lineno;
                    if(param !=4)
                    {

                    }
                    else
                    {
                        if(command[1].Equals(inputcmd) == true)
                        {
                            if(command[2].Equals("<"))
                            {
                                whilecmd = '<';
                                if (!Int32.TryParse(command[3], out whileint));
                                
                                                                
                            }
                            else if(command[2].Equals(">")) 
                            {
                                whilecmd = '>';
                                if (!Int32.TryParse(command[3], out whileint));
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(errorBox.Text))
                                {
                                    errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Invalid Command");
                                }
                                else
                                {
                                    errorBox.Text = "Line " + (lineno + 1) + " - Invalid Command";
                                }
                            }
                        }
                        else 
                        {
                            if (!string.IsNullOrWhiteSpace(errorBox.Text))
                            {
                                errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Invalid Command");
                            }
                            else
                            {
                                errorBox.Text = "Line " + (lineno + 1) + " - Invalid Command";
                            }
                        }
                    }                 

                }

                else if (command[0].Equals("endwhile") == true)
                {
                    if (whilecmd.Equals('<') == true)
                    {
                        if (!Int32.TryParse(inputval, out inputvalparsed));
                        if (inputvalparsed < whileint)
                        {
                            errorBox.AppendText("\r\n" + "loop");
                            lineno = loopline;
                        }
                    }                   

                }

                //VARIABLES

                else if (command[1].Equals("=") == true)
                {
                    Console.WriteLine("equals");
                    if (command.Length.Equals(3))
                    {
                        inputcmd = command[0];
                        inputval = command[2];
                        if (!Int32.TryParse(inputval, out inputvalparsed)) ;
                    }
                    else if (command.Length.Equals(5))
                    {
                        if (command[2].Equals(inputcmd))
                        {
                            if (command[3].Equals("+"))
                            {
                                int parsed = 0;
                                if (!Int32.TryParse(command[4], out parsed)) ;
                                inputvalparsed = parsed + inputvalparsed;
                                errorBox.AppendText("\r\n" + "add radius");
                            }
                            else if (command[3].Equals("-"))
                            {
                                int parsed = 0;
                                if (!Int32.TryParse(command[4], out parsed)) ;
                                inputvalparsed = parsed - inputvalparsed;
                            }
                            else if (command[3].Equals("/"))
                            {
                                int parsed = 0;
                                if (!Int32.TryParse(command[4], out parsed)) ;
                                inputvalparsed = parsed / inputvalparsed;
                            }
                            else if (command[3].Equals("*"))
                            {
                                int parsed = 0;
                                if (!Int32.TryParse(command[4], out parsed)) ;
                                inputvalparsed = parsed * inputvalparsed;
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(errorBox.Text))
                                {
                                    errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Invalid Command");
                                }
                                else
                                {
                                    Console.WriteLine("While loop broken");
                                    errorBox.Text = "Line " + (lineno + 1) + " - Invalid Command";
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(errorBox.Text))
                        {
                            Console.WriteLine("While loop broken");
                            errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Invalid Parameters");
                        }
                        else
                        {
                            Console.WriteLine("While loop broken");
                            errorBox.Text = "Line " + (lineno + 1) + " - Invalid Parameters";
                        }


                    }


                }

                else
                {
                    if (!string.IsNullOrWhiteSpace(errorBox.Text))
                    {
                        Console.WriteLine("While loop broken");
                        errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Invalid Command");
                    }
                    else
                    {
                        Console.WriteLine("While loop broken");
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
            Canvas.xPos = 0;
            Canvas.yPos = 0;
            Canvas.P1.Color = System.Drawing.Color.Black;
            Console.WriteLine("Pen Reset");
        }

        private void SaveFileDialogSample()
        {
            InitializeComponent();
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveImage1 = new SaveFileDialog();


            saveImage1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveImage1.DefaultExt = "*.tif";
            saveImage1.Filter = "TIFF Files|*.tif";

            if (saveImage1.ShowDialog() == DialogResult.OK)
                OutputBitmap.Save(saveImage1.FileName);

            //string path = saveImage1.FileName;
        }
        private void codeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();

            saveFile1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "txt Files|*.txt";


            if (saveFile1.ShowDialog() == DialogResult.OK)
                commandbox.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFile1 = new OpenFileDialog();

            openFile1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile1.DefaultExt = "*.txt";
            openFile1.Filter = "txt Files|*.txt";

            if (openFile1.ShowDialog() == DialogResult.OK)
                commandbox.LoadFile(openFile1.FileName, RichTextBoxStreamType.PlainText);

            commandline.Text = ""; //clears text from command line
            errorBox.Text = "";
            MyCanvas.Clear(Canvas.sizec);
            Canvas.xPos = 0;
            Canvas.yPos = 0;
            Canvas.P1.Color = System.Drawing.Color.Black;
            Refresh();//refresh display
        }

        private void imageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MyCanvas.Clear(Canvas.sizec);
            Canvas.xPos = 0;
            Canvas.yPos = 0;
            Canvas.P1.Color = System.Drawing.Color.Black;
            Refresh();//refresh display
        }

        private void commandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commandbox.Text = ""; //clears text from command line
            commandline.Text = ""; //clears text from command line
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commandbox.Text = ""; //clears text from command box
            commandline.Text = ""; //clears text from command line
            errorBox.Text = ""; //clears text from syntax box
            MyCanvas.Clear(Canvas.sizec);
            Canvas.xPos = 0;
            Canvas.yPos = 0;
            Canvas.P1.Color = System.Drawing.Color.Black;
            Refresh();//refresh display
        }

        private void syntaxbtn_Click(object sender, EventArgs e)
        {
            int lineno = 0;
            int loopline = 0;
            int loopamount = 1;
            int param = 0;
            string commandinit = commandbox.Text.Trim().ToLower();
            string[] lines = commandinit.Split('\n');
            errorBox.Text = "";

            for (lineno = 0; lineno < lines.Length; lineno++)
            {
                string[] command = lines[lineno].Split(' ', ',');

                if (command[0].Equals("moveto") == true || command[0].Equals("drawto") == true || command[0].Equals("square") == true 
                    || command[0].Equals("circle") == true || command[0].Equals("rectangle") == true || command[0].Equals("colour") == true 
                    || command[0].Equals("loop") == true || command[0].Equals("end") == true) //checks through all known commands
                {
                    if (command[0].Equals("moveto") == true || command[0].Equals("drawto") == true || command[0].Equals("rectangle") == true)
                    {
                        long number1 = 0;
                        bool canConvert = long.TryParse(command[1], out number1);
                        if (canConvert == true) { }
                        else if (!string.IsNullOrWhiteSpace(errorBox.Text))
                        { errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Incorrect Parameters"); }
                        else
                        { errorBox.Text = "Line " + (lineno + 1) + " - Incorrect Parameters"; }
                        canConvert = long.TryParse(command[2], out number1);
                        if (canConvert == true) { }
                        else if (!string.IsNullOrWhiteSpace(errorBox.Text))
                        { errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Incorrect Parameters"); }
                        else
                        { errorBox.Text = "Line " + (lineno + 1) + " - Incorrect Parameters"; }
                    }
                    else if (command[0].Equals("circle") == true || command[0].Equals("square") == true)
                    {
                        long number1 = 0;
                        bool canConvert = long.TryParse(command[1], out number1);
                        if (canConvert == true) { }
                        else {
                            if (!string.IsNullOrWhiteSpace(errorBox.Text))
                            {errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Incorrect Parameters");}
                            else
                            { errorBox.Text = "Line " + (lineno + 1) + " - Incorrect Parameters"; }
                        }
                    }
                    else if (command[0].Equals("colour") == true)
                    {
                        if (command[1].Equals("red") == true || command[1].Equals("blue") == true || command[1].Equals("black") == true || command[1].Equals("green") == true ||
                            command[1].Equals("yellow") == true )
                        {

                        }
                        else if (command[1].Equals(null) == true)
                        {
                            if (!string.IsNullOrWhiteSpace(errorBox.Text))
                            {errorBox.AppendText("\r\n" + "Pen Colour not Defined on line " + (lineno + 1));}
                            else
                            {errorBox.Text = "Pen Colour not Defined on line " + (lineno + 1);}
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(errorBox.Text))
                            {errorBox.AppendText("\r\n" + "Line " + (lineno + 1) + " - Invalid Pen Colour");}
                            else
                            {errorBox.Text = "Line " + (lineno + 1) + " - Invalid Pen Colour";}

                        }
                    }
                }
                else
                {
                    //Console.WriteLine("While loop broken");

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
    }
}
