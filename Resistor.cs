using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchematicDrawer{
    class Resistor{
        public int x, y;
        public Point line1s, line1e, line2s, line2e, text, textIndex;
        public Rectangle rect;
        public static int rCount = 0;
        public int resCount;

        public Resistor() {
            x = 0;
            y = 0;
        }
        public Resistor(Point p, bool isRotated) {
            x = p.X;
            y = p.Y;
            if (!isRotated) {
                line1s = new Point(x, y - 48);
                line1e = new Point(x, y - 35);
                rect = new Rectangle(x - 13, y - 35, 26, 71);
                line2s = new Point(x, y + 35);
                line2e = new Point(x, y + 48);
                text = new Point(x + 15, y - 35);
                textIndex = new Point(x + 30, y - 25);
            }
            else {
                line1s = new Point(x - 48, y);
                line1e = new Point(x - 35, y);
                rect = new Rectangle(x - 35, y - 13, 71, 26);
                line2s = new Point(x + 35, y);
                line2e = new Point(x + 48, y);
                text = new Point(x - 30, y - 45);
                textIndex = new Point(x - 15, y - 35);
            }
            rCount++;
            resCount = rCount;
            
        }
    }
}
