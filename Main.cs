using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SchematicDrawer{
    public partial class Main : Form{

        private bool isRotated = false;

        //For resistors
        public Bitmap resistor;
        public Bitmap resistorRotated;
        private List<Resistor> resistors = new List<Resistor> { };

        //For capacitor
        public Bitmap capacitor;
        public Bitmap capacitorRotated;
        private List<Capacitor> capacitors = new List<Capacitor> { };

        //For inductors
        public Bitmap inductor;
        public Bitmap inductorRotated;
        private List<Inductor> inductors = new List<Inductor> { };


        private int cursorNum;

        //Cosmetic assets
        public Font font;
        public Font indexFont;

        public Main(){
            InitializeComponent();
            initAssets();
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Main_KeyPress);
        }

        //Keyboard events
        void Main_KeyPress(object sender, KeyPressEventArgs e){
            if (e.KeyChar == 'a'){
                this.addComponentMenu.Show(Cursor.Position);
            }
            //Escape to remove any components
            if(e.KeyChar == 27) {
                this.Cursor = Cursors.Default;
                cursorNum = 0;
            }

            //Rotate Resistor
            if(e.KeyChar == 'r') {
                if(cursorNum == 1) {
                    if (!isRotated) {
                        this.Cursor = new Cursor(resistorRotated.GetHicon());
                        isRotated = !isRotated;
                    }
                    else {
                        this.Cursor = new Cursor(resistor.GetHicon());
                        isRotated = !isRotated;
                    }
                }else if(cursorNum == 2) {
                    if (!isRotated) {
                        this.Cursor = new Cursor(capacitorRotated.GetHicon());
                        isRotated = !isRotated;
                    }
                    else {
                        this.Cursor = new Cursor(capacitor.GetHicon());
                        isRotated = !isRotated;
                    }
                }else if(cursorNum == 3) {
                    if (!isRotated) {
                        this.Cursor = new Cursor(inductorRotated.GetHicon());
                        isRotated = !isRotated;
                    }
                    else {
                        this.Cursor = new Cursor(inductor.GetHicon());
                        isRotated = !isRotated;
                    }
                }
            }
            if(e.KeyChar == 'c') {
                //Initializes the variables to pass to the MessageBox
                string message = "Do you want to clear the table?";
                string caption = "Are you sure?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                //Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes) {
                    resistors.Clear();
                    capacitors.Clear();
                    Resistor.rCount = 0;
                    Capacitor.cCount = 0;
                    isRotated = false;
                    this.Refresh();
                }
            }
        }

        //Mouse events
        private void mouseDown(object sender, MouseEventArgs e){
            if(e.Button == MouseButtons.Left) {
                if (cursorNum == 1) {
                    resistors.Add(new Resistor(this.PointToClient(Cursor.Position), isRotated));
                }else if(cursorNum == 2) {
                    capacitors.Add(new Capacitor(this.PointToClient(Cursor.Position), isRotated));
                }else if(cursorNum == 3) {
                    inductors.Add(new Inductor(this.PointToClient(Cursor.Position), isRotated));
                }
            }
            else if(e.Button == MouseButtons.Right) {
                this.Cursor = Cursors.Default;
                isRotated = false;
                cursorNum = 0;
            }
        }
        private void mouseUp(object sender, MouseEventArgs e) {

        }
        private void mouseMove(object sender, MouseEventArgs e) {
            this.Refresh();
        }

        //Picking items
        private void resistorToolStripMenuItem_Click(object sender, EventArgs e){
            this.Cursor = new Cursor(resistor.GetHicon());
            isRotated = false;
            cursorNum = 1;
        }
        private void capacitorToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Cursor = new Cursor(capacitor.GetHicon());
            isRotated = false;
            cursorNum = 2;
        }
        private void inductorToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Cursor = new Cursor(inductor.GetHicon());
            isRotated = false;
            cursorNum = 3;
        }

        //Drawing settings
        private void formPaint(object sender, PaintEventArgs paintE){
            paintE.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Black, 1.6f);
            Brush brush = new SolidBrush(Color.Black);
            drawResistor(paintE, pen, brush);
            drawCapacitor(paintE, pen, brush);
            drawInductor(paintE, pen, brush);
        }

        //Drawing components
        private void drawResistor(PaintEventArgs e, Pen pen, Brush brush) {
            if (resistors.Count != 0) {
                foreach (Resistor r in resistors) { 
                    e.Graphics.DrawLine(pen, r.line1s, r.line1e);
                    e.Graphics.DrawRectangle(pen, r.rect);
                    e.Graphics.DrawLine(pen, r.line2s, r.line2e);
                    e.Graphics.DrawString("R", font, brush, r.text);
                    e.Graphics.DrawString(Convert.ToString(r.resCount), indexFont, brush, r.textIndex);
                }
            }
        }
        private void drawCapacitor(PaintEventArgs e, Pen pen, Brush brush) {
            if (capacitors.Count != 0) {
                foreach (Capacitor c in capacitors) {
                    e.Graphics.DrawLine(pen, c.line1s, c.line1e);
                    e.Graphics.DrawLine(pen, c.line2s, c.line2e);
                    e.Graphics.DrawLine(pen, c.line3s, c.line3e);
                    e.Graphics.DrawLine(pen, c.line4s, c.line4e);
                    e.Graphics.DrawString("C", font, brush, c.text);
                    e.Graphics.DrawString(Convert.ToString(c.capCount), indexFont, brush, c.textIndex);
                }
            }
        }
        private void drawInductor(PaintEventArgs e, Pen pen, Brush brush) {
            if (inductors.Count != 0) {
                foreach (Inductor i in inductors) {
                    e.Graphics.DrawLine(pen, i.line1s, i.line1e);
                    e.Graphics.DrawArc(pen, i.arcStart1.X, i.arcStart1.Y, i.size1.X, i.size1.Y, i.startAngle1, i.endAngle1);
                    e.Graphics.DrawArc(pen, i.arcStart2.X, i.arcStart2.Y, i.size2.X, i.size2.Y, i.startAngle2, i.endAngle2);
                    e.Graphics.DrawArc(pen, i.arcStart3.X, i.arcStart3.Y, i.size3.X, i.size3.Y, i.startAngle3, i.endAngle3);
                    e.Graphics.DrawArc(pen, i.arcStart4.X, i.arcStart4.Y, i.size4.X, i.size4.Y, i.startAngle4, i.endAngle4);
                    e.Graphics.DrawLine(pen, i.line2s, i.line2e);
                    e.Graphics.DrawString("L", font, brush, i.text);
                    e.Graphics.DrawString(Convert.ToString(i.indCount), indexFont, brush, i.textIndex);
                }
            }
        }

        //Initializing assets
        private void initAssets() {
            font = new Font(new FontFamily("Consolas"), 18);
            indexFont = new Font(new FontFamily("Consolas"), 12);
            resistor = new Bitmap(getPath("assets/resistor.png"));
            resistorRotated = new Bitmap(getPath("assets/resistorRotated.png"));
            capacitor = new Bitmap(getPath("assets/capacitor.png"));
            capacitorRotated = new Bitmap(getPath("assets/capacitorRotated.png"));
            inductor = new Bitmap(getPath("assets/inductor.png"));
            inductorRotated = new Bitmap(getPath("assets/inductorRotated.png"));
        }
        private string getPath(string path) {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);
        }

    }
}
