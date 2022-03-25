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

        //For resistors
        public Bitmap resistor;
        public Bitmap resistorRotated;
        private bool isRotated = false;
        private List<Resistor> resistors = new List<Resistor> { };


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
            if(e.KeyChar == 27) {
                this.Cursor = Cursors.Default;
                cursorNum = 0;
            }
            //Shortcuts to components
            if(e.KeyChar == 'c') {
                this.Cursor = new Cursor(resistor.GetHicon());
                cursorNum = 1;
            }

            //Rotate Resistor
            if(cursorNum == 1) {
                if(e.KeyChar == 'r') {
                    if (!isRotated) {
                        this.Cursor = new Cursor(resistorRotated.GetHicon());
                        isRotated = !isRotated;
                    }
                    else {
                        this.Cursor = new Cursor(resistor.GetHicon());
                        isRotated = !isRotated;
                    }
                }
            }
            if(e.KeyChar == 'c') {
                resistors.Clear();
                Resistor.rCount = 0;
                this.Refresh();
            }
        }

        //Mouse events
        private void mouseDown(object sender, MouseEventArgs e){
            if(e.Button == MouseButtons.Left) {
                if (cursorNum == 1) {
                    resistors.Add(new Resistor(this.PointToClient(Cursor.Position), isRotated));
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

        //Drawing settings
        private void formPaint(object sender, PaintEventArgs paintE){
            Pen pen = new Pen(Color.Black, 2);
            Brush brush = new SolidBrush(Color.Black);
            drawResistor(paintE, pen, brush);
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

        //Initializing assets
        private void initAssets() {
            font = new Font(new FontFamily("Consolas"), 18);
            indexFont = new Font(new FontFamily("Consolas"), 12);
            resistor = new Bitmap(getPath("assets/resistor.png"));
            resistorRotated = new Bitmap(getPath("assets/resistorRotated.png"));
        }
        private string getPath(string path) {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);
        }
        
    }
}
