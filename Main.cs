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
            //Shortcuts to components
            if(e.KeyChar == 'r') {
                this.Cursor = new Cursor(resistor.GetHicon());
                cursorNum = 1;
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
                }
            }
            else if(e.Button == MouseButtons.Right) {
                this.Cursor = Cursors.Default;
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
            cursorNum = 1;
        }
        private void capacitorToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Cursor = new Cursor(capacitor.GetHicon());
            cursorNum = 2;
        }

        //Drawing settings
        private void formPaint(object sender, PaintEventArgs paintE){
            Pen pen = new Pen(Color.Black, 2);
            Brush brush = new SolidBrush(Color.Black);
            drawResistor(paintE, pen, brush);
            drawCapacitor(paintE, pen, brush);
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

        //Initializing assets
        private void initAssets() {
            font = new Font(new FontFamily("Consolas"), 18);
            indexFont = new Font(new FontFamily("Consolas"), 12);
            resistor = new Bitmap(getPath("assets/resistor.png"));
            resistorRotated = new Bitmap(getPath("assets/resistorRotated.png"));
            capacitor = new Bitmap(getPath("assets/capacitor.png"));
            capacitorRotated = new Bitmap(getPath("assets/capacitorRotated.png"));
        }
        private string getPath(string path) {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);
        }

        
    }
}
